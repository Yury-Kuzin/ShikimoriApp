using ShikimoriApp.ViewModels;
using System;
using System.Windows;


namespace ShikimoriApp
{
    // TODO: 1. Сделать возможность открывать окна внутри одного приложения :(
    // TODO: 2. Фильтрация: 1. Годы :(
    // TODO: 4. Пагинация (Отображение кол-ва страниц и блокировка стрелок)
    // TODO: 5. DataGrid при пагинации не возвращается в начало!!!
    // TODO: 6. Анимация скриншотов
    // TODO: 7. Обработка ошибок

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
