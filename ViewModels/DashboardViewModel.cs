using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MigraineTracker.Models;
using MigraineTracker.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace MigraineTracker.ViewModels
{
    public partial class DashboardViewModel : ObservableObject
    {
        private DatabaseServices _db;
        public DashboardViewModel(DatabaseServices db) 
        { 
            _db = db;
        }

        [ObservableProperty]
        private int _total;

        [ObservableProperty]
        private int _thisMonth;

        [ObservableProperty]
        private double _averageIntensity;

        public ObservableCollection<Migraine> Migraines { get; } = new ObservableCollection<Migraine>();

        public void LoadData()
        {
            Migraines.Clear();

            List<Migraine> tab = _db.All();

            foreach (var migraine in tab)
            {
                Migraines.Add(migraine);
            }

            Total = Migraines.Count;

            ThisMonth = Migraines.Count(m => m.StartTime.Month == DateTime.Now.Month && m.StartTime.Year == DateTime.Now.Year);

            if (Migraines.Count > 0)
            {
                AverageIntensity = Migraines.Average(m => m.Intensity);

            }
        }

        [RelayCommand]
        private async Task GoToNewMigraine()
        {
            await Shell.Current.GoToAsync("NewMigraine");
        }

    }
}
