namespace HealthcareDocuments.Data.Models;

public class ExchangeLog
{
    public Guid Id { get; set; }
    
    public required string Action { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    
    public Guid ReferralId { get; set; }
    public Referral? Referral { get; set; }
}