namespace Pricelists.Core.Models
{
    public class PricelistModel
    {
        public int? Id { get; }
        public string Title { get; }
        public string Text { get; }
        public int Number { get; }
        public DateTime Date { get; }

        private PricelistModel(int? id, string title, string text, int number, DateTime date)
        {
            Id = id;
            Title = title;
            Text = text;
            Number = number;
            Date = date;
        }

        public static PricelistModel Create(int? id, string title, string text, int number, DateTime date)
        {
            return new PricelistModel(id, title, text, number, DateTime.Now);
        }
    }
}
