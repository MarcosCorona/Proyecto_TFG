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

        private static ProductsTableAdapter productAdapter = new ProductsTableAdapter();
        
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

        internal static ObservableCollection<ProductModel> GetProducts()
        {
            ObservableCollection<ProductModel> productsList = new ObservableCollection<ProductModel>();
            DataTable productListDT = productAdapter.GetData();
            foreach (DataRow productRow in productListDT.Rows)
            {
                ProductModel product = new ProductModel();
                product.ItemId = (int)productRow["ItemId"];
                product.Name = (string)productRow["Name"];
                product.Quantity = (int)productRow["Quantity"];
                product.Price = (double)productRow["Price"];
                product.Description = (string)productRow["Description"];
                productsList.Add(product);
            }
            return productsList;
        }
    }
}
