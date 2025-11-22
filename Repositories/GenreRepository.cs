using ImdbProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImdbProject.Repositories
{
    public class GenreRepository(ImdbContext context) : Repository<Genre>(context)
    {
        public override async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _dbSet
                .Include(g => g.Titles)
                .ToListAsync();
        }

        public override async Task<Genre?> GetByIdAsync(object id)
        {
            return await _dbSet
                .Include(g => g.Titles)
                .FirstOrDefaultAsync(g => g.GenreId == (int)id);
        }
    }
}