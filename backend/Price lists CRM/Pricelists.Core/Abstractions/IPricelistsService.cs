using Pricelists.Core.Models;

namespace Pricelists.Application.Services
{
    public interface IPricelistsService
    {
        Task<int?> CreatePricelist(PricelistModel pricelist);
        Task<int?> DeletePricelist(int? id);
        Task<List<PricelistModel>> GetAllPriceLists();
        Task<int?> UpdatePricelist(int? id, string title, string text, int number, DateTime date);
    }
}