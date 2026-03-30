using Xunit;
using Moq;
using FluentAssertions;

using Recam.Service.Services;
using Recam.Service.Interfaces;   // ✅ 关键
using Recam.Repository.Interfaces;

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
}