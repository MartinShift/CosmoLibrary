﻿namespace CosmoLibrary.Data.Entities;

public class Address
{
    public string Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public string? PublisherId { get; set; }
}
