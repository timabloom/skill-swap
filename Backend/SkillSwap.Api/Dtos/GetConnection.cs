namespace SkillSwap.Api.Dtos;

public record GetConnection(
    Guid PublicId,
    Guid ProfileMatchPublicId,
    bool IsAccepted
);