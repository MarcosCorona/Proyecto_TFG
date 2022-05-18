using Newtonsoft.Json;
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
            ProductModel product = new ProductModel();
            outboundViewModel.SelectedProduct = (ProductModel)parameter;
            product = (ProductModel)outboundViewModel.SelectedProduct.Clone();
           

            Boolean encontradok = false;

            if (outboundViewModel.Quantity <= product.Quantity) 
            { 
                if(product.Quantity > 0)
                {
                    foreach (ProductModel p in outboundViewModel.CharList)
                    {

                        if (product.ItemId.Equals(p.ItemId))
                        {
                            encontradok = true;
                            p.Quantity = outboundViewModel.Quantity + p.Quantity;
                            outboundViewModel.Total = p.Quantity * p.Price;
                            break;
                        }
                        else
                        {
                            encontradok = false;
                        }

                        if (encontradok == false)
                        {
                            outboundViewModel.Total = product.Quantity * product.Price;
                            outboundViewModel.CharList.Add(product);

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Quantity most be positive.");
                }
            }

        }
        public OutboundViewModel outboundViewModel { get; set; }
        public AddtochartCommand(OutboundViewModel outboundViewModel)
        {
            this.outboundViewModel = outboundViewModel;
        }
    }
}
