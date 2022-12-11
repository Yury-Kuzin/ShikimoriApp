using ShikimoriApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShikimoriApp.ViewModels
{
    class CalendarWindowViewModel : INotifyPropertyChanged
    {
        private ShikimoriContext context = new ShikimoriContext();
        private Dictionary<DateOnly, List<CalendarItem>>? items;
        public event PropertyChangedEventHandler? PropertyChanged;
        public Dictionary<DateOnly, List<CalendarItem>>? Items { get => items; }
        public CalendarWindowViewModel()
        {
            items = context.GetCalendar();
        }

    }
}
