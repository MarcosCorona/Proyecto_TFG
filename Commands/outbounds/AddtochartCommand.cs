using Newtonsoft.Json;
using Proyecto_TFG.Handlers;
using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Proyecto_TFG.Commands
{
    class AddtochartCommand: ICommand
    {
    
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ProductModel product = outboundViewModel.Product;
            ProductModel product2 = new ProductModel();
            Boolean encontradok = false;
            product2.Total = 0;
            if(product != null)
            {
                if (outboundViewModel.Quantity <= product.Quantity)
                {
                    if (outboundViewModel.Quantity > 0)
                    {
                        if (outboundViewModel.CharList.Count == 0)
                        {
                            product2 = (ProductModel)product.Clone();
                            product2.Quantity = outboundViewModel.Quantity;
                            product2.Total = product2.Quantity * product2.Price;
                            outboundViewModel.CharList.Add(product2);
                        }
                        else
                        {
                            foreach (ProductModel p in outboundViewModel.CharList)
                            {
                                if (product.ItemId.Equals(p.ItemId))
                                {
                                    encontradok = true;
                                    p.Quantity = outboundViewModel.Quantity + p.Quantity;
                                    p.Total = p.Quantity * p.Price;
                                    break;
                                }
                                else
                                {
                                    encontradok = false;
                                }
                            }
                            if (encontradok == false)
                            {
                                product2 = (ProductModel)product.Clone();
                                product2.Quantity = outboundViewModel.Quantity;
                                product2.Total = product2.Quantity * product2.Price;
                                outboundViewModel.CharList.Add(product2);
                            }
                        }

                        outboundViewModel.Total = 0;
                        foreach (ProductModel p in outboundViewModel.CharList)
                        {
                            outboundViewModel.Total = p.Total + outboundViewModel.Total;
                        }

                            int resultQty = product.Quantity - outboundViewModel.Quantity;
                        DataSetHandler.updateqty(resultQty, product.ItemId);
                        outboundViewModel.ProductsList = DataSetHandler.GetProducts();
                    }
                    else
                    {
                        MessageBox.Show("Quantity most be positive.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a product.");
            }
            

        }
        public OutboundViewModel outboundViewModel { get; set; }
        public AddtochartCommand(OutboundViewModel outboundViewModel)
        {
            this.outboundViewModel = outboundViewModel;
        }
   
    }
}
