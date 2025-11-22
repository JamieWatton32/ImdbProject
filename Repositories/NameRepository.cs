using ImdbProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImdbProject.Repositories
{
    public class NameRepository(ImdbContext context) : Repository<Name>(context)
    {
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
