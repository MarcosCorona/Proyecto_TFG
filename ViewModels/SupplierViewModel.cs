using Proyecto_TFG.Commands;
using Proyecto_TFG.Commands.Clients;
using Proyecto_TFG.Commands.Supplier;
using Proyecto_TFG.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TFG.ViewModels
{
    class SupplierViewModel: ViewModelBase
    {
        public UpdateViewCommandV2 updateViewCommandv2 { set; get; }
        public LoadSuppliersListCommand loadSuppliersListCommand { get; set; }
        public LoadSupplierCommand loadSupplierCommand { get; set; }
        public CreateSupplierCommand createSupplierCommand { set; get; }
        public ClearSupplierCommand clearSupplierCommand { get; set; }
        public DeleteSupplierCommand deleteSupplierCommand { set; get; }
        public ModifySupplierCommand modifySupplierCommand { set; get; }
        public SearchSupplierCommand searchSupplierCommand { set; get; }


        private SupplierModel currentSupplier { get; set; }
        public SupplierModel CurrentSupplier
        {
            get { return currentSupplier; }
            set
            {
                currentSupplier = value;
                OnPropertyChanged(nameof(CurrentSupplier));
            }
        }
        private SupplierModel selectedSupplier { get; set; }
        public SupplierModel SelectedSupplier
        {
            get { return selectedSupplier; }
            set
            {
                selectedSupplier = value;
                OnPropertyChanged(nameof(SelectedSupplier));
            }
        }

        private SupplierModel supplier;
        public SupplierModel Supplier
        {
            get { return supplier; }
            set
            {
                supplier = value;
                OnPropertyChanged(nameof(Supplier));
            }
        }
        private ObservableCollection<SupplierModel> supplierList;
        public ObservableCollection<SupplierModel> SupplierList
        {
            set
            {
                supplierList = value;
                OnPropertyChanged(nameof(SupplierList));
            }
            get
            {
                return supplierList;
            }
        }

        public int searchedId { get; set; }

        public SupplierViewModel(UpdateViewCommandV2 updateViewCommand)
        {
            updateViewCommandv2 = updateViewCommand;
            loadSuppliersListCommand = new LoadSuppliersListCommand(this);
            loadSupplierCommand = new LoadSupplierCommand(this);
            createSupplierCommand = new CreateSupplierCommand(this);
            clearSupplierCommand = new ClearSupplierCommand(this);
            deleteSupplierCommand = new DeleteSupplierCommand(this);
            modifySupplierCommand = new ModifySupplierCommand(this);
            searchSupplierCommand = new SearchSupplierCommand(this);
            CurrentSupplier = new SupplierModel();
        }
    }
}
