using System.ComponentModel.DataAnnotations;

namespace SkillSwap.Api.Dtos;

public record AddNeed(
    [Required, MinLength(3), MaxLength(50)]
    string TagName
);