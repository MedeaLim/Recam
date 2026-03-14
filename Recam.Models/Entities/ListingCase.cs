namespace Recam.Models.Entities;

public class ListingCase
{
    public Guid Id { get; set; }

    public string Address { get; set; } = string.Empty;

    public string PropertyStatus { get; set; } = string.Empty;

    public string PropertyType { get; set; } = string.Empty;

    public int Bedrooms { get; set; }

    public int Bathrooms { get; set; }

    public int Garage { get; set; }

    public double Area { get; set; }

    public decimal Price { get; set; }

    public string Status { get; set; } = "Created";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}