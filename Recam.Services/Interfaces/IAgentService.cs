using Recam.Models.Entities;

namespace Recam.Services.Interfaces;

public interface IAgentService
{
    Task<Agent?> GetByEmailAsync(string email);

    Task<List<Agent>> GetAllAsync();
}