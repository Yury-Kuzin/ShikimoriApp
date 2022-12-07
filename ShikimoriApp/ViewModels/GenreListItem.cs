using ShikimoriApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShikimoriApp.ViewModels
{
    class GenreListItem : INotifyPropertyChanged
    {
        private bool selected;
        private Genre genre;

        public GenreListItem(Genre genre, bool selected)
        {
            this.genre = genre;
            this.selected = selected;
        }

        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }
        public Genre Genre
        {
            get { return genre; }
            set
            {
                genre = value;
                OnPropertyChanged("Genre");
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
