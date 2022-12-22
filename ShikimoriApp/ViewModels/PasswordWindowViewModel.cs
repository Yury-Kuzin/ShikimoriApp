using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace ShikimoriApp.ViewModels
{
    class PasswordWindowViewModel : INotifyPropertyChanged
    {
        private Window window;
        public event PropertyChangedEventHandler? PropertyChanged;
        public PasswordWindowViewModel(Window window)
        {
            this.window = window;
            this.window.Closing += Window_Closing;
            DialogResult = false;
        }

        private void Window_Closing(object? sender, CancelEventArgs e)
        {
            this.window.DialogResult = DialogResult;
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
                        string pwd = Properties.Settings.Default.Password;
                        DialogResult = inputPassword == pwd;

                        if (DialogResult)
                        {
                            this.window.DialogResult = DialogResult;
                            ErrorText = "";
                            window.Close();
                        }
                        else
                            ErrorText = "Пароль введён неверно!";

                    }));

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
