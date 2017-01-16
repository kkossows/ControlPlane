using System;
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
        SignalMessage sm;
        //OD KRZYŚKA
        Socket client;
        IPEndPoint clientIpEndPoint;
        IPEndPoint cloudIPEndPoint;
        EndPoint cloudEndPoint;

        byte[] buffer;
        byte[] receivedPacket;
        byte[] packet;
        string myIpAddress;
        int myPort;

        string cloudIpAddress;
        int cloudPort;
        




        //Zamiana obiektu na ciąg bitów
        static byte[] SignalMessageToByte(SignalMessage sm)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            //Wpisanie w memory streama obiektu
            bf.Serialize(ms, sm);
            //Zwraca ms w formie tablicy
            return ms.ToArray();
        }


        //Odtwarzanie z ciagu bitów obiektu
        private static SignalMessage ByteToLog(byte[] inData)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            ms.Write(inData, 0, inData.Length);
            ms.Seek(0, SeekOrigin.Begin);
            object o = (object)bf.Deserialize(ms);
            return (SignalMessage)o;
        }
    }
}
