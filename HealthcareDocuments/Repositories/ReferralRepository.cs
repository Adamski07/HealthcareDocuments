using HealthcareDocuments.Data;
using HealthcareDocuments.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareDocuments.Repositories;

public class ReferralRepository : IReferralRepository
{
    private readonly AppDbContext _context;

    public ReferralRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Referral> CreateAsync(Referral referral)
    {
        _context.Referrals.Add(referral);
        await _context.SaveChangesAsync();

        return referral;
    }

    public async Task<IReadOnlyList<Referral>> GetAllAsync()
    {
        return await _context.Referrals
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Referral?> GetByIdAsync(Guid id)
    {
        return await _context.Referrals
            .AsNoTracking()
            .FirstOrDefaultAsync(referral => referral.Id == id);
    }

    public async Task<Document> AddDocumentAsync(Document document)
    {
        _context.Documents.Add(document);
        await _context.SaveChangesAsync();

        return document;
    }

    public async Task<IReadOnlyList<Document>> GetDocumentsByReferralIdAsync(Guid referralId)
    {
        return await _context.Documents
            .AsNoTracking()
            .Where(document => document.ReferralId == referralId)
            .ToListAsync();
    }
}
