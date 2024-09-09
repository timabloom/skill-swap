using SkillSwap.Api.Models;

namespace SkillSwap.Api.Dtos;

public record ProfileGetResponse(
    Guid PublicId,
    string ClerkId,
    string Name,
    string? Bio,
    string? ImageUrl,
    ICollection<GetSkill>? Skills,
    ICollection<GetNeed>? Needs,
    ICollection<GetConnection>? Connections,
    GetContactInformation? ContactInformation
)
{
    public static explicit operator ProfileGetResponse(Profile profile)
    {
        return new ProfileGetResponse(
            profile.PublicId,
            profile.ClerkId,
            profile.Name,
            profile.Bio,
            profile.ImageUrl,
            profile.Skills.Select(x => new GetSkill(x.PublicId, x.TagName)).ToList(),
            profile.Needs.Select(x => new GetNeed(x.PublicId, x.TagName)).ToList(),
            profile.Connections.Select(x => new GetConnection(x.PublicId, x.IsAccepted)).ToList(),
            profile.ContactInformation == null ? null : new GetContactInformation(profile.ContactInformation.PublicId, profile.ContactInformation.Email)
        );
    }
}
