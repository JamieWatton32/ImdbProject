using ImdbProject.Models;
using ImdbProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImdbProject.Repositories
{
    public class EpisodeRepository : Repository<Episode>, IEpisodeRepository
    {
        public EpisodeRepository(ImdbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Episode>> GetAllAsync()
        {
            return await _dbSet
                .Include(e => e.Title)
                .Include(e => e.ParentTitle)
                .ToListAsync();
        }

        public override async Task<Episode?> GetByIdAsync(object id)
        {
            return await _dbSet
                .Include(e => e.Title)
                .Include(e => e.ParentTitle)
                .FirstOrDefaultAsync(e => e.TitleId == (string)id);
        }

        public async Task<Episode?> GetEpisodeWithDetailsAsync(string titleId)
        {
            return await _dbSet
                .Include(e => e.Title)
                .Include(e => e.ParentTitle)
                .FirstOrDefaultAsync(e => e.TitleId == titleId);
        }
    }
}