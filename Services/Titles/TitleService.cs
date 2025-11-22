using ImdbProject.Models;
using ImdbProject.Repositories;
using System.Threading.Tasks;

namespace ImdbProject.Services.Titles
{
    public class TitleService : BaseService<Title>
    {
        private readonly TitleRepository _titleRepository;

        public TitleService(TitleRepository repository) : base(repository)
        {
            _titleRepository = repository;
        }

        public async Task<Title?> GetTitleAsync(string titleId)
        {
            return await _titleRepository.GetTitleWithDetailsAsync(titleId);
        }
    }
}   