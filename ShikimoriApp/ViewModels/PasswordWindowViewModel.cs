using ShikimoriApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ShikimoriApp.ViewModels
{
    class PasswordWindowViewModel : INotifyPropertyChanged
    {
        private Window window;
        private string password;
        private bool? dialogResult;
        public event PropertyChangedEventHandler? PropertyChanged;
        public PasswordWindowViewModel(Window window)
        {
            this.window = window;
            password = "123456";
        }

        public bool? DialogResult
        {
            get { return dialogResult; }
            set
            {
                dialogResult = value;
                OnPropertyChanged("DialogResult");
            }
        }

        private string? passwordText;
        public string? PasswordText
        {
            get { return passwordText; }
            set
            {
                passwordText = value;
                OnPropertyChanged("PasswordText");
            }
        }

        private RelayCommand? checkPassword;
        public RelayCommand CheckPassword => checkPassword ??
                    (checkPassword = new RelayCommand(obj =>
                    {
                        string inputPassword = ((PasswordBox)obj).Password;
                        dialogResult = inputPassword == password;
                        if (dialogResult == false)
                            window.Close();

                    }));

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
