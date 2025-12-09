using ImdbProject.Models;

namespace ImdbProject.Services.Interfaces
{
    public interface IRatingService : IBaseService<Rating>
    {
        Task<Rating?> GetRatingAsync(string titleId);
    }
}