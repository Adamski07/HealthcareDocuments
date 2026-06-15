using HealthcareDocuments.Data.Models;
using HealthcareDocuments.Dtos.ExchangeLogs;
using HealthcareDocuments.Repositories;

namespace HealthcareDocuments.Services;

public class ExchangeLogService : IExchangeLogService
{
    private readonly IExchangeLogRepository _exchangeLogRepository;

    public ExchangeLogService(IExchangeLogRepository exchangeLogRepository)
    {
        _exchangeLogRepository = exchangeLogRepository;
    }

    public async Task<List<ExchangeLogResponseDto>> GetAllAsync()
    {
        var exchangeLogs = await _exchangeLogRepository.GetAllAsync();

        return exchangeLogs.Select(ToResponse).ToList();
    }

    public async Task AddAsync(Guid referralId, string action)
    {
        var exchangeLog = new ExchangeLog
        {
            Id = Guid.NewGuid(),
            ReferralId = referralId,
            Action = action,
            Timestamp = DateTime.UtcNow
        };

        await _exchangeLogRepository.AddAsync(exchangeLog);
    }

    private static ExchangeLogResponseDto ToResponse(ExchangeLog exchangeLog)
    {
        return new ExchangeLogResponseDto
        {
            Id = exchangeLog.Id,
            ReferralId = exchangeLog.ReferralId,
            Action = exchangeLog.Action,
            Timestamp = exchangeLog.Timestamp
        };
    }
}
