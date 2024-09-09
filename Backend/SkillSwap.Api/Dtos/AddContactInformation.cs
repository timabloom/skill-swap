using System.ComponentModel.DataAnnotations;

namespace SkillSwap.Api.Dtos;

public record AddContactInformation(
    [Required, EmailAddress]
    string Email
);