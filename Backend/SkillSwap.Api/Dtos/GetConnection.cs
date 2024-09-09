namespace SkillSwap.Api.Dtos;

public record GetConnection(
    Guid PublicId,
    bool IsAccepted
);