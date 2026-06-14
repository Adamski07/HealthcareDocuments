using System.ComponentModel.DataAnnotations;

namespace HealthcareDocuments.Dtos.Referrals;

public class CreateReferralRequestDto
{
    [Required]
    public string? PatientName { get; set; }

    [Required]
    public DateOnly? PatientDateOfBirth { get; set; }

    [Required]
    public string? FromOrganization { get; set; }

    [Required]
    public string? ToOrganization { get; set; }
}
