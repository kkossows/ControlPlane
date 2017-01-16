using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainController
{
    class SignalMessage
    {
        public int _callID { get; set; }
        public string _callingID { get; set; }
        public string _calledID { get; set; }
        public int _capacity { get; set; }
        public bool _confirmation { get; set; }
        public string _name { get; set; }
        public string _type { get; set; }
        public int _labelIN { get; set; }
        public int _labelOUT { get; set; }
        public int _modificationID { get; set; }
        public SignalMessage()
        {

        }



    }
}
