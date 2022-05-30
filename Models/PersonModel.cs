using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TFG.Models
{
    class PersonModel: ICloneable
    {
        public string dni { get; set; } 
        public string name { get; set; }        

        public string lastname { get; set; }    

        public string email { get; set; }
        
        public string address { get; set; }

        public DateTime birthday { get; set; }

        public string password { get; set; }    
        public string city { get; set; }

        public string job { get; set; }

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
            return dni + ". " + name;
        }


    }
}
