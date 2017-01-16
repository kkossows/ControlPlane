using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPlane
{
    class CPCC
    {

        #region Variables
        private PC _packetController;
        private string _localHostName;
        private string _myDomainNccIpAddress;
        private Dictionary<int, Call> _callDictionary;  //słownik wiążący callID z jego parametrami
        #endregion

        #region Properties
        #endregion

        #region MainMethodes
        public CPCC(string configurationFolderPath, PC packetController)
        {
            _packetController = packetController;
            InitialiseVariables(configurationFolderPath);
        }

        private void InitialiseVariables(string configurationFolderPath)
        {
            //configurationFolderPath będzie zawierał między innymi plik CPCC_configuration.xml
            //tutaj będziemy go parsować
            //wyjmujemy z niego _localHostName oraz wartosci słownika
        }
        #endregion


        #region Call_Modificate_Start_Methodes
        //metoda odpowiedzialna za znalezienie unikalnego identyfikatora sesji
        private int GetCallNewIndex()
        {
            int index = _callDictionary.Count();
            if (index == 0)
                index++;
            while (_callDictionary.ContainsKey(index))
                index++;

            return index;
        }

        //metoda będzie wywoływana w węzle klienckim, jeżeli będziemy chcieli utworzyć sesję
        //będziemy wysyłać żądaną przepustowość oraz miejsce docelowe
        public string CpccCallRequest(string calledID, int callingCapacity)
        {
            int callID = GetCallNewIndex();
            SignalMessage signalMessage = CallRequest(callID, _localHostName, calledID, callingCapacity);

            

            return null;
        }

        public string CpccCallRealise(string calledID, int callingCapacity)
        {
            return null;
        }

        //metoda wywołana, jezeli CPCCInvoke skończy działanie
        static public void CpccCallEnd(IAsyncResult async)
        {

        }

        #endregion


        #region Methodes_From_Standardization
        //1
        private SignalMessage CallRequest(int callID, string callingID, string calledID, int capacity)
        {
            SignalMessage message = new SignalMessage()
            {
                DestinationIpAddress = _myDomainNccIpAddress,

                SignalMessageType = SignalMessage.SignalType.CallRequest,
                CallID = callID,
                CallingID = callingID,
                CalledID = calledID,
                CallingCapacity = capacity
            };
   
            return message;
        }







        //8
        private SignalMessage CallAccept(int _callID, bool _confirmation)
        {

            return null;
        }

        //14
        private SignalMessage CallModificationAccept(int _modificationID)
        {
            SignalMessage smCMA = new SignalMessage();
            smCMA._modificationID = _modificationID;


            return smCMA;
        }
        #endregion

    }

    //wartości, jakie może przyjmować status zgłoszenia
    public enum CallState
    {
        inProgress, rejected, confirmed
    }

    //struktura zgłoszenia
    public struct Call
    {
        string _callingID;
        string _calledID;
        int _callingCapacity;
        CallState _state;
    }
}
