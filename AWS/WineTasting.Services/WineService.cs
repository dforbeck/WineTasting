﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTasting.Data;
using WineTasting.Models.Tasting;
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
                WineId = model.WineId,
                TastingId = model.TastingId,
                Brand = model.Brand,
                SubBrand = model.SubBrand,
                WineVarietal = model.WineVarietal,
                Region = model.Region,
                Year = model.Year,
                CodeForTasting = model.CodeForTasting,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Wines.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WineListItem> GetWinesByTastingId(TastingDetail tasting)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = 
                    ctx
                    .Wines
                    .Where(e => e.TastingId == tasting.TastingId)
                    .Select(e => new WineListItem
                    {
                        OwnerId = e.OwnerId,
                        WineId = e.WineId,
                        TastingId = e.TastingId,
                        TastingDate = tasting.TastingDate,
                        Brand = e.Brand,
                        SubBrand = e.SubBrand,
                        WineVarietal = e.WineVarietal,
                        Region = e.Region,
                        Year = e.Year,
                        CodeForTasting = e.CodeForTasting
                    }
                     );
                return query.ToArray();
            }
        }

        public WineDetail GetWineById(int wineId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Wines
                    .Single(e => e.WineId == wineId && e.OwnerId == _userId);
                return new WineDetail
                {
                    OwnerId = entity.OwnerId,
                    WineId = entity.WineId,
                    TastingId = entity.TastingId,
                    TastingDate = entity.Tasting.TastingDate,
                    Brand = entity.Brand,
                    SubBrand = entity.SubBrand,
                    WineVarietal = entity.WineVarietal,
                    Region = entity.Region,
                    Year = entity.Year,
                    CodeForTasting = entity.CodeForTasting,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
            }
        }
      
        public bool UpdateWine(WineEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Wines
                    .Single(e => e.WineId == model.WineId && e.OwnerId == _userId);

                entity.Brand = model.Brand;
                entity.SubBrand = model.SubBrand;
                entity.WineVarietal = model.WineVarietal;
                entity.Region = model.Region;
                entity.Year = model.Year;
                entity.CodeForTasting = model.CodeForTasting;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteWine(int wineId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx
                    .Wines
                    .Single(e => e.WineId == wineId && e.OwnerId == _userId);

                ctx.Wines.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}