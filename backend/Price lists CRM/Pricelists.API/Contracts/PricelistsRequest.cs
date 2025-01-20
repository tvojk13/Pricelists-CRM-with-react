namespace Pricelists.API.Contracts
{
    public record PricelistsRequest(
        string Title,
        string Text,
        int Number,
        DateTime Date);
}
