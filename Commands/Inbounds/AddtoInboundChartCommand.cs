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

namespace Proyecto_TFG.Commands.Inbounds
{
    internal class AddtoInboundChartCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ProductModel product = inboundViewModel.Product;
            ProductModel product2 = new ProductModel();
            Boolean encontradok = false;
            product2.Total = 0;
            if (product != null)
            {
                if (inboundViewModel.Quantity <= product.Quantity)
                {
                    if (inboundViewModel.Quantity > 0)
                    {
                        if (inboundViewModel.CharList.Count == 0)
                        {
                            product2 = (ProductModel)product.Clone();
                            product2.Quantity = inboundViewModel.Quantity;
                            product2.Total = product2.Quantity * product2.Price;
                            inboundViewModel.CharList.Add(product2);
                        }
                        else
                        {
                            foreach (ProductModel p in inboundViewModel.CharList)
                            {
                                if (product.ItemId.Equals(p.ItemId))
                                {
                                    encontradok = true;
                                    p.Quantity = inboundViewModel.Quantity + p.Quantity;
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
                                product2.Quantity = inboundViewModel.Quantity;
                                product2.Total = product2.Quantity * product2.Price;
                                inboundViewModel.CharList.Add(product2);
                            }
                        }

                        inboundViewModel.Total = 0;
                        foreach (ProductModel p in inboundViewModel.CharList)
                        {
                            inboundViewModel.Total = p.Total + inboundViewModel.Total;
                        }

                        int resultQty = product.Quantity + inboundViewModel.Quantity;
                        DataSetHandler.updateqty(resultQty, product.ItemId);
                        inboundViewModel.ProductsList = DataSetHandler.GetProducts();
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
        public InboundViewModel inboundViewModel { get; set; }
        public AddtoInboundChartCommand(InboundViewModel inboundViewModel)
        {
            this.inboundViewModel = inboundViewModel;
        }
    } 
}
