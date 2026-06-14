using HealthcareDocuments.Data.Models;

namespace HealthcareDocuments.Dtos.Documents;

public class DocumentResponseDto
{
    public Guid Id { get; set; }

    public Guid ReferralId { get; set; }

    public DocumentType Type { get; set; }

    public required string Title { get; set; }

    public required string Content { get; set; }

    public DateTime CreatedAt { get; set; }
}
