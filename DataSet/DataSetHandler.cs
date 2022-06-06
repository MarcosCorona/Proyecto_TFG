using Proyecto_TFG.DataSet.DataSet1TableAdapters;
using Proyecto_TFG.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_TFG.Handlers
{
 
    class DataSetHandler
    {
        private static PersonTableAdapter personAdapter = new PersonTableAdapter();

        private static ProductsTableAdapter productAdapter = new ProductsTableAdapter();

        private static ClientsTableAdapter clientAdapter = new ClientsTableAdapter();

        private static OutboundOrdersTableAdapter outboundAdapter = new OutboundOrdersTableAdapter();

        private static InboundsTableAdapter inboundAdapter = new InboundsTableAdapter();

        private static InboundDetailTableAdapter inboundDetailAdapter = new InboundDetailTableAdapter();

        private static OutboundDetailTableAdapter detailAdapter = new OutboundDetailTableAdapter();

        private static SupplierTableAdapter supplierAdapter = new SupplierTableAdapter();

        private static OutboundPDFTableAdapter opdfAdapter = new OutboundPDFTableAdapter();

        private static InboundPDFTableAdapter ipdfAdapter = new InboundPDFTableAdapter();




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
                person.address = (string)personRow["Address"];
                person.job = (string)personRow["Job"];
                person.email = (string)personRow["Email"];
                person.birthday = (DateTime)personRow["Birthday"];
                person.city = (string)personRow["City"];


                personsList.Add(person);
            }
            return personsList;
        }


        public static PersonModel person = new PersonModel();
        public static void setUser(PersonModel p)
        {
            person = p;
            getUser();
        }

        public static PersonModel getUser()
        {
            return person;
        }

        internal static ObservableCollection<InboundDetailModel> getInboundDetails()
        {
            ObservableCollection<InboundDetailModel> detailList = new ObservableCollection<InboundDetailModel>();
            DataTable detailListDT = inboundDetailAdapter.GetData();
            foreach (DataRow detailRow in detailListDT.Rows)
            {
                InboundDetailModel detail = new InboundDetailModel();
                detail.DetailId = (int)detailRow["DetailId"];
                detail.OrderId = (int)detailRow["OrderId"];
                detail.ItemId = (int)detailRow["ItemId"];
                detail.ProductDesc = (string)detailRow["ProductDescription"];
                detail.ProductQuantity = (int)detailRow["ProductQuantity"];
                detail.ProductPrice = (decimal)detailRow["ProductPrice"];

                detailList.Add(detail);
            }
            return detailList;
        }

        internal static ObservableCollection<InboundModel> GetInbounds()
        {
            ObservableCollection<InboundModel> inboundList = new ObservableCollection<InboundModel>();
            DataTable inboundListDT = inboundAdapter.GetData();
            foreach (DataRow inboundRow in inboundListDT.Rows)
            {
                InboundModel inbound = new InboundModel();
                inbound.OrderId = (int)inboundRow["OrderId"];
                inbound.SupplierId = (int)inboundRow["SupplierId"];
                inbound.OrderDate = (DateTime)inboundRow["OrderDate"];
                inbound.Total = (double)inboundRow["Total"];
                inboundList.Add(inbound);
            }
            return inboundList;
        }

        internal static ObservableCollection<OutboundDetailModel> getDetails()
        {
            ObservableCollection<OutboundDetailModel> detailList = new ObservableCollection<OutboundDetailModel>();
            DataTable detailListDT = detailAdapter.GetData();
            foreach (DataRow detailRow in detailListDT.Rows)
            {
                OutboundDetailModel detail = new OutboundDetailModel();
                detail.DetailId = (int)detailRow["DetailId"];
                detail.OrderId = (int)detailRow["OrderId"];
                detail.ItemId = (int)detailRow["ItemId"];
                detail.ProductDesc = (string)detailRow["ProductDescription"];
                detail.ProductQuantity = (int)detailRow["ProductQuantity"];
                detail.ProductPrice = (decimal)detailRow["ProductPrice"];

                detailList.Add(detail);
            }
            return detailList;
        }

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
                    outboundAdapter.Insert(clientId, date, (Decimal)total); 
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        internal static bool insertInbound(int supplierId, DateTime date, double total)
        {
            try
            {
                DataTable inboundDataTable = inboundAdapter.GetData();
                if (inboundDataTable.Rows.Count < 0)
                {
                    return false;
                }
                else
                {
                    inboundAdapter.Insert(supplierId, date, (Decimal)total);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        internal static bool insertProduct(int itemId, string Name, int Quantity, double price, string description)
        {
            DataTable productTableAdapter = productAdapter.GetData();
            if(productTableAdapter.Rows.Count < 0)
            {
                return false;
            }
            else
            {
                productAdapter.Insert(Name, Quantity, (decimal)price, description);
                return true;
            }
            
        }

        internal static bool insertSupplier(int supplierId, string name, string telephone, string email, string nIF)
        {
            DataTable supplierTableAdapter = supplierAdapter.GetData();
            if (supplierTableAdapter.Rows.Count < 0)
            {
                return false;
            }
            else
            {
                supplierAdapter.Insert(name, telephone, email, nIF);
                return true;
            }
        }

        internal static bool insertUser(string dni, string name, string lastname, string email, string password, DateTime birthday, string job, string address, string city)
        {

            DataTable userTableAdapter = personAdapter.GetData();
            if (userTableAdapter.Rows.Count < 0)
            {
                return false;
            }
            else
            {
                if(dni is null)
                {
                    MessageBox.Show("Dni is empty.");
                }
                personAdapter.Insert(dni,name,lastname,email,password,birthday,job,address,city);
                return true;
            }
        }

        internal static bool insertClient(int clientId, string name, string telephone, string email, string nIF)
        {
            DataTable clientTableAdapter = clientAdapter.GetData();
            if (clientTableAdapter.Rows.Count < 0)
            {
                return false;
            }
            else
            {
                clientAdapter.Insert(name, telephone, email, nIF);
                return true;
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
                    DataRow ultimoRegistro = outboundAdapter.GetData().Last();
                    int idLastOutbound = (int)ultimoRegistro["OrderId"];
                    detailAdapter.Insert(idLastOutbound, itemId, description, (Decimal)price, quantity);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        internal static bool insertInboundDetail(int itemId, string description, int quantity, double price)
        {
            try
            {
                DataTable detailTableAdapter = inboundDetailAdapter.GetData();
                if (detailTableAdapter.Rows.Count < 0)
                {
                    return false;
                }
                else
                {
                    DataRow lastItem = inboundAdapter.GetData().Last();
                    int idLastInbound = (int)lastItem["OrderId"];
                    inboundDetailAdapter.Insert(idLastInbound, itemId, description, (Decimal)price, quantity);
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

        internal static ObservableCollection<SupplierModel> GetSuppliers()
        {
            ObservableCollection<SupplierModel> suppliersList = new ObservableCollection<SupplierModel>();
            DataTable supplierListDT = supplierAdapter.GetData();
            foreach (DataRow supplierRow in supplierListDT.Rows)
            {
                SupplierModel supplier = new SupplierModel();
                supplier.SupplierId = (int)supplierRow["SupplierId"];
                supplier.Name = (string)supplierRow["Name"];
                supplier.Telephone = (string)supplierRow["Telephone"];
                supplier.Email = (string)supplierRow["Email"];
                supplier.NIF = (string)supplierRow["NIF"];
                suppliersList.Add(supplier);
            }
            return suppliersList;
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
            productAdapter.UpdateQuantity(resultQty,itemId);
        }

        internal static void removeOutbound(int orderId)
        {
            outboundAdapter.DeleteOrder(orderId);
        }
        internal static void removeDetail(int orderId)
        {
            detailAdapter.DeleteDetail(orderId);
        }
        internal static void removeInbound(int orderId)
        {
            inboundAdapter.DeleteInbound(orderId);
        }
        internal static void deleteClient(int clientId)
        {
            clientAdapter.DeleteClient(clientId);
        }
        internal static void deleteSupplier(int supplierId)
        {
            supplierAdapter.DeleteSupplier(supplierId);
        }

        internal static void removeInboundDetail(int orderId)
        {
            inboundDetailAdapter.DeleteDetail(orderId);
        }

        internal static void deleteProduct(int itemId)
        {
            productAdapter.deleteProduct(itemId);
        }


        internal static void deleteUser(string dni)
        {
            personAdapter.DeleteUser(dni);
        }
        internal static void modifyProduct(int itemId,string name, int quantity, string description, double price)
        {
            productAdapter.updateProduct(name, quantity, (decimal)price, description, itemId);
        }

        internal static void modifyClient(int clientId, string name, string telephone, string email, string nIF)
        {
            clientAdapter.UpdateClient(name, telephone, email, nIF,clientId);
        }

        internal static void modifySupplier(int supplierId, string name, string telephone, string email, string nIF)
        {
            supplierAdapter.UpdateSupplier(name, telephone, email, nIF, supplierId);
        }
        internal static void modifyUser(string dni, string name, string lastname, string email, string password, DateTime birthday, string job, string address, string city)
        {
            string date = birthday.ToString();
            personAdapter.UpdateUser(dni, name, lastname, email, password, date, job, address, city, dni);
        }

        public static DataTable getOutboundDataByOrderId(int orderid)
        {
            return opdfAdapter.GetDataById(orderid);
        }

        public static DataTable getInboundDataByOrderID(int orderid)
        {
            return ipdfAdapter.GetDataById(orderid);

        }


    }
}
