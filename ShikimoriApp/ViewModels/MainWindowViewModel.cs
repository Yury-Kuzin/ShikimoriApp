using ShikimoriApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShikimoriApp.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private ShikimoriContext context = new ShikimoriContext();
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Anime>? Animes { get; set; }

        public MainWindowViewModel()
        {
            Animes = new ObservableCollection<Anime>(context.GetAnimes());
        }



        private RelayCommand getAnimeCommand;
        public RelayCommand GetAnimeCommand
        {
            get
            {
                return getAnimeCommand ??
                    (getAnimeCommand = new RelayCommand(obj =>
                    {
                        context.GetAnime(Convert.ToInt32(obj));
                        var o = obj;
                    }));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
