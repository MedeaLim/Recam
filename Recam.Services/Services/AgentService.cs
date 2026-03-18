using Recam.Models.Entities;
using Recam.Repository.Interfaces;
using Recam.Services.Interfaces;

namespace Recam.Services.Services;

public class AgentService : IAgentService
{
    private readonly IAgentRepository _agentRepository;

    public AgentService(IAgentRepository agentRepository)
    {
        _agentRepository = agentRepository;
    }

    public async Task<Agent?> GetByEmailAsync(string email)
    {
        return await _agentRepository.GetByEmailAsync(email);
    }

    public async Task<List<Agent>> GetAllAsync()
    {
        return await _agentRepository.GetAllAsync();
    }
}