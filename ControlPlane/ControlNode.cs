using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//klasa testowa reprezentująca np fioletowy węzeł sterowania
namespace ControlPlane
{
    class ControlNode
    {
        //inne
        public PC PC_module { get; private set; }

        //warstwa CALL
        public NCC NCC_module { get; private set; }

        //warstwa CONNECTION
        public CC CC_module { get; private set; }
        public RC RC_module { get; set; }
        public LRM LRM_module { get; private set; }


        public ControlNode()
        {
            PC_module = new PC();

            NCC_module = new NCC();

            CC_module = new CC();
            RC_module = new RC();
            LRM_module = new LRM();
        }
    }
}
