using Xunit;
using Moq;
using FluentAssertions;

using Microsoft.AspNetCore.Mvc;

using Recam.API.Controllers;
using Recam.Services.Interfaces;
using Recam.Models.Entities;

namespace Recam.Tests;

public class ListingControllerTests
{
    private readonly Mock<IListingService> _listingServiceMock;
    private readonly ListingController _controller;

    public ListingControllerTests()
    {
        _listingServiceMock = new Mock<IListingService>();
        _controller = new ListingController(_listingServiceMock.Object);
    }

    [Fact]
    public async Task GetById_Should_ReturnOk_When_ListingExists()
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

        _listingServiceMock
            .Setup(x => x.GetListingByIdAsync(listingId))
            .ReturnsAsync(listing);

        // Act
        var result = await _controller.GetById(listingId);

        // Assert
        result.Should().BeOfType<OkObjectResult>();

        var okResult = result as OkObjectResult;
        okResult!.Value.Should().Be(listing);
    }

    [Fact]
    public async Task GetById_Should_ReturnNotFound_When_ListingDoesNotExist()
    {
        // Arrange
        var listingId = Guid.NewGuid();

        _listingServiceMock
            .Setup(x => x.GetListingByIdAsync(listingId))
            .ReturnsAsync((ListingCase?)null);

        // Act
        var result = await _controller.GetById(listingId);

        // Assert
        result.Should().BeOfType<NotFoundResult>();

        _listingServiceMock.Verify(
            x => x.GetListingByIdAsync(listingId),
            Times.Once);
    }
}