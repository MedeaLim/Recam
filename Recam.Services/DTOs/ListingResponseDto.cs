using Recam.Models.Enums;

namespace Recam.Services.DTOs;

public class ListingResponseDto
{
    public Guid Id { get; set; }

    public string Address { get; set; } = string.Empty;

    public PropertyStatus PropertyStatus { get; set; }

    public PropertyType PropertyType { get; set; }

    public int Bedrooms { get; set; }

    public int Bathrooms { get; set; }

    public int Garage { get; set; }

    public double Area { get; set; }

    public decimal Price { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}