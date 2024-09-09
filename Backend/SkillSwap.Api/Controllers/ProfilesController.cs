using Microsoft.AspNetCore.Mvc;
using SkillSwap.Api.Dtos;
using SkillSwap.Api.Models;

namespace SkillSwap.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfilesController(SkillSwapContext context) : ControllerBase
{
    private readonly SkillSwapContext _context = context;
    
    [HttpPost]
    public async Task<ActionResult> CreateProfile(ProfileCreateRequest requestBody)
    {
        var profile = new Profile
        {
            PublicId = Guid.NewGuid(),
            ClerkId = requestBody.ClerkId,
            Name = requestBody.Name,
            Bio = requestBody?.Bio,
            ImageUrl = requestBody?.ImageUrl,
            Skills = requestBody?.Skills?.Select(x => new Skill { TagName = x.TagName }).ToList() ?? [],
            Needs = requestBody?.Needs?.Select(x => new Need { TagName = x.TagName }).ToList() ?? [],
            ContactInformation = new ContactInformation
            {
                Email = requestBody?.Email ?? string.Empty
            }
        };
        _context.Profiles.Add(profile);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProfile", new { profile.PublicId }, (ProfileGetResponse)profile);
    }
}
