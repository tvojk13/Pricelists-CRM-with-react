using Microsoft.EntityFrameworkCore;
using Pricelists.Core.Models;

namespace Pricelists.DataAccess.Entites.Repository
{
    public class PricelistsRepository : IPricelistsRepository
    {
        private readonly PricelistsDbContext _context;
        public PricelistsRepository(PricelistsDbContext context)
        {
            _context = context;
        }

        public async Task<List<PricelistModel>> Get()
        {
            var pricelistEntities = await _context.Pricelists
                .AsNoTracking()
                .ToListAsync();

            var pricelists = pricelistEntities
                .Select(p => PricelistModel.Create(p.Id, p.Title, p.Text, p.Number, p.Date))
                .ToList();

            return pricelists;
        }

        public async Task<int?> Create(PricelistModel pricelist)
        {
            var pricelistEntity = new PricelistEntity
            {
                Id = pricelist.Id,
                Title = pricelist.Title,
                Text = pricelist.Text,
                Number = pricelist.Number,
                Date = pricelist.Date,
            };

            await _context.Pricelists.AddAsync(pricelistEntity);
            await _context.SaveChangesAsync();

            return pricelistEntity.Id;
        }

        public async Task<int?> Update(int? id, string title, string text, int number, DateTime date)
        {
            var pricelists = await _context.Pricelists
                .Where(p => p.Id == id)
                .ToListAsync();

            foreach (var pricelist in pricelists)
            {
                pricelist.Id = id;
                pricelist.Title = title;
                pricelist.Text = text;
                pricelist.Number = number;
                pricelist.Date = date;
            }

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<int?> Delete(int? id)
        {
            var pricelists = await _context.Pricelists
                .Where(p => p.Id == id)
                .ToListAsync();

            _context.Pricelists.RemoveRange(pricelists);

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
