namespace SkillSwap.Api.Dtos;

public record GetContactInformation(
    Guid PublicId,
    string Email
);