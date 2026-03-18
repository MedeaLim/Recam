using Microsoft.EntityFrameworkCore;
using Recam.DataAccess.Data;
using Recam.Models.Entities;
using Recam.Repository.Interfaces;

namespace Recam.Repository.Repositories;

public class CaseContactRepository : ICaseContactRepository
{
    private readonly RecamDbContext _context;

    public CaseContactRepository(RecamDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(CaseContact caseContact)
    {
        await _context.CaseContacts.AddAsync(caseContact);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CaseContact>> GetByListingIdAsync(Guid listingId)
    {
        return await _context.CaseContacts
            .Where(c => c.ListingId == listingId)
            .ToListAsync();
    }
}