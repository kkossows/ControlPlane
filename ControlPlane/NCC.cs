using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainController
{
    class NCC
    {
        public int _callID { get; set;}
        public string _callingID { get; set; }
        public string _calledID { get; set; }
        public int _capacity { get; set; }
        public bool _confirmation { get; set; }
        public string _name { get; set; }
        public string _type { get; set; }
        public int _labelIN { get; set; }
        public int _labelOUT { get; set; }


        public NCC()
        {
            DirectoryClass dir;
            PolicyClass pol;

        }
        //4
        private SignalMessage CallCoordination(int _callID, string _callingID, string _calledID, int _capacity)
        {
            SignalMessage smCC = new SignalMessage();
            smCC._callID = _callID;
            smCC._callingID = _callingID;
            smCC._calledID = _calledID;
            smCC._capacity = _capacity;

                return smCC;
        }
        //7
        private SignalMessage CallIndication(int _callID, string _callingID, string _calledID, int _capactity)
        {
            SignalMessage smCI = new SignalMessage();
            smCI._callID = _callID;
            smCI._callingID = _callingID;
            smCI._calledID = _calledID;
            smCI._capacity = _capacity;

            return smCI;
        }
        //8
        private SignalMessage CallAccept(int _callID, bool _confirmation)
        {
            SignalMessage smCA = new SignalMessage();
            smCA._callID = _callID;
            smCA._confirmation = _confirmation;
            return smCA;

        }
        //16
        private SignalMessage CallAccept(int _callID, bool _confirmation, int _labelOUT)
        {
            SignalMessage smCAl = new SignalMessage();
            smCAl._callID = _callID;
            smCAl._confirmation = _confirmation;
            smCAl._labelOUT = _labelOUT;
            return smCAl;
        }
        //5
        private SignalMessage DirectoryRequest(string _calledID)
        {
            SignalMessage smDR = new SignalMessage();
            smDR._calledID = _calledID;
            
            return smDR;
        }

        //10
        private SignalMessage ConnectionRequest(int _callID, string _callingID, string _calledID)
        {
            SignalMessage smCR = new SignalMessage();
            smCR._callID = _callID;
            smCR._callingID = _callingID;
            smCR._calledID = _calledID;
            return smCR;
        }
        //12
        private SignalMessage CallModificationRequest(int _callID, string _type)
        {
            SignalMessage smCMR = new SignalMessage();
            smCMR._callID = _callID;
            smCMR._type = _type;
            return smCMR;
        }
        //13
        private SignalMessage CallModificationIndication(int _modificationID, int _callID, string _type, int _labelOUT)
        {
            SignalMessage smCMI = new SignalMessage();
            smCMI._modificationID = _modificationID;
            smCMI._callID = _callID;
            smCMI._type = _type;
            smCMI._labelOUT = _labelOUT;
            return smCMI;
        }


    }
}
