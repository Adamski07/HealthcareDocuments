using HealthcareDocuments.Data.Models;
using HealthcareDocuments.Dtos.ExchangeLogs;
using HealthcareDocuments.Repositories;

namespace HealthcareDocuments.Services;

public class ExchangeLogService : IExchangeLogService
{
    private readonly IExchangeLogRepository _exchangeLogRepository;
    private readonly ILogger<ExchangeLogService> _logger;

    public ExchangeLogService(
        IExchangeLogRepository exchangeLogRepository,
        ILogger<ExchangeLogService> logger)
    {
        _exchangeLogRepository = exchangeLogRepository;
        _logger = logger;
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
        await _exchangeLogRepository.SaveChangesAsync();

        _logger.LogInformation("Exchange log created for referral {ReferralId}: {Action}", referralId, action);
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
