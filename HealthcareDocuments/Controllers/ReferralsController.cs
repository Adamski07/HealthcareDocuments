using HealthcareDocuments.Dtos.Documents;
using HealthcareDocuments.Dtos.Referrals;
using HealthcareDocuments.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareDocuments.Controllers;

[ApiController]
[Route("api/referrals")]
public class ReferralsController : ControllerBase
{
    private readonly IReferralService _referralService;

    public ReferralsController(IReferralService referralService)
    {
        _referralService = referralService;
    }

    [HttpPost]
    public async Task<ActionResult<ReferralResponseDto>> Create(CreateReferralRequestDto request)
    {
        var referral = await _referralService.CreateAsync(request);

        return CreatedAtAction(nameof(GetById), new { id = referral.Id }, referral);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReferralResponseDto>>> GetAll()
    {
        var referrals = await _referralService.GetAllAsync();

        return Ok(referrals);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ReferralResponseDto>> GetById(Guid id)
    {
        var referral = await _referralService.GetByIdAsync(id);

        if (referral is null)
        {
            return NotFound();
        }

        return Ok(referral);
    }

    [HttpPost("{referralId:guid}/documents")]
    public async Task<ActionResult<DocumentResponseDto>> AddDocument(
        Guid referralId,
        CreateDocumentDto request)
    {
        var document = await _referralService.AddDocumentToReferralAsync(referralId, request);

        if (document is null)
        {
            return NotFound();
        }

        return CreatedAtAction(nameof(GetDocuments), new { referralId }, document);
    }

    [HttpGet("{referralId:guid}/documents")]
    public async Task<ActionResult<IEnumerable<DocumentResponseDto>>> GetDocuments(Guid referralId)
    {
        var documents = await _referralService.GetDocumentsByReferralIdAsync(referralId);

        if (documents is null)
        {
            return NotFound();
        }

        return Ok(documents);
    }
}
