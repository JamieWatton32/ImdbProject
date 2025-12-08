using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ImdbProject.ViewModels {
    public class SettingsViewModel : INotifyPropertyChanged {
        private bool _notificationsEnabled = true;
        private bool _soundEnabled = false;
        private int _selectedTheme = 0;
        private double _fontSize = 12;
        private int _clickCounter = 0;
        private string _cacheStatus = "Cache is active";
        private string _exportStatus = "Ready to export";
        private string _resetStatus = "Settings active";

        public bool NotificationsEnabled {
            get => _notificationsEnabled;
            set {
                _notificationsEnabled = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NotificationStatus));
            }
        }

        public string NotificationStatus => NotificationsEnabled ? "Notifications are ON" : "Notifications are OFF";

        public bool SoundEnabled {
            get => _soundEnabled;
            set {
                _soundEnabled = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SoundStatus));
            }
        }

        public string SoundStatus => SoundEnabled ? "Sound alerts enabled" : "Sound alerts disabled";

        public int SelectedTheme {
            get => _selectedTheme;
            set {
                _selectedTheme = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ThemeStatus));
            }
        }

        public string ThemeStatus {
            get {
                return SelectedTheme switch {
                    0 => "Light theme selected",
                    1 => "Dark theme selected",
                    2 => "Auto theme selected",
                    _ => "Unknown theme"
                };
            }
        }

        public double FontSize {
            get => _fontSize;
            set {
                _fontSize = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FontSizeStatus));
            }
        }

        public string FontSizeStatus => $"Font size: {FontSize:F0}pt";

        public string CacheStatus {
            get => _cacheStatus;
            set {
                _cacheStatus = value;
                OnPropertyChanged();
            }
        }

        public string ExportStatus {
            get => _exportStatus;
            set {
                _exportStatus = value;
                OnPropertyChanged();
            }
        }

        public string ResetStatus {
            get => _resetStatus;
            set {
                _resetStatus = value;
                OnPropertyChanged();
            }
        }

        public int ClickCounter {
            get => _clickCounter;
            set {
                _clickCounter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ClickCounterText));
            }
        }

        public string ClickCounterText => $"Clicked {ClickCounter} time{(ClickCounter != 1 ? "s" : "")}";

        public ICommand ClearCacheCommand { get; }
        public ICommand ExportDataCommand { get; }
        public ICommand ResetCommand { get; }
        public ICommand IncrementCounterCommand { get; }

        public SettingsViewModel() {
            ClearCacheCommand = new RelayCommand(ClearCache);
            ExportDataCommand = new RelayCommand(ExportData);
            ResetCommand = new RelayCommand(ResetSettings);
            IncrementCounterCommand = new RelayCommand(IncrementCounter);
        }

        private void ClearCache() {
            CacheStatus = "Cache cleared!";
        }

        private void ExportData() {
            ExportStatus = "Data exported successfully!";
        }

        private void ResetSettings() {
            ResetStatus = "Settings reset to defaults!";
            NotificationsEnabled = true;
            SoundEnabled = false;
            SelectedTheme = 0;
            FontSize = 12;
        }

        private void IncrementCounter() {
            ClickCounter++;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand {
        private readonly Action _execute;

        public RelayCommand(Action execute) {
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _execute();
    }
}
