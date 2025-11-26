using ImdbProject.Models;
using ImdbProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ImdbProject.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(ImdbContext context) : base(context)
        {
        }

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

        public async Task<Genre?> GetGenreAsync(int genreId)
        {
            return await _dbSet
                .Include(g => g.Titles)
                .FirstOrDefaultAsync(g => g.GenreId == genreId);
        }

        public async Task<Genre?> GetGenreByNameAsync(string name)
        {
            return await _dbSet
                .Include(g => g.Titles)
                .FirstOrDefaultAsync(g => g.Name == name);
        }
    }
}