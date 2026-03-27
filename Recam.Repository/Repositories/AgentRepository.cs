using Microsoft.EntityFrameworkCore;
using Recam.DataAccess.Data;
using Recam.Models.Entities;
using Recam.Repository.Interfaces;

namespace Recam.Repository.Repositories;

public class AgentRepository : IAgentRepository
{
    private readonly RecamDbContext _context;

    public AgentRepository(RecamDbContext context)
    {
        _context = context;
    }

    public async Task<Agent?> GetByEmailAsync(string email)
    {
        return await _context.Agents
            .FirstOrDefaultAsync(a => a.Email == email);
    }

    public async Task<List<Agent>> GetAllAsync()
    {
        return await _context.Agents.ToListAsync();
    }

    public async Task AddAsync(Agent agent)
    {
        _context.Agents.Add(agent);
        await _context.SaveChangesAsync();
    }

    public async Task<Agent?> GetByIdAsync(Guid id)
    {
    return await _context.Agents.FindAsync(id);
    }

    public async Task UpdateAsync(Agent agent)
    {
        _context.Agents.Update(agent);
        await _context.SaveChangesAsync();
    }
}