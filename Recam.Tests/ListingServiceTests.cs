using Xunit;
using Moq;
using FluentAssertions;

using Recam.Services.Interfaces;
using Recam.Services.Services;
using Recam.Repository.Interfaces;
using Recam.Services.DTOs;
using Recam.Models.Entities;

namespace Recam.Tests;

public class ListingServiceTests
{
    private readonly Mock<IListingRepository> _listingRepositoryMock;
    private readonly ListingService _listingService;

    public ListingServiceTests()
    {
        _listingRepositoryMock = new Mock<IListingRepository>();
        _listingService = new ListingService(_listingRepositoryMock.Object);
    }

    [Fact]
    public async Task CreateListingAsync_Should_CallRepository_When_ListingIsValid()
    {
        // Arrange
        var listing = new ListingCase
        {
            Id = Guid.NewGuid(),
            Address = "Test Address",
            Price = 1000000,
            AgentId = "agent-1"
        };

        _listingRepositoryMock
            .Setup(x => x.AddAsync(It.IsAny<ListingCase>()))
            .Returns(Task.CompletedTask);

        // Act
        await _listingService.CreateListingAsync(listing);

        // Assert
        _listingRepositoryMock.Verify(
            x => x.AddAsync(It.Is<ListingCase>(l =>
                l.Address == listing.Address &&
                l.Price == listing.Price &&
                l.AgentId == listing.AgentId
            )),
            Times.Once);
    }
}