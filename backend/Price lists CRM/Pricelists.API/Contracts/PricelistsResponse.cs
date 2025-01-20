namespace Pricelists.API.Contracts
{
    public record PricelistsResponse(
        int? Id,
        string Title,
        string Text,
        int Number,
        DateTime Date);
}
