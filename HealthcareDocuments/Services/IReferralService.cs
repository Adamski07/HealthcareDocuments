using HealthcareDocuments.Dtos.Documents;
using HealthcareDocuments.Dtos.Referrals;

namespace HealthcareDocuments.Services;

public interface IReferralService
{
    Task<ReferralResponseDto> CreateAsync(CreateReferralRequestDto request);

    Task<IReadOnlyList<ReferralResponseDto>> GetAllAsync();

    Task<ReferralResponseDto?> GetByIdAsync(Guid id);

    Task<DocumentResponseDto?> AddDocumentToReferralAsync(Guid referralId, CreateDocumentDto request);

    Task<IReadOnlyList<DocumentResponseDto>?> GetDocumentsByReferralIdAsync(Guid referralId);

    Task<bool> RequestMedicationInformationAsync(Guid referralId);
}
