namespace SocializR.Data.Models
{
    public class Shout
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
