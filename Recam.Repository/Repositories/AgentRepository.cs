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
}