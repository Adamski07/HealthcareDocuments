using HealthcareDocuments.Data.Models;

namespace HealthcareDocuments.Repositories;

public interface IExchangeLogRepository
{
    Task<List<ExchangeLog>> GetAllAsync();

    Task AddAsync(ExchangeLog exchangeLog);
}
