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
    /// Lógica de interacción para OutboundsView.xaml
    /// </summary>
    public partial class OutboundsView : UserControl
    {
        public OutboundsView()
        {
            InitializeComponent();
        }

        private void createClick(object sender, RoutedEventArgs e)
        {
            managePanel.Visibility = Visibility.Collapsed;
            createPanel.Visibility = Visibility.Visible;    
        }

        private void manageClick(object sender, RoutedEventArgs e)
        {
            managePanel.Visibility = Visibility.Visible;
            createPanel.Visibility = Visibility.Collapsed;
        }
    }
}
