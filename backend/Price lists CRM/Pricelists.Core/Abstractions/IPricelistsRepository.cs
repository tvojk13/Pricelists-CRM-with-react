using Pricelists.Core.Models;

namespace Pricelists.DataAccess.Entites.Repository
{
    public interface IPricelistsRepository
    {
        Task<int?> Create(PricelistModel pricelist);
        Task<int?> Delete(int? id);
        Task<List<PricelistModel>> Get();
        Task<int?> Update(int? id, string title, string text, int number, DateTime date);
    }
}