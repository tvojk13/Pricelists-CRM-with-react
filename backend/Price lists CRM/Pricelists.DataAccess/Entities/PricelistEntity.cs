namespace Pricelists.DataAccess.Entites
{
    public class PricelistEntity
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
    }
}
