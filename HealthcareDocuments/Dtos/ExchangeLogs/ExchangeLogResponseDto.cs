namespace HealthcareDocuments.Dtos.ExchangeLogs;

public class ExchangeLogResponseDto
{
    public Guid Id { get; set; }

    public Guid ReferralId { get; set; }

    public required string Action { get; set; }

    public DateTime Timestamp { get; set; }
}
