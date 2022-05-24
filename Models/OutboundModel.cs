using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TFG.Models
{
    class OutboundModel
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }    
        public DateTime OrderDate { get; set; }
        public double Total { get; set; }   
    }
}
