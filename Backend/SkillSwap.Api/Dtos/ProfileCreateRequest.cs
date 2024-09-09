using System.ComponentModel.DataAnnotations;

namespace SkillSwap.Api.Dtos;

public record ProfileCreateRequest(
    [Required]
    string ClerkId,
    [Required]
    string Name,
    [MaxLength(300)]
    string? Bio,
    [Url]
    string? ImageUrl,
    ICollection<AddSkill>? Skills,
    ICollection<AddNeed>? Needs,
    [EmailAddress]
    string? Email
);
