using Microsoft.EntityFrameworkCore;
using Recam.DataAccess.Data;
using Recam.Models.Entities;
using Recam.Repository.Interfaces;

namespace Recam.Repository.Repositories;

public class MediaRepository : IMediaRepository
{
    private readonly RecamDbContext _context;

    public MediaRepository(RecamDbContext context)
    {
        _context = context;
    }

    public async Task<List<MediaAsset>> GetByListingIdAsync(Guid listingId)
    {
        return await _context.MediaAssets
            .Where(m => m.ListingId == listingId && !m.IsDeleted)
            .ToListAsync();
    }

    public async Task<MediaAsset?> GetByIdAsync(Guid id)
    {
        return await _context.MediaAssets
            .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);
    }

    public async Task AddAsync(MediaAsset media)
    {
        await _context.MediaAssets.AddAsync(media);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(MediaAsset media)
    {
        media.IsDeleted = true;
        _context.MediaAssets.Update(media);
        await _context.SaveChangesAsync();
    }
}