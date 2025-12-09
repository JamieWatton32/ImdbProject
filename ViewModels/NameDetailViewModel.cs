using CommunityToolkit.Mvvm.ComponentModel;
using ImdbProject.Services.Interfaces;

namespace ImdbProject.ViewModels
{
    public partial class NameDetailViewModel : ObservableObject
    {
        private readonly INameService _nameService;

        [ObservableProperty]
        private NameViewModel? _selectedName;

        public NameDetailViewModel(INameService nameService)
        {
            _nameService = nameService;
        }

        public async Task LoadNameDetailsAsync(string nameId)
        {
            var name = await _nameService.GetNameAsync(nameId);
            if (name != null)
            {
                SelectedName = NameViewModel.FromModel(name);
            }
        }
    }
}
