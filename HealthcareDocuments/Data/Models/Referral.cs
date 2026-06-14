namespace HealthcareDocuments.Data.Models;

public class Referral
{
    public Guid Id { get; set; }

    public required string PatientName { get; set; }

    public DateOnly PatientDateOfBirth { get; set; }

    public required string FromOrganization { get; set; }

    public required string ToOrganization { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Document> Documents { get; set; } = [];

    public ICollection<ExchangeLog> ExchangeLogs { get; set; } = [];
}