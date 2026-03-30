using Xunit;
using Moq;
using FluentAssertions;

using Recam.Services.Services;
using Recam.Repository.Interfaces;
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

    [Fact]
    public async Task GetListingByIdAsync_Should_ReturnListing_When_Exists()
    {
        // Arrange
        var listingId = Guid.NewGuid();

        var listing = new ListingCase
        {
            Id = listingId,
            Address = "Test Address",
            Price = 1000000,
            AgentId = "agent-1"
        };

        _listingRepositoryMock
            .Setup(x => x.GetByIdAsync(listingId))
            .ReturnsAsync(listing);

        // Act
        var result = await _listingService.GetListingByIdAsync(listingId);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(listingId);

        _listingRepositoryMock.Verify(
            x => x.GetByIdAsync(listingId),
            Times.Once);
    }

    [Fact]
    public async Task DeleteListingAsync_Should_CallRepository_When_ListingExists()
    {
        // Arrange
        var listingId = Guid.NewGuid();

        _listingRepositoryMock
            .Setup(x => x.DeleteAsync(listingId))
            .Returns(Task.CompletedTask);

        // Act
        await _listingService.DeleteListingAsync(listingId);

        // Assert
        _listingRepositoryMock.Verify(
            x => x.DeleteAsync(listingId),
            Times.Once);
    }
}