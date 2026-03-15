using Recam.Models.Enums;

namespace Recam.Services.DTOs;

public class CreateListingDto
{
    public string Address { get; set; } = string.Empty;

    public PropertyStatus PropertyStatus { get; set; }

    public PropertyType PropertyType { get; set; }

    public int Bedrooms { get; set; }

    public int Bathrooms { get; set; }

    public int Garage { get; set; }

    public double Area { get; set; }

    public decimal Price { get; set; }
}