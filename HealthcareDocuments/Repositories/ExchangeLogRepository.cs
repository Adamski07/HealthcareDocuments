using HealthcareDocuments.Data;
using HealthcareDocuments.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareDocuments.Repositories;

public class ExchangeLogRepository : IExchangeLogRepository
{
    private readonly AppDbContext _context;

    public ExchangeLogRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ExchangeLog>> GetAllAsync()
    {
        return await _context.ExchangeLogs
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(ExchangeLog exchangeLog)
    {
        await _context.ExchangeLogs.AddAsync(exchangeLog);
        await _context.SaveChangesAsync();

    }
}
