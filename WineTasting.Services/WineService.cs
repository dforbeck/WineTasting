using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;
using WineTasting.Models.Wine;

namespace WineTasting.Services
{
    public class WineService
    {
        private readonly Guid _userId;

        public WineService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWine(WineCreate model)
        {
            var entity = new Wine()
            {
                OwnerId = _userId,
                Brand = model.Brand,
                SubBrand = model.SubBrand,
                WineVarietal = model.WineVarietal,
                Region = model.Region,
                Year = model.Year,
                CodeForBlindTasting = model.CodeForBlindTasting,
                CreatedUtc = DateTimeOffset.Now                
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Wines.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WineListItem> GetWines()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Wines
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new WineListItem
                    {
                        WineId = e.WineId,
                        Brand = e.Brand,
                        SubBrand = e.SubBrand,
                        WineVarietal = e.WineVarietal,
                        Region = e.Region,
                        Year = e.Year,
                        CodeForBlindTasting = e.CodeForBlindTasting                        
                    }
                    );
                return query.ToArray();
            }
        }

        public WineDetail GetNotebyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Wines
                    .Single(e => e.WineId == wineId && e.OwnerId == _userId);
                return new WineDetail
                {
                    WineId = entity.WineId,
                    Brand = entity.Brand,
                    SubBrand = entity.SubBrand,
                    WineVarietal = entity.SubBrand,
                    Region = entity.SubBrand,
                    Year = entity.Year,
                    CodeForBlindTasting = entity.CodeForBlindTasting,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModfiedUtc
                };

            }
        }
    }
}
