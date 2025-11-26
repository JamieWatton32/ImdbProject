using CommunityToolkit.Mvvm.ComponentModel;
using ImdbProject.Models;
using ImdbProject.Services.Episodes;
using ImdbProject.Services.Principals;
using ImdbProject.Services.Ratings;
using ImdbProject.Services.TitleAliases;
using ImdbProject.Services.Titles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImdbProject.ViewModels
{
    public partial class TitleDetailsViewModel : ObservableObject
    {
        private readonly MainViewModel _mainViewModel;

        [ObservableProperty]
        private TitleViewModel? _selectedTitle;

        public TitleDetailsViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public async Task LoadTitleDetailsAsync(string titleId)
        {
            var title = _mainViewModel.Titles.FirstOrDefault(t => t.TitleId == titleId);
            if (title != null)
            {
                SelectedTitle = title;
            }
        }
    }
}
