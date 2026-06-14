using HealthcareDocuments.Dtos.ExchangeLogs;
using HealthcareDocuments.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareDocuments.Controllers;

[ApiController]
[Route("api/exchange-logs")]
public class ExchangeLogsController : ControllerBase
{
    private readonly IExchangeLogService _exchangeLogService;

    public ExchangeLogsController(IExchangeLogService exchangeLogService)
    {
        _exchangeLogService = exchangeLogService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExchangeLogResponseDto>>> GetAll()
    {
        var exchangeLogs = await _exchangeLogService.GetAllAsync();

        return Ok(exchangeLogs);
    }
}
