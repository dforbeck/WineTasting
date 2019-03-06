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
                TastingDate = model.TastingDate,
                Title = model.Title,
                Host = model.Host,
                TypeOfWine = model.TypeOfWine,
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
                        TastingId = e.TastingId,
                        TastingDate = e.TastingDate,
                        Title = e.Title,
                        TypeOfWine = e.TypeOfWine
                    }
                    );
                return query.ToArray();
            }
        }
    }


}
