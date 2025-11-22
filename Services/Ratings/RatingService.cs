using ImdbProject.Models;
using ImdbProject.Repositories;
using System.Threading.Tasks;

namespace ImdbProject.Services.Ratings
{
    public class RatingService : BaseService<Rating>
    {
        private readonly RatingRepository _ratingRepository;

        public RatingService(RatingRepository repository) : base(repository)
        {
            _ratingRepository = repository;
        }

        public async Task<Rating?> GetRatingAsync(string titleId)
        {
            return await _ratingRepository.GetRatingAsync(titleId);
        }
    }
}
