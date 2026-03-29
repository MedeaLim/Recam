using Microsoft.EntityFrameworkCore;
using Recam.DataAccess.Data;
using Recam.Models.Entities;
using Recam.Repository.Interfaces;
using Recam.Models.Enums; 


namespace Recam.Repository.Repositories;

public class ListingRepository : IListingRepository
{
    private readonly RecamDbContext _context;

    public ListingRepository(RecamDbContext context)
    {
        _context = context;
    }

    public async Task<object> GetAllAsync(
        string? status,
        string? keyword,
        string? propertyType,
        int page,
        int pageSize)
    {
        var query = _context.ListingCases.AsQueryable();
        // Status (string)
        if (!string.IsNullOrEmpty(status))
        {
            query = query.Where(x => x.Status.ToLower() == status.ToLower());
        }

        // Keyword
        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(x => x.Address.Contains(keyword));
        }

        // PropertyType (enum)
        if (!string.IsNullOrEmpty(propertyType))
        {
            if (Enum.TryParse<PropertyType>(propertyType, true, out var parsedType))
            {
                query = query.Where(x => x.PropertyType == parsedType);
            }
        }

        // ===== Total Count =====
        var totalCount = await query.CountAsync();

        // ===== Pagination =====
        var data = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        // ===== Return =====
        return new
        {
            totalCount,
            page,
            pageSize,
            data
        };
    }
    public async Task<ListingCase?> GetByIdAsync(Guid id)
    {
        return await _context.ListingCases.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(ListingCase listing)
    {
        await _context.ListingCases.AddAsync(listing);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ListingCase listing)
    {
        _context.ListingCases.Update(listing);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var listing = await _context.ListingCases.FindAsync(id);

        if (listing != null)
        {
            _context.ListingCases.Remove(listing);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<ListingCase>> GetByAgentIdAsync(string agentId)
    {
        return await _context.ListingCases
            .Where(l => l.AgentId == agentId)
            .ToListAsync();
    }
}