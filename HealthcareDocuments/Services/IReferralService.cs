using HealthcareDocuments.Dtos.Referrals;

namespace HealthcareDocuments.Services;

public interface IReferralService
{
    Task<ReferralResponseDto> CreateAsync(CreateReferralRequestDto request);

    Task<IReadOnlyList<ReferralResponseDto>> GetAllAsync();

    Task<ReferralResponseDto?> GetByIdAsync(Guid id);
}
