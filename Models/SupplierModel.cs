using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TFG.Models
{
    class SupplierModel:ICloneable
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string NIF { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
        public override string ToString()
        {
            return SupplierId + ". " + Name;
        }

    }
}
