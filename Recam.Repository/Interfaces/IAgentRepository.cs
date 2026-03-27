using Recam.Models.Entities;

namespace Recam.Repository.Interfaces;

public interface IAgentRepository
{
    Task<Agent?> GetByEmailAsync(string email);
    Task<List<Agent>> GetAllAsync();
    Task AddAsync(Agent agent);
    Task<Agent?> GetByIdAsync(Guid id);
    Task UpdateAsync(Agent agent);
}