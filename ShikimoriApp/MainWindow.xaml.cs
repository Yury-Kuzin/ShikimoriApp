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
    // TODO: 1. Сделать возможность открывать окна внутри одного приложения
    // TODO: 2. Фильтрация по имени
    // TODO: 3. Фильтрация: 1. Годы 2. Продолжительность
    // TODO: 4. Сортировка всего списка + Не работает сортировка по имени
    // TODO: 5. Изучить авторизацию
    // TODO: 6. Пагинация
    // TODO: 7. 


    // TODO: 999: Получить длительность всех аниме в МИРЕ.
    public partial class MainWindow : Window
    {
        ShikimoriController controller;
        public MainWindow()
        {
            InitializeComponent();
            controller = new ShikimoriController();
            animesDataGrid.ItemsSource = controller.GetAnimes();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
