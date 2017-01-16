using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPlane
{
    class SignalMessage
    {
        public int CallID { get; set; }
        public string CallingID { get; set; }
        public string CalledID { get; set; }
        public int Capacity { get; set; }
        public bool Confirmation { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int LabelIN { get; set; }
        public int LabelOUT { get; set; }
        public int ModificationID { get; set; }

        public SignalMessage()
        {

        }



    }
}
