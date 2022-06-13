using Proyecto_TFG.Commands;
using Proyecto_TFG.Handlers;
using Proyecto_TFG.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            test();
        }
        ObservableCollection<PersonModel> personsList = DataSetHandler.GetPerson();
        
        public void test()
        {
            PersonModel person = new PersonModel();
            person = DataSetHandler.getUser();
            foreach(PersonModel p in personsList)
            {
                if(p.dni == person.dni)
                {
                    if (p.job == "RRHH")
                    {
                        outboundsbt.Visibility = Visibility.Collapsed;
                        inboundsbt.Visibility = Visibility.Collapsed;
                        inventorybt.Visibility = Visibility.Collapsed;
                        clientsbt.Visibility = Visibility.Collapsed;
                        suppliersbt.Visibility = Visibility.Collapsed;
                        employeesbt.Visibility = Visibility.Visible;
                    }
                    else if (p.job.Equals("Administrative"))
                    {
                        outboundsbt.Visibility = Visibility.Visible;
                        inboundsbt.Visibility = Visibility.Visible;
                        inventorybt.Visibility = Visibility.Collapsed;
                        clientsbt.Visibility = Visibility.Visible;
                        suppliersbt.Visibility = Visibility.Visible;
                        employeesbt.Visibility = Visibility.Collapsed;
                    }
                    else if (p.job.Equals("Stock"))
                    {
                        outboundsbt.Visibility = Visibility.Collapsed;
                        inboundsbt.Visibility = Visibility.Collapsed;
                        inventorybt.Visibility = Visibility.Visible;
                        clientsbt.Visibility = Visibility.Collapsed;
                        suppliersbt.Visibility = Visibility.Collapsed;
                        employeesbt.Visibility = Visibility.Collapsed;
                    }
                    else if (p.job.Equals("Boss"))
                    {
                        outboundsbt.Visibility = Visibility.Visible;
                        inboundsbt.Visibility = Visibility.Visible;
                        inventorybt.Visibility = Visibility.Visible;
                        clientsbt.Visibility = Visibility.Visible;
                        suppliersbt.Visibility = Visibility.Visible;
                        employeesbt.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        outboundsbt.Visibility = Visibility.Collapsed;
                        inboundsbt.Visibility = Visibility.Collapsed;
                        inventorybt.Visibility = Visibility.Collapsed;
                        clientsbt.Visibility = Visibility.Collapsed;
                        suppliersbt.Visibility = Visibility.Collapsed;
                        employeesbt.Visibility = Visibility.Collapsed;
                    }
                    break;
                }
            }
        }
        public void enableAll()
        {
            outboundsbt.IsEnabled = true;
            inboundsbt.IsEnabled = true;
            inventorybt.IsEnabled = true;
            clientsbt.IsEnabled = true;
            suppliersbt.IsEnabled = true;
            employeesbt.IsEnabled = true;
        }
        private void outboundsbt_Click(object sender, RoutedEventArgs e)
        {
            enableAll();
            outboundsbt.IsEnabled = false;
        }

        private void inboundsbt_Click(object sender, RoutedEventArgs e)
        {
            enableAll();
            inboundsbt.IsEnabled = false;
        }

        private void inventorybt_Click(object sender, RoutedEventArgs e)
        {
            enableAll();
            inventorybt.IsEnabled = false;
        }

        private void clientsbt_Click(object sender, RoutedEventArgs e)
        {
            enableAll();
            clientsbt.IsEnabled = false;
        }

        private void suppliersbt_Click(object sender, RoutedEventArgs e)
        {
            enableAll();
            suppliersbt.IsEnabled = false;
        }

        private void employeesbt_Click(object sender, RoutedEventArgs e)
        {
            enableAll();
            employeesbt.IsEnabled = false;
        }
    }
}
