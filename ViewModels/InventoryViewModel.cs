using Proyecto_TFG.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TFG.ViewModels
{
    class InventoryViewModel: ViewModelBase
    {
        public UpdateViewCommandV2 updateViewCommandv2 { set; get; }


        public InventoryViewModel(UpdateViewCommandV2 updateViewCommand)
        {
            updateViewCommandv2 = updateViewCommand;
        }
    }
}
