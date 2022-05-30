using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_TFG.Views
{
    /// <summary>
    /// Lógica de interacción para InventoryView.xaml
    /// </summary>
    public partial class InventoryView : UserControl
    {
        public InventoryView()
        {
            InitializeComponent();
            ed1();
            
        }

        private void editClick(object sender, RoutedEventArgs e)
        {
            btcreate.Visibility = Visibility.Collapsed;
            btedit.Visibility = Visibility.Collapsed;
            btmod.Visibility = Visibility.Visible;
            btdel.Visibility = Visibility.Visible;
            btcancel.Visibility = Visibility.Visible;
            searchp.Visibility = Visibility.Visible;
            
            txtid.Visibility = Visibility.Visible;
            boxid.Visibility = Visibility.Visible;
            boxid.IsEnabled = false;


            ProductsList.IsEnabled = true;
        }

        private void ed1()
        {
            btcreate.Visibility = Visibility.Visible;
            btedit.Visibility = Visibility.Visible;
            btmod.Visibility = Visibility.Collapsed;  
            btdel.Visibility = Visibility.Collapsed;
            btcancel.Visibility = Visibility.Collapsed;
            searchp.Visibility = Visibility.Collapsed;
            txtid.Visibility = Visibility.Collapsed;
            boxid.Visibility = Visibility.Collapsed;
            ProductsList.IsEnabled = false;

            
            
        }

        private void btcancel_Click(object sender, RoutedEventArgs e)
        {
            ed1();
        }


    }
}
