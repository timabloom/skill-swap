using SkillSwap.Api.Models;

namespace SkillSwap.Api.Dtos;

public record GetConnection(
    Guid PublicId,
    Guid ProfileMatchPublicId,
    bool IsAccepted
)
{
    public static explicit operator GetConnection(Connection connection)
    {
        return new GetConnection(
            connection.PublicId,
            connection.ProfileMatchPublicId,
            connection.IsAccepted
        );
    }
}