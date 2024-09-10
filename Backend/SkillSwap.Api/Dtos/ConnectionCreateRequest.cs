using System.ComponentModel.DataAnnotations;

namespace SkillSwap.Api.Dtos;

public record ConnectionCreateRequest(
    [Required]
    string ClerkId,
    [Required]
    Guid ProfileMatchPublicId
);