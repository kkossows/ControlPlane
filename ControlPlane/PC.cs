﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


//Tutaj musze zrobić wysyłanie pakietów 
namespace ControlPlane
{
    
    class PC
    {
        #region Network_Variables
        private Socket _pcSocket;
        private IPEndPoint _pcIpEndPoint;

        private string _pcIpAddress;
        private int _pcPort;

        private IPEndPoint _receivingIPEndPoint;
        private EndPoint _receivingEndPoint;

        private byte[] _buffer;
        private int _bufferSize;
        #endregion

        #region Other_Variables

        #endregion

        #region Properties
        #endregion

        #region Delegates
        private delegate void Delegate_SendInsideMessage(SignalMessage message);
        private delegate void Delegate_ReceiveInsideMessage(SignalMessage message);
        #endregion

        #region MainMethodes
        public PC(string configurationFolderPath)
        {
            InitialiseVariables(configurationFolderPath);
            InitializeSocket();
        }

        private void InitialiseVariables(string configurationFolderPath)
        {
            //wczytanie wszystkich zmiennych z pliku znajdującego się w katalogu o podanej ściezce
            //plik nazywać się będzie PC_configuration.xml
        }
        #endregion



        #region Networ_Methodes
        private void InitializeSocket()
        {
            try
            {
                //tworzymy gniazdo i przypisujemy mu numer portu i IP zgodne z plikiem konfig
                _pcSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                _pcIpEndPoint = new IPEndPoint((IPAddress.Parse(_pcIpAddress)), _pcPort);
                _pcSocket.Bind(_pcIpEndPoint);
            }
            catch
            {
                //LOG
                DeviceClass.MakeLog("ERROR - Incorrect IP address or port number or these values are already in use.");
                //_cloud.StopWorking("Incorrect IP address or port number or these values are already in use.");
            }

            //LOG
            DeviceClass.MakeLog("INFO - PC Socket: IP:" + _pcIpAddress + " Port:" + _pcPort);

            //tworzymy punkt końcowy, z którego będziemy odbierali dane (z jakiegokolwiek adresu IP na porcie sygnalizacyjnym _pcPort)
            _receivingIPEndPoint = new IPEndPoint(IPAddress.Any, _pcPort);
            _receivingEndPoint = (EndPoint)_receivingIPEndPoint;

            //tworzymy bufor nasłuchujący
            _buffer = new byte[_bufferSize];

            //nasłuchujemy
            _pcSocket.BeginReceiveFrom(_buffer, 0, _buffer.Length, SocketFlags.None, ref _receivingEndPoint, new AsyncCallback(ReceivedPacket), null);

            //LOG
            DeviceClass.MakeLog("INFO - Start Listening.");
        }

        public void ReceivedPacket(IAsyncResult res)
        {
            int size;
            try
            {
                //kończę odbieranie danych
                size = _pcSocket.EndReceiveFrom(res, ref _receivingEndPoint);
            }
            catch
            {
                IPEndPoint unreachableHost = _receivingEndPoint as IPEndPoint;
                DeviceClass.MakeLog("ERROR - Cannnot send packet to: IP:" + unreachableHost.Address + " Port: " + unreachableHost.Port + ". Destination unreachable (Port unreachable)");

                //ustawiam odpowiedni recivingEndPoint
                _receivingIPEndPoint = new IPEndPoint(IPAddress.Any, _pcPort);
                _receivingEndPoint = (EndPoint)_receivingIPEndPoint;

                //uruchamiam ponowne nasłuchiwanie
                _pcSocket.BeginReceiveFrom(_buffer, 0, _buffer.Length, SocketFlags.None, ref _receivingEndPoint, new AsyncCallback(ReceivedPacket), null);

                return;
            }

            //tworzę tablicę bajtów składającą się jedynie z danych otrzymanych (otrzymany pakiet)
            byte[] receivedPacket = new byte[size];
            Array.Copy(_buffer, receivedPacket, receivedPacket.Length);

            //tworzę tymczasowy LOKALNY punkt końcowy zawierający informacje o nadawcy (jego ip oraz nr portu)
            IPEndPoint _receivedIPEndPoint = (IPEndPoint)_receivingEndPoint;

            //zeruje bufor odbierający
            _buffer = new byte[_bufferSize];

            //ustawiam odpowiedni recivingEndPoint
            _receivingIPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            _receivingEndPoint = (EndPoint)_receivingIPEndPoint;

            //uruchamiam ponowne nasłuchiwanie
            _pcSocket.BeginReceiveFrom(_buffer, 0, _buffer.Length, SocketFlags.None, ref _receivingEndPoint, new AsyncCallback(ReceivedPacket), null);

            //tworzę logi
            DeviceClass.MakeLog("INFO - Received packet from: IP:" + _receivedIPEndPoint.Address + " Port: " + _receivedIPEndPoint.Port);

            //przesyłam otrzymaną wiadomość do metody odpowiedzialnej za przetwarzanie
            ProcessReceivedPacket(receivedPacket, ref _receivedIPEndPoint);
        }

        public void SendPacket(IAsyncResult res)
        {
            var endPoint = res.AsyncState as IPEndPoint;
            int size = _pcSocket.EndSendTo(res);

            //tworzę logi
            DeviceClass.MakeLog("INFO - Packet send to: IP:" + endPoint.Address + " Port: " + endPoint.Port);
        }

        public void SendMyPacket(byte[] myPacket, string destinationIP)
        {
            byte[] packet = myPacket;
            IPEndPoint destinationIpEndPoint = new IPEndPoint(IPAddress.Parse(destinationIP), _pcPort);

            //inicjuje start wysyłania przetworzonego pakietu do nadawcy
            _pcSocket.BeginSendTo(packet, 0, packet.Length, SocketFlags.None, destinationIpEndPoint, new AsyncCallback(SendPacket), null);
        }

        private void ProcessReceivedPacket(byte[] receivedPacket)
        {
            SignalMessage receivedMessage = ByteToSignalMessage(receivedPacket);

        }
        #endregion

        #region InsideMessageMethodes_DELEGATES
        private void SendInsideMessage(SignalMessage message)
        {
            Delegate_ReceiveInsideMessage receiveMessage = new Delegate_ReceiveInsideMessage(ReceiveInsideMessage);
            receiveMessage.BeginInvoke(message, new AsyncCallback(ReceiveInsideMessageCallback), null);
        }
        static private void SendInsideMessageCallback(IAsyncResult async)
        {
            //napisz loga, ze wiadomość została przesłana dalej
            //metoda wywoływana po wyjściu z metody SendInsideMessage
        }

        private void ReceiveInsideMessage(SignalMessage message)
        {

        }
        static private void ReceiveInsideMessageCallback(IAsyncResult async)
        {
            //napisz loga, że otrzymałeś wiadomość
            //metoda wywoływana po wyjściu z metody ReceiveInsideMessage
        }
        #endregion

        #region OtherMethodes
        public void SendMessageMethod(SignalMessage message)
        {
            //trzeba jakoś sprawdzić, czy ma wysyłać wiadomość wewnętrzną, czy zewnętrzną
            bool insideMessage = CheckIfMessageIsInsideOrOutside(message);

            if(insideMessage)
            {
                //inicjalizacja delegata
                Delegate_SendInsideMessage sendMessage = new Delegate_SendInsideMessage(SendInsideMessage);
                sendMessage.BeginInvoke(message, new AsyncCallback(SendInsideMessageCallback), null);
            }
            else
            {
                string destinationIP = message.DestinationIpAddress;
                byte[] data = SignalMessageToByte(message);

                SendMyPacket(data, destinationIP);
            }
        }
        private bool CheckIfMessageIsInsideOrOutside(SignalMessage message)
        {
            //jakoś sprawdzamy jak true to wewnętrzna jak false to zewnętrzna
            //jakoś po adresach docelowych w message trzeba sprawdzać
            return true;
        }
        #endregion

        #region Serialize_Deserialize
        static byte[] SignalMessageToByte(SignalMessage sm)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, sm);   //Wpisanie w memory streama obiektu
            return ms.ToArray();    //Zwraca ms w formie tablicy bajtów
        }
        private static SignalMessage ByteToSignalMessage(byte[] inData)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            ms.Write(inData, 0, inData.Length);
            ms.Seek(0, SeekOrigin.Begin);
            object o = (object)bf.Deserialize(ms);

            return (SignalMessage)o;
        }
        #endregion
    }
}
