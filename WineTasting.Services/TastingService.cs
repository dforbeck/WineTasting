using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;
using WineTasting.Models.Tasting;

namespace WineTasting.Services
{
    public class TastingService
    {
        private readonly Guid _userId;

        public TastingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTasting(TastingCreate model)
        {
            var entity = new Tasting()
            {
                OwnerId = _userId,
                TastingId= model.TastingId,
                TastingDate = model.TastingDate,
                Title = model.Title,
                Host = model.Host,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tastings.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TastingListItem> GetTastings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Tastings
                    .Where(e => e.OwnerId == _userId)
                    .Select
                    (e => new TastingListItem
                    {
                        OwnerId = e.OwnerId,
                        TastingId = e.TastingId,
                        TastingDate = e.TastingDate,
                        Title = e.Title,
                        Host = e.Host,
                    }
                    );
                return query.ToArray();
            }
        }

        public TastingDetail GetTastingById(int tastingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tastings
                            .Single(e => e.TastingId == tastingId && e.OwnerId == _userId);

                return new TastingDetail
                {
                    OwnerId = entity.OwnerId,
                    TastingId = entity.TastingId,
                    TastingDate = entity.TastingDate,
                    Title = entity.Title,
                    Host = entity.Host,
                    CreatedUtc = entity.CreatedUtc, 
                    ModifiedUtc = entity.ModifiedUtc
                };


            }
        }

        public bool UpdateTasting(TastingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tastings
                    .Single(e => e.TastingId == model.TastingId && e.OwnerId == _userId);

                entity.OwnerId = model.OwnerId;
                entity.TastingId = model.TastingId;
                entity.TastingDate = model.TastingDate;
                entity.Title = model.Title;
                entity.Host = model.Host;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }        
        }

        public bool DeleteTasting(int tastingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Tastings
                    .Single(e => e.TastingId == tastingId && e.OwnerId == _userId);

                ctx.Tastings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
