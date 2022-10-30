using ShikimoriApp.ViewModels;
using System;
using System.Windows;


namespace ShikimoriApp
{
    // TODO: 1. Сделать возможность открывать окна внутри одного приложения
    // TODO: 3. Фильтрация: 1. Годы 2. Продолжительность
    // TODO: 4. Сортировка всего списка + Не работает сортировка по имени
    // TODO: 5. Изучить авторизацию
    // TODO: 6. Пагинация
    // TODO: 7. DataGrid при пагинации не возвращается в начало

    // TODO: 999: Получить длительность всех аниме в МИРЕ.
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mainWindowViewModel;
        public MainWindow()
        {
            InitializeComponent();
            mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;
        }
    }
}
