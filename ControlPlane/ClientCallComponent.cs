using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//węzeł sterowania umiezczony w środku klienta
namespace ControlPlane
{
    class ClientCallComponent
    {
        public PC PC_module { get; private set; }
        public CPCC CPCC_module { get; private set; }

        public ClientCallComponent()
        {
            PC_module = new PC();
            CPCC_module = new CPCC();
        }
    }
}
