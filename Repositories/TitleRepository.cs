using ImdbProject.Models;
using ImdbProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImdbProject.Repositories
{
    public class TitleRepository : Repository<Title>, ITitleRepository
    {
        public TitleRepository(ImdbContext context) : base(context)
        {
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

        public async Task<List<Title>> GetTvSeries()
        {
            return await _dbSet
                .Where(t => t.TitleType == "tvSeries")
                .Where(t => t.StartYear >= 2000)
                 .Include(t => t.EpisodeParentTitles)
                    .Where(t => t.EpisodeParentTitles.Count != 0)
                .ToListAsync();
        }
    }
}
