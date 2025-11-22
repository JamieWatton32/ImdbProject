using CommunityToolkit.Mvvm.ComponentModel;
using ImdbProject.Models;

namespace ImdbProject.ViewModels
{
    /// <summary>
    /// ViewModel for a single Principal entity (cast and crew roles)
    /// </summary>
    public partial class PrincipalViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _titleId = null!;

        [ObservableProperty]
        private int _ordering;

        [ObservableProperty]
        private string? _nameId;

        [ObservableProperty]
        private string? _jobCategory;

        [ObservableProperty]
        private string? _job;

        [ObservableProperty]
        private string? _characters;

        // Navigation property
        [ObservableProperty]
        private Name? _name;

        public static PrincipalViewModel FromModel(Principal principal)
        {
            return new PrincipalViewModel
            {
                TitleId = principal.TitleId,
                Ordering = principal.Ordering,
                NameId = principal.NameId,
                JobCategory = principal.JobCategory,
                Job = principal.Job,
                Characters = principal.Characters,
                Name = principal.Name
            };
        }
    }
}
