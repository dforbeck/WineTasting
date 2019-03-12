using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;
using WineTasting.Models.Rating;

namespace WineTasting.Services
{
    public class RatingService
    {
        private readonly Guid _userId;

        public RatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRating(RatingCreate model)
        {
            var entity = new Rating()
            {
                OwnerId = _userId,
                GuestRating = model.GuestRating,
                Comments = model.Comments,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new  ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
