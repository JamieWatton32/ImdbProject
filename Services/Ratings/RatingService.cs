using ImdbProject.Models;
using ImdbProject.Repositories.Interfaces;
using ImdbProject.Services.Interfaces;

namespace ImdbProject.Services.Ratings
{
    public class RatingService : BaseService<Rating>, IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository repository) : base(repository)
        {
            _ratingRepository = repository;
        }

        public async Task<Rating?> GetRatingAsync(string titleId)
        {
            return await _ratingRepository.GetRatingAsync(titleId);
        }
    }
}
