using Pricelists.Core.Models;
using Pricelists.DataAccess.Entites.Repository;

namespace Pricelists.Application.Services
{
    public class PricelistsService : IPricelistsService
    {
        private readonly IPricelistsRepository _pricelistsRepository;

        public PricelistsService(IPricelistsRepository pricelistsRepository)
        {
            _pricelistsRepository = pricelistsRepository;
        }

        public async Task<List<PricelistModel>> GetAllPriceLists()
        {
            return await _pricelistsRepository.Get();
        }

        public async Task<int?> CreatePricelist(PricelistModel pricelist)
        {
            return await _pricelistsRepository.Create(pricelist);
        }

        public async Task<int?> UpdatePricelist(int? id, string title, string text, int number, DateTime date)
        {
            return await _pricelistsRepository.Update(id, title, text, number, date);
        }

        public async Task<int?> DeletePricelist(int? id)
        {
            return await _pricelistsRepository.Delete(id);
        }
    }
}
