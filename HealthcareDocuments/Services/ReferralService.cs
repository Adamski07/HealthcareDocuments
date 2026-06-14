using HealthcareDocuments.Data.Models;
using HealthcareDocuments.Dtos.Documents;
using HealthcareDocuments.Dtos.Referrals;
using HealthcareDocuments.Repositories;

namespace HealthcareDocuments.Services;

public class ReferralService : IReferralService
{
    private readonly IReferralRepository _referralRepository;

    public ReferralService(IReferralRepository referralRepository)
    {
        _referralRepository = referralRepository;
    }

    public async Task<ReferralResponseDto> CreateAsync(CreateReferralRequestDto request)
    {
        var referral = new Referral
        {
            Id = Guid.NewGuid(),
            PatientName = request.PatientName!,
            PatientDateOfBirth = request.PatientDateOfBirth!.Value,
            FromOrganization = request.FromOrganization!,
            ToOrganization = request.ToOrganization!,
            CreatedAt = DateTime.UtcNow
        };

        var createdReferral = await _referralRepository.CreateAsync(referral);

        return ToResponse(createdReferral);
    }

    public async Task<IReadOnlyList<ReferralResponseDto>> GetAllAsync()
    {
        var referrals = await _referralRepository.GetAllAsync();

        return referrals.Select(ToResponse).ToList();
    }

    public async Task<ReferralResponseDto?> GetByIdAsync(Guid id)
    {
        var referral = await _referralRepository.GetByIdAsync(id);

        return referral is null ? null : ToResponse(referral);
    }

    public async Task<DocumentResponseDto?> AddDocumentToReferralAsync(Guid referralId, CreateDocumentDto request)
    {
        var referral = await _referralRepository.GetByIdAsync(referralId);

        if (referral is null)
        {
            return null;
        }

        var document = new Document
        {
            Id = Guid.NewGuid(),
            ReferralId = referralId,
            Type = request.Type!.Value,
            Title = request.Title!,
            Content = request.Content!,
            CreatedAt = DateTime.UtcNow
        };

        var createdDocument = await _referralRepository.AddDocumentAsync(document);

        return ToDocumentResponse(createdDocument);
    }

    public async Task<IReadOnlyList<DocumentResponseDto>?> GetDocumentsByReferralIdAsync(Guid referralId)
    {
        var referral = await _referralRepository.GetByIdAsync(referralId);

        if (referral is null)
        {
            return null;
        }

        var documents = await _referralRepository.GetDocumentsByReferralIdAsync(referralId);

        return documents.Select(ToDocumentResponse).ToList();
    }

    private static ReferralResponseDto ToResponse(Referral referral)
    {
        return new ReferralResponseDto
        {
            Id = referral.Id,
            PatientName = referral.PatientName,
            PatientDateOfBirth = referral.PatientDateOfBirth,
            FromOrganization = referral.FromOrganization,
            ToOrganization = referral.ToOrganization,
            CreatedAt = referral.CreatedAt
        };
    }

    private static DocumentResponseDto ToDocumentResponse(Document document)
    {
        return new DocumentResponseDto
        {
            Id = document.Id,
            ReferralId = document.ReferralId,
            Type = document.Type,
            Title = document.Title,
            Content = document.Content,
            CreatedAt = document.CreatedAt
        };
    }
}
