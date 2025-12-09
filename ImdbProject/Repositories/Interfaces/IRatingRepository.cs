using ImdbProject.Models;

namespace ImdbProject.Repositories.Interfaces
{
    public interface IRatingRepository : IRepository<Rating>
    {
        public Task<Rating?> GetRatingAsync(string titleId);
    }
}
