namespace CosmoLibrary.Business.Models;

public class BookDto
{
    public string? Id { get; set; }
    public string Title { get; set; }

    public PublisherDto Publisher { get; set; }

    public DateTime PublicationDate { get; set; }

    public string ImageUrl { get; set; }
}
