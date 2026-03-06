using CommunityToolkit.Mvvm.ComponentModel;
using MigraineTracker.Models;
using MigraineTracker.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MigraineTracker.ViewModels
{
    public partial class HistoryViewModel : ObservableObject
    {
        private DatabaseServices _db;
        public HistoryViewModel(DatabaseServices db)
        {
            _db = db;
        }

        public ObservableCollection<Migraine> Migraines { get; } = new ObservableCollection<Migraine>();

        public void LoadData()
        {
            Migraines.Clear();

            List<Migraine> tab = _db.All();

            foreach (var migraine in tab)
            {
                Migraines.Add(migraine);
            }
        }
    }
}