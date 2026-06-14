using HealthcareDocuments.Data.Models;

namespace HealthcareDocuments.Repositories;

public interface IReferralRepository
{
    Task<Referral> CreateAsync(Referral referral);

    Task<IReadOnlyList<Referral>> GetAllAsync();

    Task<Referral?> GetByIdAsync(Guid id);
}
