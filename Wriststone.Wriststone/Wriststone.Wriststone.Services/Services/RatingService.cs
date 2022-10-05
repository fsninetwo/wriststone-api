using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Wriststone.Common.Domain.Exceptions;
using Wriststone.Wriststone.Data.IRepositories;
using Wriststone.Wriststone.Data.Models;
using Wriststone.Wriststone.Services.Helpers;
using Wriststone.Wriststone.Services.IServices;

namespace Wriststone.Wriststone.Services.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public RatingService(IRatingRepository ratingRepository, IUserService userService, IMapper mapper)
        {
            _ratingRepository = ratingRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task AddRatingAsync(RatingCreateDTO rating)
        {
            var user = await _userService.GetUserAsync(1);

            var newRating = RatingHelper.ConvertRatingDTOtoRating(rating, user.Id);

            try
            {
                await _ratingRepository.AddRatingAsync(newRating);
            }
            catch (InternalException ex)
            {
                Console.WriteLine("Error, ", ex.Message);
            }       
        }

        public async Task<RatingDTO> GetRatingAsync(long ratingId)
        {
            var rating = await _ratingRepository.GetRatingAsync(ratingId);

            if (rating == null)
            {
                return null;
            }

            var ratingModel = _mapper.Map<RatingDTO>(rating);

            if (rating.UserId.HasValue)
            {
                var user = await _userService.GetUserAsync(rating.UserId.Value);

                ratingModel.UserName = user.Login; 
            }
            else
            {
                ratingModel.UserName = "Deleted";
            }

            return ratingModel;
        }

        public async Task<List<RatingDTO>> GetRatingsAsync(long productId)
        {
            var ratings = await _ratingRepository.GetRatingsAsync(productId);

            return ratings;
        }

        public async Task UpdateRatingAsync(RatingUpdateDTO rating)
        {
            var updateRating = RatingHelper.ConvertRatingDTOtoRating(rating);

            try
            {
                await _ratingRepository.UpdateRatingAsync(updateRating);
            }
            catch (InternalException ex)
            {
                Console.WriteLine("Error, " + ex.Message);
            }
        }

        public async Task DeleteRatingAsync(long ratingId)
        {
            try
            {
                await _ratingRepository.DeleteRatingAsync(ratingId);
            }
            catch (InternalException ex)
            {
                Console.WriteLine("Error, " + ex.Message);
            }
        }
    }
}
