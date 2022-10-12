using System.Collections.Generic;
using System.Threading.Tasks;
using Wriststone.Wriststone.Data.Models;

namespace Wriststone.Wriststone.Services.IServices
{
    public interface IRatingService
    {
        Task AddRatingAsync(RatingCreateDTO rating);

        Task UpdateRatingAsync(RatingUpdateDTO rating);

        Task<RatingDTO> GetRatingAsync(long ratingId);

        Task<List<RatingDTO>> GetRatingsAsync(long productId);

        Task DeleteRatingAsync(long ratingId);
    }
}
