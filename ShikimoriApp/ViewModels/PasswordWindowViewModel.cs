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
        public event PropertyChangedEventHandler? PropertyChanged;
        public PasswordWindowViewModel(Window window)
        {
            this.window = window;
            password = "123456";
        }

        private bool dialogResult;
        public bool DialogResult
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

        private string errorText;
        public string ErrorText
        {
            get { return errorText; }
            set
            {
                errorText = value;
                OnPropertyChanged("ErrorText");
            }
        }

        private RelayCommand? checkPassword;
        public RelayCommand CheckPassword => checkPassword ??
                    (checkPassword = new RelayCommand(obj =>
                    {
                        string inputPassword = ((PasswordBox)obj).Password;
                        DialogResult = inputPassword == password;
                        this.window.DialogResult = DialogResult;
                        if (DialogResult)
                            ErrorText = "";
                        else
                            ErrorText = "Пароль введён неверно!";
                        if (DialogResult)
                            window.Close();

                    }));

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
