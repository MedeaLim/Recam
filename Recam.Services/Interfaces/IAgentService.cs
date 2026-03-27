using Recam.Models.Entities;
using Recam.Services.DTOs.Agent;

namespace Recam.Services.Interfaces;

public interface IAgentService
{
    Task<Agent?> GetByEmailAsync(string email);
    Task<List<Agent>> GetAllAsync();

    Task<Guid> CreateAgentAsync(CreateAgentRequest request);
    Task AssignAdminAsync(Guid agentId, string adminId);
}