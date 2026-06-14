using HealthcareDocuments.Dtos.ExchangeLogs;

namespace HealthcareDocuments.Services;

public interface IExchangeLogService
{
    Task<List<ExchangeLogResponseDto>> GetAllAsync();

    Task AddAsync(Guid referralId, string action);
}
