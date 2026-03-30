using Xunit;
using Moq;
using FluentAssertions;

using Recam.Services.Services;
using Recam.Services.Interfaces;
using Recam.Repository.Interfaces;
using Recam.Models.Entities;

using Microsoft.AspNetCore.Identity;

namespace Recam.Tests;

public class AgentServiceTests
{
    private readonly Mock<IAgentRepository> _agentRepositoryMock;
    private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;

    private readonly AgentService _agentService;

    public AgentServiceTests()
    {
        _agentRepositoryMock = new Mock<IAgentRepository>();

        // ⚠️ UserManager mock 写法特殊（重点）
        _userManagerMock = new Mock<UserManager<ApplicationUser>>(
            Mock.Of<IUserStore<ApplicationUser>>(),
            null, null, null, null, null, null, null, null
        );

        _agentService = new AgentService(
            _agentRepositoryMock.Object,
            _userManagerMock.Object
        );
    }

    [Fact]
    public async Task GetAgentByEmailAsync_Should_ReturnAgent_When_Exists()
    {
        // Arrange
        var email = "test@recam.com";

        var agent = new Agent
        {
            Id = Guid.NewGuid(),
            Email = email,
            Name = "Test Agent"
        };

        _agentRepositoryMock
            .Setup(x => x.GetByEmailAsync(email))
            .ReturnsAsync(agent);

        // Act
        var result = await _agentService.GetByEmailAsync(email);

        // Assert
        result.Should().NotBeNull();
        result!.Email.Should().Be(email);

        _agentRepositoryMock.Verify(
            x => x.GetByEmailAsync(email),
            Times.Once);
    }

    [Fact]
    public async Task AssignAdminAsync_Should_UpdateAgent_When_AgentExists()
    {
        // Arrange
        var agentId = Guid.NewGuid();
        var adminId = "admin-123";

        var agent = new Agent
        {
            Id = agentId,
            Name = "Test Agent",
            Email = "test@recam.com"
        };

        _agentRepositoryMock
            .Setup(x => x.GetByIdAsync(agentId))
            .ReturnsAsync(agent);

        _agentRepositoryMock
            .Setup(x => x.UpdateAsync(It.IsAny<Agent>()))
            .Returns(Task.CompletedTask);

        // Act
        await _agentService.AssignAdminAsync(agentId, adminId);

        // Assert
        _agentRepositoryMock.Verify(
            x => x.UpdateAsync(It.Is<Agent>(a =>
                a.Id == agentId &&
                a.AdminId == adminId
            )),
            Times.Once);
    }

    [Fact]
    public async Task AssignAdminAsync_Should_ThrowException_When_AgentNotFound()
    {
        // Arrange
        var agentId = Guid.NewGuid();
        var adminId = "admin-123";

        _agentRepositoryMock
            .Setup(x => x.GetByIdAsync(agentId))
            .ReturnsAsync((Agent?)null);

        // Act
        Func<Task> act = async () => await _agentService.AssignAdminAsync(agentId, adminId);

        // Assert
        await act.Should().ThrowAsync<Exception>()
            .WithMessage("Agent not found");

        _agentRepositoryMock.Verify(
            x => x.UpdateAsync(It.IsAny<Agent>()),
            Times.Never);
    }
}