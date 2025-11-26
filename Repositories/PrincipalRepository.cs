using ImdbProject.Models;
using ImdbProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImdbProject.Repositories
{
    public class PrincipalRepository : Repository<Principal>, IPrincipalRepository
    {
        public PrincipalRepository(ImdbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Principal>> GetAllAsync()
        {
            return await _dbSet
                .Include(p => p.Name)
                .ToListAsync();
        }

        public override async Task<Principal?> GetByIdAsync(object id)
        {
            // Principal has composite key (TitleId, Ordering)
            // For simple GetById, just include navigation
            return await _dbSet
                .Include(p => p.Name)
                .FirstOrDefaultAsync();
        }

        public async Task<Principal?> GetPrincipalAsync(string titleId, int ordering)
        {
            return await _dbSet
                .Include(p => p.Name)
                .FirstOrDefaultAsync(p => p.TitleId == titleId && p.Ordering == ordering);
        }

        public async Task<IEnumerable<Principal>> GetByTitleIdAsync(string titleId)
        {
            return await _dbSet
                .Include(p => p.Name)
                .Where(p => p.TitleId == titleId)
                .ToListAsync();
        }
    }
}
