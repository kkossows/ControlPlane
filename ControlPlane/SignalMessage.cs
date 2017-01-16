using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPlane
{
    public class SignalMessage
    {
        #region General
        public SignalType SignalMessageType { get; set; }
        public string DestinationIpAddress { get; set; }
        #endregion

        #region Call
        public int CallID { get; set; }
        public string CallingID { get; set; }
        public string CalledID { get; set; }
        public int CallingCapacity { get; set; }
        #endregion

        #region Connection
        public int ConnnectionID { get; set; }
        public int LabelIN { get; set; }
        public int LabelOUT { get; set; }
        public int ModificationID { get; set; }
        #endregion


        public enum SignalType
        {
            CallRequest, CallAccept
        };

        public SignalMessage()
        {

        }
    }
}
