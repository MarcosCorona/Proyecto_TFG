using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TFG.Models
{
    class PersonModel
    {
        public string dni { get; set; } 
        public string name { get; set; }        

        public string lastname { get; set; }    

        public string email { get; set; }   

        public DateTime birthday { get; set; }

        public string password { get; set; }    

        public int job_id { set; get; } 
        public int address_id { set; get; } 


    }
}
