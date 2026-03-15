using Microsoft.EntityFrameworkCore;
using Recam.DataAccess.Data;
using Recam.Models.Entities;
using Recam.Repository.Interfaces;

namespace Recam.Repository.Repositories;

public class ListingRepository : IListingRepository
{
    private readonly RecamDbContext _context;

    public ListingRepository(RecamDbContext context)
    {
        _context = context;
    }

    public async Task<List<ListingCase>> GetAllAsync()
    {
        return await _context.ListingCases.ToListAsync();
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
}