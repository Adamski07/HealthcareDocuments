using System.ComponentModel.DataAnnotations;
using HealthcareDocuments.Data.Models;

namespace HealthcareDocuments.Dtos.Documents;

public class CreateDocumentDto
{
    [Required]
    public DocumentType? Type { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Content { get; set; }
}
