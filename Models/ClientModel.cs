using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TFG.Models
{
    class ClientModel
    {
        public int ClientId { get; set; }
        public string Name { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string NIF { get; set; }

        public override string ToString()
        {
            return ClientId + ". " + Name;
        }

    }
}
