using ImdbProject.Data;
using ImdbProject.Models;
using ImdbProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImdbProject.Repositories
{
    public class NameRepository : Repository<Name>, INameRepository
    {
        public NameRepository(ImdbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Name>> GetAllAsync()
        {
            return await _dbSet
                .Include(n => n.Principals)
                .ToListAsync();
        }

        public override async Task<Name?> GetByIdAsync(object id)
        {
            return await _dbSet
                .Include(n => n.Principals)
                .Include(n => n.Titles)        // Directors
                .Include(n => n.Titles1)       // Writers
                .Include(n => n.TitlesNavigation)  // Known for
                .FirstOrDefaultAsync(n => n.NameId == (string)id);
        }

        public async Task<Name?> GetNameWithDetailsAsync(string nameId)
        {
            return await _dbSet
                .Include(n => n.Principals)
                .Include(n => n.Titles)        // Directors
                .Include(n => n.Titles1)       // Writers
                .Include(n => n.TitlesNavigation)  // Known for
                .FirstOrDefaultAsync(n => n.NameId == nameId);
        }
    }
}
