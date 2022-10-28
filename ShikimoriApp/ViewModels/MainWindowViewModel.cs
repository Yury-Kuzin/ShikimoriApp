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
        private ObservableCollection<Anime>? animes;
        public ObservableCollection<Anime>? Animes
        {
            get => animes;
            set
            {
                animes = value;
                OnPropertyChanged();
            }
        }
        private Anime anime_;
        public Anime Anime
        {
            get => anime_;
            set
            {
                anime_ = value;
                OnPropertyChanged();
            }
        }

        private string? searchText;
        public string? SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        public MainWindowViewModel()
        {
            animes = new ObservableCollection<Anime>(context.GetAnimes());
        }

        private RelayCommand? getAnimesCommand;
        public RelayCommand GetAnimesCommand
        {
            get
            {
                return getAnimesCommand ??
                    (getAnimesCommand = new RelayCommand(obj =>
                    {
                        ShikimoriContext db = new ShikimoriContext();
                        animes.Clear();
                        animes = new ObservableCollection<Anime>(context.GetAnimes(1, searchText));
                        Update();
                    }));
            }
        }

        private RelayCommand? getAnimeCommand;
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
        public void Update()
        {
            ShikimoriContext db = new ShikimoriContext();
            Animes = new ObservableCollection<Anime>(db.GetAnimes(1, searchText));
        }
    }
}
