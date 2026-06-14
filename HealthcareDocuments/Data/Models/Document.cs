namespace HealthcareDocuments.Data.Models;

public class Document
{
    public Guid Id { get; set; }
    
    public DocumentType Type { get; set; }

    public required string Title { get; set; }

    public required string Content { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public Guid ReferralId { get; set; }
    public Referral? Referral { get; set; }
}

public enum DocumentType
{
    ReferralLetter = 1,
    AllergyInformation = 2,
    MedicationInformation = 3
}