using ImdbProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImdbProject.Repositories
{
    public class TitleRepository : Repository<Title>
    {
        public TitleRepository(ImdbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Title>> GetAllAsync()
        {
            return await _dbSet
                .Include(t => t.Genres)
                .Include(t => t.Rating)
                .Include(t => t.EpisodeTitle)
                .ToListAsync();
        }

        public override async Task<Title?> GetByIdAsync(object id)
        {
            return await _dbSet
                .Include(t => t.Genres)
                .Include(t => t.Rating)
                .Include(t => t.EpisodeTitle)
                .Include(t => t.EpisodeParentTitles)
                .FirstOrDefaultAsync(t => t.TitleId == (string)id);
        }

        public async Task<Title?> GetTitleWithDetailsAsync(string titleId)
        {
            return await _dbSet
                .Include(t => t.Genres)
                .Include(t => t.Rating)
                .Include(t => t.EpisodeTitle)
                .Include(t => t.EpisodeParentTitles)
                .Include(t => t.TitleAliases)
                .Include(t => t.Names)        // Directors
                .Include(t => t.Names1)       // Writers
                .Include(t => t.NamesNavigation)  // Known for
                .FirstOrDefaultAsync(t => t.TitleId == titleId);
        }
    }
}
        