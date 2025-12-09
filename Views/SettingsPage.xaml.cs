using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ImdbProject.Views {
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// Have some dumb fun.
    /// </summary>
    public partial class SettingsPage : Page {
        private int clickCount = 0;
        private int mysteryCount = 0;
        private int totalInteractions = 0;
        private int sessionSeconds = 0;
        private DispatcherTimer sessionTimer;
        private DispatcherTimer loadingTimer;
        private int loadingProgress = 0;

        private string[] brewStatuses = new[]
        {
            "Perfectly chilled ❄️",
            "Still brewing... patience required",
            "Ready to drink! 🎉",
            "Temperature optimal",
            "Needs more time...",
            "Brewing complete!",
            "Critical: Too cold!",
            "Warning: Lukewarm detected",
            "Excellent condition ⭐"
        };

        private string[] fortunes = new[]
        {
            "A bug you create today will haunt you next week.",
            "You will soon discover a semicolon in an unexpected place.",
            "Stack Overflow will have exactly what you need... almost.",
            "Your code will compile on the first try! (Just kidding)",
            "A merge conflict approaches. Prepare yourself.",
            "Great success awaits... after you fix that null reference.",
            "You will soon understand why that variable was named 'temp2'.",
            "The documentation you seek does not exist yet.",
            "Your next commit message will be 'fixed stuff'.",
            "A wild NullReferenceException appears!"
        };

        private string[] mysteryMessages = new[]
        {
            "Nothing happened... or did it?",
            "You discovered a secret!",
            "Achievement unlocked: Curious Clicker",
            "The mystery deepens...",
            "ERROR: Success!",
            "This button is self-aware now.",
            "You shouldn't have done that...",
            "Congratulations! You found nothing.",
            "The cake is a lie.",
            "Have you tried turning it off and on again?"
        };

        public SettingsPage() {
            InitializeComponent();

            // Start session timer
            sessionTimer = new DispatcherTimer();
            sessionTimer.Interval = TimeSpan.FromSeconds(1);
            sessionTimer.Tick += SessionTimer_Tick;
            sessionTimer.Start();
        }

        private void SessionTimer_Tick(object sender, EventArgs e) {
            sessionSeconds++;
            SessionTimeText.Text = $"Time in settings: {sessionSeconds} seconds";
        }

        private void IncrementTotalInteractions() {
            totalInteractions++;
            TotalClicksText.Text = $"Total interactions: {totalInteractions}";
        }

        private void ClickButton_Click(object sender, RoutedEventArgs e) {
            clickCount++;
            ClickCountText.Text = $"Clicked {clickCount} time{(clickCount != 1 ? "s" : "")}";
            IncrementTotalInteractions();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e) {
            clickCount = 0;
            ClickCountText.Text = "Clicked 0 times";
            ResetStatusText.Text = "Counter has been reset!";
            IncrementTotalInteractions();
        }

        private void CheckBrewButton_Click(object sender, RoutedEventArgs e) {
            var random = new Random();
            var status = brewStatuses[random.Next(brewStatuses.Length)];
            var temp = random.Next(35, 45); // Fahrenheit

            BrewStatusText.Text = status;
            BrewTempText.Text = $"Current temperature: {temp}°F ({(temp - 32) * 5 / 9}°C)";
            IncrementTotalInteractions();
        }

        private void DarkModeCheck_Changed(object sender, RoutedEventArgs e) {
            DarkModeStatus.Text = DarkModeCheck.IsChecked == true
                ? "Dark mode active 🌙"
                : "Light mode active ☀️";
            IncrementTotalInteractions();
        }

        private void CatModeCheck_Changed(object sender, RoutedEventArgs e) {
            CatModeStatus.Text = CatModeCheck.IsChecked == true
                ? "Cat mode enabled! 😺😸😻"
                : "Cat mode disabled 😢";
            IncrementTotalInteractions();
        }

        private void TurboCheck_Changed(object sender, RoutedEventArgs e) {
            TurboStatus.Text = TurboCheck.IsChecked == true
                ? "⚡ TURBO MODE ENGAGED ⚡ (200% speed)"
                : "Running at normal speed";
            IncrementTotalInteractions();
        }

        private void MysteryButton_Click(object sender, RoutedEventArgs e) {
            mysteryCount++;
            var random = new Random();
            var message = mysteryMessages[random.Next(mysteryMessages.Length)];

            MysteryText.Text = message;
            MysteryCounter.Text = $"Mystery button pressed {mysteryCount} time{(mysteryCount != 1 ? "s" : "")}";
            IncrementTotalInteractions();
        }

        private void FortuneButton_Click(object sender, RoutedEventArgs e) {
            var random = new Random();
            var fortune = fortunes[random.Next(fortunes.Length)];

            FortuneText.Text = $"🔮 {fortune}";
            IncrementTotalInteractions();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e) {
            if (loadingTimer != null && loadingTimer.IsEnabled) {
                // Already loading
                return;
            }

            loadingProgress = 0;
            LoadProgress.Value = 0;
            LoadStatusText.Text = "Loading...";
            LoadButton.IsEnabled = false;

            loadingTimer = new DispatcherTimer();
            loadingTimer.Interval = TimeSpan.FromMilliseconds(50);
            loadingTimer.Tick += LoadingTimer_Tick;
            loadingTimer.Start();
            IncrementTotalInteractions();
        }

        private void LoadingTimer_Tick(object sender, EventArgs e) {
            loadingProgress += 2;
            LoadProgress.Value = loadingProgress;

            if (loadingProgress >= 100) {
                loadingTimer.Stop();
                LoadStatusText.Text = "Loading complete! ✓";
                LoadButton.IsEnabled = true;
            }
            else if (loadingProgress == 50) {
                LoadStatusText.Text = "Loading... halfway there!";
            }
            else if (loadingProgress > 80) {
                LoadStatusText.Text = "Loading... almost done!";
            }
        }
    }
}
