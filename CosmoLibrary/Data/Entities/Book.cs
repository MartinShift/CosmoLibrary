namespace CosmoLibrary.Data.Entities;

public class Book
{
    public string Id { get; set; }

    public string Title { get; set; }

    public Publisher Publisher { get; set; }

    public DateTime PublicationDate { get; set; }

    public string ImageUrl { get; set; }
}
