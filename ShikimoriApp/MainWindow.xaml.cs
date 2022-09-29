using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
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

namespace ShikimoriApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ShikimoriController controller;
        public MainWindow()
        {
            InitializeComponent();
            controller = new ShikimoriController();

            
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            animesDataGrid.ItemsSource = controller.GetAnimes();
        }
    }
}
