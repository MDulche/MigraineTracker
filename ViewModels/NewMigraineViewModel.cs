using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MigraineTracker.Models;
using MigraineTracker.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MigraineTracker.ViewModels
{
    public partial class NewMigraineViewModel : ObservableObject
    {
        private readonly DatabaseServices _db;

        public NewMigraineViewModel(DatabaseServices db)
        {
            _db = db;
        }

        [RelayCommand]
        private async Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task Save()
        {
            var migraine = new Migraine
            {
                StartTime = StartTime,
                EndTime = EndTime,
                Intensity = Intensity,
                CreatedAt = DateTime.Now,
                ProbableCause = ProbableCause,
                SymptomsBefore = SymptomsBefore,
                SymptomsDuring = SymptomsDuring,
                Notes = Notes,
            };

            _db.Add(migraine);
            await Shell.Current.GoToAsync("..");
        }


        [ObservableProperty]
        private DateTime _startTime = DateTime.Now;

        [ObservableProperty]
        private DateTime? _endTime;

        [ObservableProperty]
        private int _intensity = 5;

        [ObservableProperty]
        private string _probableCause = string.Empty;

        [ObservableProperty]
        private string _symptomsBefore = string.Empty;

        [ObservableProperty]
        private string _symptomsDuring = string.Empty;

        [ObservableProperty]
        private string _notes = string.Empty;
    }
}
