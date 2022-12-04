using ShikimoriApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShikimoriApp.ViewModels
{
    internal class AnimeWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private ShikimoriContext context = new ShikimoriContext();
        private AnimeInfo? animeInfo;

        public AnimeInfo? AnimeInfo { get => animeInfo; }

        public AnimeWindowViewModel(int animeId)
        {
            animeInfo = context.GetAnime(animeId);
        }
    }
}
