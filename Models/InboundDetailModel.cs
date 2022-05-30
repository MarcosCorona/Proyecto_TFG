using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TFG.Models
{
    class InboundDetailModel
    {
        public int DetailId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public string ProductDesc { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
    }
}
