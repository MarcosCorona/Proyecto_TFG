using Proyecto_TFG.DataSet.DataSet1TableAdapters;
using Proyecto_TFG.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TFG.Handlers
{
 
    class DataSetHandler
    {
        private static PersonTableAdapter personAdapter = new PersonTableAdapter();
        
        public static ObservableCollection<PersonModel> GetPerson()
        {
            ObservableCollection<PersonModel> personsList = new ObservableCollection<PersonModel>();
            DataTable personListDT = personAdapter.GetData();
            foreach (DataRow personRow in personListDT.Rows)
            {
                PersonModel person = new PersonModel();
                person.dni = (string)personRow["Dni"];
                person.name = (string)personRow["Name"];
                person.password = (string)personRow["Password"];
                person.lastname = (string)personRow["Lastname"];
                person.address_id = (int)personRow["Address_id"];
                person.job_id = (int)personRow["Job_id"];
                person.email = (string)personRow["Email"];
                person.birthday = (DateTime)personRow["Birthday"];
               

                personsList.Add(person);
            }
            return personsList;
        }

    }
}
