namespace HealthcareDocuments.Dtos.Referrals;

public class ReferralResponseDto
{
    public Guid Id { get; set; }

    public required string PatientName { get; set; }

    public DateOnly PatientDateOfBirth { get; set; }

    public required string FromOrganization { get; set; }

    public required string ToOrganization { get; set; }

    public DateTime CreatedAt { get; set; }
}
