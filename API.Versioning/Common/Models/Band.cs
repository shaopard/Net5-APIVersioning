namespace Common.Models
{
    public class Band
    {
        public int Id { get; set; }

        public IEnumerable<string>? Names { get; set; }

        public int FoundedYear { get; set; }
    }
}
