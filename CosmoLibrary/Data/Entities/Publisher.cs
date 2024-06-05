namespace CosmoLibrary.Data.Entities;

public class Publisher
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Address Address { get; set; }
    public string? BookId { get; set; }
}

