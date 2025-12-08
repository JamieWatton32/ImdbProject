using ImdbProject.Data;
using ImdbProject.Models;
using ImdbProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImdbProject.Repositories
{
    public class TitleAliasRepository : Repository<TitleAlias>, ITitleAliasRepository
    {
        public TitleAliasRepository(ImdbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<TitleAlias>> GetAllAsync()
        {
            return await _dbSet
                .Include(ta => ta.TitleNavigation)
                .ToListAsync();
        }

        public override async Task<TitleAlias?> GetByIdAsync(object id)
        {
            // TitleAlias has composite key (TitleId, Ordering)
            return await _dbSet
                .Include(ta => ta.TitleNavigation)
                .FirstOrDefaultAsync();
        }

        public async Task<TitleAlias?> GetTitleAliasAsync(string titleId, int ordering)
        {
            return await _dbSet
                .Include(ta => ta.TitleNavigation)
                .FirstOrDefaultAsync(ta => ta.TitleId == titleId && ta.Ordering == ordering);
        }

        public async Task<IEnumerable<TitleAlias>> GetByTitleIdAsync(string titleId)
        {
            return await _dbSet
                .Include(ta => ta.TitleNavigation)
                .Where(ta => ta.TitleId == titleId)
                .ToListAsync();
        }
    }
}
