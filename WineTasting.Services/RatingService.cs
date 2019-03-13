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

        public IEnumerable<RatingListItem> GetRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Ratings
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new RatingListItem
                    {
                        RatingId = e.RatingId,
                        GuestRating = e.GuestRating,
                        Comments = e.Comments
                    }
                    );
                return query.ToArray();
            }
        }

        public RatingDetail GetRatingById(int ratingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings
                    .Single(e => e.RatingId == ratingId && e.OwnerId == _userId);
                return new RatingDetail
                {
                    RatingId = entity.RatingId,
                    GuestRating = entity.GuestRating,
                    Comments = entity.Comments,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }

        public bool UpdateRating(RatingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings
                    .Single(e => e.RatingId == model.RatingId && e.OwnerId == _userId);

                entity.GuestRating = model.GuestRating;
                entity.Comments = model.Comments;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;                 
            }

        }

        public bool DeleteRating(int ratingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings
                    .Single(e => e.RatingId == ratingId && e.OwnerId == _userId);

                ctx.Ratings.Remove(entity);

                return ctx.SaveChanges() == 1;

            }
        }


    }
}
