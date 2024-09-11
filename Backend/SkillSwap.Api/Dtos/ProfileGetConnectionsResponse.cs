using SkillSwap.Api.Models;

namespace SkillSwap.Api.Dtos;

public record ProfileGetConnectionsResponse(
    Guid PublicId,
    string Name,
    string? Bio,
    string? ImageUrl,
    ICollection<GetSkill>? Skills,
    ICollection<GetNeed>? Needs,
    GetContactInformation? ContactInformation
)
{
    public static explicit operator ProfileGetConnectionsResponse(Profile profile)
    {
        return new ProfileGetConnectionsResponse(
            profile.PublicId,
            profile.Name,
            profile.Bio,
            profile.ImageUrl,
            profile.Skills.Select(x => new GetSkill(x.PublicId, x.TagName)).ToList(),
            profile.Needs.Select(x => new GetNeed(x.PublicId, x.TagName)).ToList(),
            profile.ContactInformation != null ? new GetContactInformation(profile.ContactInformation.PublicId, profile.ContactInformation.Email) : null
        );
    }
}
