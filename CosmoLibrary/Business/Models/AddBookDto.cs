namespace CosmoLibrary.Business.Models
{
    public class AddBookDto
    {
        public BookDto Book { get; set; }

        public List<string> AuthorIds { get; set; }
    }
}
