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

        //metoda wczytuje słownik jeżeli już jakiś istnieje
        private void InitialiseVariables(string configurationFolderPath)
        {
            //configurationFolderPath będzie zawierał między innymi plik CPCC_configuration.xml
            //tutaj będziemy go parsować
        }


        //metoda będzie wywoływana w węzle klienckim, jeżeli będziemy chcieli utworzyć sesję lub ją zamknąć
        //będziemy wysyłać żądaną przepustowość oraz miejsce docelowe
        public void CPCCInvoke(string callingID, int callingCapacity)
        {

        }

        //metoda wywołana, jezeli CPCCInvoke skończy działanie
        static public void CPCCEnd(IAsyncResult async)
        {

        }
        #endregion


        #region MethodesFromstandardization
        //1
        private SignalMessage CallRequest(int _callID, string _callingID, string _calledID, int _capacity)
        {
            SignalMessage smCR = new SignalMessage();
            smCR._callID = _callID;
            smCR._callingID = _callingID;
            smCR._calledID = _calledID;
            smCR._capacity = _capacity;

            return smCR;
        }
        //8
        private SignalMessage CallAccept(int _callID, bool _confirmation)
        {
            SignalMessage smCA = new SignalMessage();
            smCA._callID = _callID;
            smCA._confirmation = _confirmation;
          

            return smCA;
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

    //struktura zgłoszenia
    public struct Call
    {
        public string CallingID { get; private set; }
        public string CalledID { get; private set; }
        public int CallingCapacity { get; private set; }
        public bool Confirmed { get; private set; }
    }
}
