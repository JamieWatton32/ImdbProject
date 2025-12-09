using ImdbProject.Models;
using ImdbProject.Repositories.Interfaces;
using ImdbProject.Services.Interfaces;

namespace ImdbProject.Services.TitleAliases
{
    public class TitleAliasService : BaseService<TitleAlias>, ITitleAliasService
    {
        private readonly ITitleAliasRepository _titleAliasRepository;

        public TitleAliasService(ITitleAliasRepository repository) : base(repository)
        {
            _titleAliasRepository = repository;
        }

        public async Task<TitleAlias?> GetTitleAliasAsync(string titleId, int ordering)
        {
            return await _titleAliasRepository.GetTitleAliasAsync(titleId, ordering);
        }

        public async Task<IEnumerable<TitleAlias>> GetByTitleIdAsync(string titleId)
        {
            return await _titleAliasRepository.GetByTitleIdAsync(titleId);
        }
    }
}
