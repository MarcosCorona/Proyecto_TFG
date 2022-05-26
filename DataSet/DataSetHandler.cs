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

        private static ClientsTableAdapter clientAdapter = new ClientsTableAdapter();

        private static OutboundOrdersTableAdapter outboundAdapter = new OutboundOrdersTableAdapter();

        private static OutboundDetailTableAdapter detailAdapter = new OutboundDetailTableAdapter();

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

        public static int i = 1;

        
        internal static bool insertOutbound(int clientId, DateTime date, double total)
        {
            try
            {
                DataTable outboundDataTale = outboundAdapter.GetData();
                if (outboundDataTale.Rows.Count < 0)
                {
                    return false;
                }
                else
                {
                    i++;
                    outboundAdapter.Insert(clientId, date, (Decimal)total); 
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        internal static bool insertDetail(int itemId, string description, int quantity, double price)
        {
            try
            {
                DataTable detailTableAdapter = detailAdapter.GetData();
                if (detailTableAdapter.Rows.Count < 0)
                {
                    return false;
                }
                else
                {
                    detailAdapter.Insert(i, itemId, description, (Decimal)price, quantity);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        internal static ObservableCollection<ClientModel> GetClients()
        {
            ObservableCollection<ClientModel> clientsList = new ObservableCollection<ClientModel>();
            DataTable clientListDT = clientAdapter.GetData();
            foreach (DataRow clientRow in clientListDT.Rows)
            {
                ClientModel client = new ClientModel();
                client.ClientId = (int)clientRow["ClientId"];
                client.Name = (string)clientRow["Name"];
                client.Telephone = (string)clientRow["Telephone"];
                client.Email = (string)clientRow["Email"];
                client.NIF = (string)clientRow["NIF"];
                clientsList.Add(client);
            }
            return clientsList;
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
        internal static ObservableCollection<OutboundModel> GetOutbounds()
        {
            ObservableCollection<OutboundModel> outboundsList = new ObservableCollection<OutboundModel>();
            DataTable outboundListDT = outboundAdapter.GetData();
            foreach (DataRow outboundRow in outboundListDT.Rows)
            {
                OutboundModel outbound = new OutboundModel();
                outbound.OrderId = (int)outboundRow["OrderId"];
                outbound.ClientId = (int)outboundRow["ClientId"];
                outbound.OrderDate = (DateTime)outboundRow["OrderDate"];
                outbound.Total = (double)outboundRow["Total"];
                outboundsList.Add(outbound);
            }
            return outboundsList;
        }
        internal static void updateqty(int resultQty, int itemId)
        {
            ObservableCollection<ProductModel> productsList = new ObservableCollection<ProductModel>();
            productAdapter.UpdateQuantity(resultQty,itemId);
            GetProducts();
        }
    }
}
