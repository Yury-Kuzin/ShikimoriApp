using ShikimoriApp.Models;
using ShikimoriApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static ShikimoriApp.ShikimoriContext;

namespace ShikimoriApp.ViewModels
{
    class MyAnimeListWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private ShikimoriContext context = new ShikimoriContext();

        private RelayCommand radioSelectedChanged;
        public RelayCommand RadioSelectedChanged
        {
            get
            {
                return radioSelectedChanged ??
                    (radioSelectedChanged = new RelayCommand(obj =>
                    {
                        animes.Clear();
                        Animes = new ObservableCollection<Anime>(context.GetPersonalList((ListStatus)Convert.ToInt32(obj)));
                    }));
            }
        }

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

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public MyAnimeListWindowViewModel()
        {
            animes = new ObservableCollection<Anime>(context.GetPersonalList(ShikimoriContext.ListStatus.Planned));
        }
    }
}
