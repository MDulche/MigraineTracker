using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MigraineTracker.Models;
using MigraineTracker.Services;
using System.Collections.ObjectModel;
using System.Globalization;

namespace MigraineTracker.ViewModels
{
    public partial class CalendarViewModel : ObservableObject
    {
        private DatabaseServices _db;

        public CalendarViewModel(DatabaseServices db)
        {
            _db = db;
            _month = DateTime.Today.Month;
            _year = DateTime.Today.Year;
        }

        [ObservableProperty] private int _month;
        [ObservableProperty] private int _year;
        [ObservableProperty] private int _selectedDay;

        public string MonthTitle => new DateTime(Year, Month, 1)
            .ToString("MMMM yyyy", CultureInfo.GetCultureInfo("fr-FR"));

        partial void OnMonthChanged(int value)
        {
            OnPropertyChanged(nameof(MonthTitle));
        }

        partial void OnYearChanged(int value)
        {
            OnPropertyChanged(nameof(MonthTitle));
        }

        public ObservableCollection<CalendarDayViewModel> Days { get; } = new();
        public ObservableCollection<Migraine> SelectedDayMigraines { get; } = new();

        public void LoadData()
        {
            SelectedDayMigraines.Clear();

            var tab = _db.All();
            var monthMigraines = tab.Where(m => m.StartTime.Month == Month && m.StartTime.Year == Year).ToList();

            Days.Clear();
            int firstDay = (((int)new DateTime(Year, Month, 1).DayOfWeek) + 6) % 7;
            int daysInMonth = DateTime.DaysInMonth(Year, Month);

            for (int i = 0; i < firstDay; i++)
                Days.Add(new CalendarDayViewModel { Day = 0 });

            for (int d = 1; d <= daysInMonth; d++)
            {
                var dayMigraines = monthMigraines.Where(m => m.StartTime.Day == d).ToList();
                bool hasMigraine = dayMigraines.Count > 0;
                int maxIntensity = hasMigraine ? dayMigraines.Max(m => m.Intensity) : 0;

                Color dotColor = !hasMigraine ? Colors.Transparent
                    : maxIntensity <= 3 ? Color.FromArgb("#34D399")
                    : maxIntensity <= 6 ? Color.FromArgb("#FBBF24")
                    : Color.FromArgb("#F87171");

                Days.Add(new CalendarDayViewModel
                {
                    Day = d,
                    HasMigraine = hasMigraine,
                    DotColor = dotColor,
                    IsToday = d == DateTime.Today.Day && Month == DateTime.Today.Month && Year == DateTime.Today.Year,
                    IsSelected = d == SelectedDay
                });
            }

            if (SelectedDay > 0)
            {
                var selected = monthMigraines.Where(m => m.StartTime.Day == SelectedDay).ToList();
                foreach (var m in selected)
                    SelectedDayMigraines.Add(m);
            }
        }

        [RelayCommand]
        private void PreviousMonth()
        {
            if (Month == 1) { Month = 12; Year--; }
            else Month--;
            SelectedDay = 0;
            LoadData();
        }

        [RelayCommand]
        private void NextMonth()
        {
            if (Month == 12) { Month = 1; Year++; }
            else Month++;
            SelectedDay = 0;
            LoadData();
        }

        [RelayCommand]
        private void SelectDay(int day)
        {
            // Désélectionner l'ancien
            var old = Days.FirstOrDefault(d => d.IsSelected);
            if (old != null) old.IsSelected = false;

            // Sélectionner le nouveau
            SelectedDay = day;
            var cell = Days.FirstOrDefault(d => d.Day == day);
            if (cell != null) cell.IsSelected = true;

            // Rafraîchir les migraines du jour
            SelectedDayMigraines.Clear();
            var tab = _db.All();
            var dayMigraines = tab.Where(m => m.StartTime.Month == Month && m.StartTime.Year == Year && m.StartTime.Day == day).ToList();
            foreach (var m in dayMigraines)
                SelectedDayMigraines.Add(m);
        }

        

    }

    public partial class CalendarDayViewModel : ObservableObject
    {
        [ObservableProperty] private int _day;
        [ObservableProperty] private bool _hasMigraine;
        [ObservableProperty] private Color _dotColor = Colors.Transparent;
        [ObservableProperty] private bool _isToday;
        [ObservableProperty] private bool _isSelected;
    }
}
