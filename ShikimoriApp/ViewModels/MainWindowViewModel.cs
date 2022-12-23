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

namespace ShikimoriApp.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private ShikimoriContext context = new ShikimoriContext();
        public event PropertyChangedEventHandler? PropertyChanged;
        public MainWindowViewModel()
        {
            animes = new ObservableCollection<Anime>(context.GetAnimes(page, searchText, isProhibitedContent));
            List<GenreListItem>? list = context.GetGenres().Select(o => new GenreListItem(o, false)).ToList();
            genres = new ObservableCollection<GenreListItem>(list);
            isProhibitedContent = false;
            ProhibitedText = "Родительский контроль!";
        }

        private ObservableCollection<GenreListItem>? genres;
        public ObservableCollection<GenreListItem>? Genres
        {
            get => genres;
            set
            {
                genres = value;
                OnPropertyChanged();
            }
        }
        private bool isProhibitedContent;
        public bool IsProhibitedContent
        {
            get => isProhibitedContent;
            set
            {
                isProhibitedContent = value;
                OnPropertyChanged("IsProhibitedContent");
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

        private int page = 1;
        public int Page
        {
            get { return page; }
            set
            {
                page = value;
                OnPropertyChanged("Page");
            }
        }


        private RelayCommand? nextPageCommand;
        public RelayCommand NextPageCommand
        {
            get
            {
                return nextPageCommand ??
                    (nextPageCommand = new RelayCommand(obj =>
                    {
                        if (Animes.Count == 50)
                            Update(++Page);
                    }));
            }
        }

        private RelayCommand? prevPageCommand;
        public RelayCommand PrevPageCommand
        {
            get
            {
                return prevPageCommand ??
                    (prevPageCommand = new RelayCommand(obj =>
                    {
                        if (Page > 1)
                            Update(--Page);
                    }));
            }
        }

        private RelayCommand? getAnimesCommand;
        public RelayCommand GetAnimesCommand
        {
            get
            {
                return getAnimesCommand ??
                    (getAnimesCommand = new RelayCommand(obj =>
                    {
                        Update();
                        Page = 1;
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
                        int id = Convert.ToInt32(obj);
                        AnimeWindow animeWindow = new AnimeWindow(id);
                        animeWindow.Show();
                    }));
            }
        }

        private RelayCommand? calendarOpen;
        public RelayCommand CalendarOpen
        {
            get
            {
                return calendarOpen ??
                    (calendarOpen = new RelayCommand(obj =>
                    {
                        CalendarWindow calendarWindow = new CalendarWindow();
                        calendarWindow.Show();
                    }));
            }
        }

        private string prohibitedText;
        public string ProhibitedText
        {
            get => prohibitedText;
            set
            {
                prohibitedText = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand? passwordEnter;
        public RelayCommand PasswordEnter
        {
            get
            {
                return passwordEnter ??
                    (passwordEnter = new RelayCommand(obj =>
                    {
                        PasswordWindow passwordWindow = new PasswordWindow();
                        if (passwordWindow.ShowDialog().Value)
                        {
                            IsProhibitedContent = !IsProhibitedContent;
                            if (!IsProhibitedContent)
                                ProhibitedText = "Родительский контроль!";
                            else
                                ProhibitedText = "";
                            Update();
                        }
                    }));
            }
        }

        private RelayCommand? animeListOpen;
        public RelayCommand AnimeListOpen
        {
            get
            {
                return animeListOpen ??
                    (animeListOpen = new RelayCommand(obj =>
                    {
                        MyAnimeListWindow myAnimeListWindow = new MyAnimeListWindow();
                        myAnimeListWindow.ShowDialog();
                    }));
            }
        }

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        public void Update(int page = 1)
        {
            animes.Clear();
            int[]? genres = Genres.Where(o => o.Selected).Select(s => s.Genre.Id).ToArray();
            Animes = new ObservableCollection<Anime>(context.GetAnimes(page, searchText, isProhibitedContent, genres));
        }
    }
}
