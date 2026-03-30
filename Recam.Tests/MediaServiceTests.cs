using Xunit;
using Moq;
using FluentAssertions;

using Recam.Service.Services;
using Recam.Service.Interfaces;   
using Recam.Repository.Interfaces;
using Recam.Service.DTOs.Media;
using Recam.Models.Enums;

namespace Recam.Tests;

public class MediaServiceTests
{
    private readonly Mock<IMediaRepository> _mediaRepositoryMock;
    private readonly Mock<IBlobStorageService> _storageServiceMock;

    private readonly MediaService _mediaService;

    public MediaServiceTests()
    {
        _mediaRepositoryMock = new Mock<IMediaRepository>();
        _storageServiceMock = new Mock<IBlobStorageService>();

        _mediaService = new MediaService(
            _mediaRepositoryMock.Object,
            _storageServiceMock.Object
        );
    }

    [Fact]
    public async Task UploadMediaAsync_Should_SaveMedia_When_RequestIsValid()
    {
        // Arrange
        var listingId = Guid.NewGuid();

        var stream = new MemoryStream(new byte[] { 1, 2, 3 });

        var request = new UploadMediaRequestDto
        {
            FileStream = stream,
            FileName = "test.jpg",
            ContentType = "image/jpeg",
            MediaType = MediaType.Photo,    
            IsHero = true
        };

        var storagePath = "fake/path/test.jpg";

        _storageServiceMock
            .Setup(x => x.UploadAsync(It.IsAny<Stream>(), It.IsAny<string>()))
            .ReturnsAsync(storagePath);

        _mediaRepositoryMock
            .Setup(x => x.AddAsync(It.IsAny<MediaAsset>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _mediaService.UploadMediaAsync(listingId, request);

        // Assert
        result.Should().NotBeNull();
        result.Url.Should().NotBeNull();
        result.MediaType.Should().Be(MediaType.Photo.ToString());

        _storageServiceMock.Verify(
            x => x.UploadAsync(It.IsAny<Stream>(), It.IsAny<string>()),
            Times.Once);

        _mediaRepositoryMock.Verify(
            x => x.AddAsync(It.IsAny<MediaAsset>()),
            Times.Once);
    }

    [Fact]
    public async Task GetMediaByListingIdAsync_Should_ReturnMediaList_When_Exists()
    {
        // Arrange
        var listingId = Guid.NewGuid();

        var mediaList = new List<MediaAsset>
        {
            new MediaAsset
            {
                Id = Guid.NewGuid(),
                FileName = "test.jpg",
                StoragePath = "path/test.jpg",
                MediaType = MediaType.Photo
            }
        };

        _mediaRepositoryMock
            .Setup(x => x.GetByListingIdAsync(listingId))
            .ReturnsAsync(mediaList);

        // Act
        var result = await _mediaService.GetMediaByListingIdAsync(listingId);

        // Assert
        result.Should().NotBeNull();
        result.Count.Should().Be(1);

        _mediaRepositoryMock.Verify(
            x => x.GetByListingIdAsync(listingId),
            Times.Once);
    }

    [Fact]
    public async Task DeleteMediaAsync_Should_CallRepository_When_MediaExists()
    {
        // Arrange
        var mediaId = Guid.NewGuid();

        var media = new MediaAsset
        {
            Id = mediaId,
            FileName = "test.jpg",
            OriginalFileName = "test.jpg",
            StoragePath = "path/test.jpg",
            ContentType = "image/jpeg"
        };

        // ⚠️ Service 内部肯定会先 Get 再 Delete
        _mediaRepositoryMock
            .Setup(x => x.GetByIdAsync(mediaId))
            .ReturnsAsync(media);

        _mediaRepositoryMock
            .Setup(x => x.DeleteAsync(It.IsAny<MediaAsset>()))
            .Returns(Task.CompletedTask);

        // Act
        await _mediaService.DeleteMediaAsync(mediaId);

        // Assert
        _mediaRepositoryMock.Verify(
            x => x.DeleteAsync(It.Is<MediaAsset>(m => m.Id == mediaId)),
            Times.Once);
    }
}