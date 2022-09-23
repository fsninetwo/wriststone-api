using System.Collections.Generic;
using System.Threading.Tasks;
using Wriststone.Data.Entities.Entities;
using Wriststone.Wriststone.Data.Models;

namespace Wriststone.Wriststone.Data.IRepositories
{
    public interface IRatingRepository
    {
        Task AddRatingAsync(Rating newRate);

        Task UpdateRatingAsync(Rating updatedRate);

        Task<Rating> GetRatingAsync(long rateId, bool asNoTracking = true);

        Task<List<RatingDTO>> GetRatingsAsync(long productId, bool asNoTracking = true);

        Task DeleteRatingAsync(long rateId);
    }
}
