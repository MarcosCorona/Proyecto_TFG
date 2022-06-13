using Proyecto_TFG.Handlers;
using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
using Proyecto_TFG.Views;
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
            //metodo para añadir productos a la lista del carrito.
            //atributos
            ProductModel product = inboundViewModel.Product;
            ProductModel product2 = new ProductModel();
            Boolean encontradok = false;
            product2.Total = 0;
            //si el producto no es nulo 
            if (product != null)
            {   //y la cantidad que solicitamos no es mayor a la que existe.
                if (inboundViewModel.Quantity <= product.Quantity)
                {
                    //si la cantidad es mayor que 0
                    if (inboundViewModel.Quantity > 0)
                    {
                        //si la cuenta de la lista del carrito es 0
                        if (inboundViewModel.CharList.Count == 0)
                        {   
                            //clonamos un segundo producto que será añadido a la lista del carrito
                            product2 = (ProductModel)product.Clone();
                            product2.Quantity = inboundViewModel.Quantity;
                            product2.Total = product2.Quantity * product2.Price;
                            inboundViewModel.CharList.Add(product2);
                        }
                        else
                        {
                            //por cada producto en la lista del carrito
                            foreach (ProductModel p in inboundViewModel.CharList)
                            {
                                //si coincide un producto con el producto que deseamos añadir
                                if (product.ItemId.Equals(p.ItemId))
                                {
                                    //en vez de crear un nuevo producto se le suma cantidad y se recalcula el total.
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
                            //si no se ha encontrado.
                            if (encontradok == false)
                            {
                                //se clona el producto con la cantidad y total calculados y se añade a la lista
                                product2 = (ProductModel)product.Clone();
                                product2.Quantity = inboundViewModel.Quantity;
                                product2.Total = product2.Quantity * product2.Price;
                                inboundViewModel.CharList.Add(product2);
                            }
                        }

                        inboundViewModel.Total = 0;
                        foreach (ProductModel p in inboundViewModel.CharList)
                        {
                            //calculo del total del alabaran
                            inboundViewModel.Total = p.Total + inboundViewModel.Total;
                            
                        }

                        //una vez se ha realizado lo anterior, se actualizará la cantidad del producto en la base de datos.
                        int resultQty = product.Quantity + inboundViewModel.Quantity;
                        DataSetHandler.updateqty(resultQty, product.ItemId);
                        inboundViewModel.ProductsList = DataSetHandler.GetProducts();
                    }
                    else
                    {
                        //error, cantidad negativa.
                        qpositive();
                    }
                }
                else
                {
                    //error, no hay suficiente stock
                    qexcesive();
                }
            }
            else
            {
                //Error, producto no selecionado
                sproduct();
            }

        }
        private void qpositive()
        {
            bool? Result = new MessageBoxCustom("Quantity most be positive.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void qexcesive()
        {
            bool? Result = new MessageBoxCustom("Doesn't exists enough quantity of stock .", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        private void sproduct()
        {
            bool? Result = new MessageBoxCustom("Select a product.", MessageType.Error, MessageButtons.Ok).ShowDialog();
        }
        public InboundViewModel inboundViewModel { get; set; }
        public AddtoInboundChartCommand(InboundViewModel inboundViewModel)
        {
            this.inboundViewModel = inboundViewModel;
        }
    } 
}
