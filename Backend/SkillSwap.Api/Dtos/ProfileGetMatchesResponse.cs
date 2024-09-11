using SkillSwap.Api.Models;

namespace SkillSwap.Api.Dtos;

public record ProfileGetMatchesResponse(
    Guid PublicId,
    string Name,
    string? Bio,
    string? ImageUrl,
    ICollection<GetSkill>? Skills,
    ICollection<GetNeed>? Needs
)
{
    public static explicit operator ProfileGetMatchesResponse(Profile profile)
    {
        return new ProfileGetMatchesResponse(
            profile.PublicId,
            profile.Name,
            profile.Bio,
            profile.ImageUrl,
            profile.Skills.Select(x => new GetSkill(x.PublicId, x.TagName)).ToList(),
            profile.Needs.Select(x => new GetNeed(x.PublicId, x.TagName)).ToList()
        );
    }
}
