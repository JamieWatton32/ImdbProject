using ImdbProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImdbProject.Repositories
{
    public class RatingRepository : Repository<Rating>
    {
        public RatingRepository(ImdbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Rating>> GetAllAsync()
        {
            return await _dbSet
                .Include(r => r.Title)
                .ToListAsync();
        }

        public override async Task<Rating?> GetByIdAsync(object id)
        {
            return await _dbSet
                .Include(r => r.Title)
                .FirstOrDefaultAsync(r => r.TitleId == (string)id);
        }

        public async Task<Rating?> GetRatingAsync(string titleId)
        {
            return await _dbSet
                .Include(r => r.Title)
                .FirstOrDefaultAsync(r => r.TitleId == titleId);
        }
    }
}
