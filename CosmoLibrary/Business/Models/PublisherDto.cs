namespace CosmoLibrary.Business.Models;

public class PublisherDto
{
    public string? Id { get; set; }
    public string Name { get; set; }
    public AddressDto Address { get; set; }
    public string? BookId { get; set; }
}
