using Proyecto_TFG.Models;
using Proyecto_TFG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_TFG.Commands
{
    class UpdateViewCommandV2 : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public PDFViewModel pDFViewModel;

        public void Execute(object parameter)
        {
            if (parameter is string)
            {
                string viewName = (string)parameter;

                if (viewName.Equals("outbound"))
                {
                    homeViewModel.SelectedViewModel = new OutboundViewModel(this);

                }
                else if (viewName.Equals("inventory"))
                {
                    homeViewModel.SelectedViewModel = new InventoryViewModel(this);
                }
                else if (viewName.Equals("inbounds"))
                {
                    homeViewModel.SelectedViewModel = new InboundViewModel(this);

                }else if (viewName.Equals("clients"))
                {
                    homeViewModel.SelectedViewModel = new ClientsViewModel(this);
                }
                else if (viewName.Equals("suppliers"))
                {
                    homeViewModel.SelectedViewModel = new SupplierViewModel(this);
                }else if (viewName.Equals("users"))
                {
                    homeViewModel.SelectedViewModel = new UsersViewModel(this);
                }else if (viewName.Equals("pdfOutbound"))
                {
                    homeViewModel.SelectedViewModel = pDFViewModel;
                }
                else if (viewName.Equals("pdfInbound"))
                {
                    homeViewModel.SelectedViewModel = pDFViewModel;
                }
           
            }
        }

        public HomeViewModel homeViewModel { get; set; }

        public UpdateViewCommandV2(HomeViewModel homeViewModel)
        {
            this.homeViewModel = homeViewModel;
            pDFViewModel = new PDFViewModel(this);

        }
    }
}
