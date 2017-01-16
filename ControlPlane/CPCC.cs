using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainController
{
    class CPCC
    {
        public int _callID { get; set; }
        public string _callingID { get; set; }
        public string _calledID { get; set; }
        public int _capacity { get; set; }
        public bool _confirmation { get; set; }

        public CPCC()
        {

        }
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


    }
}
