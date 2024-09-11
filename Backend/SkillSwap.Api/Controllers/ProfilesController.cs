using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillSwap.Api.Dtos;
using SkillSwap.Api.Models;

namespace SkillSwap.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfilesController(SkillSwapContext context) : ControllerBase
{
    private readonly SkillSwapContext _context = context;

    [HttpGet("Matches/{clerkId}")]
    public async Task<ActionResult<IEnumerable<ProfileGetMatchesResponse>>> GetMatchingProfiles(string skill, string clerkId)
    {
        var profile = await _context.Profiles
            .Include(x => x.Skills)
            .Include(x => x.Connections)
            .FirstOrDefaultAsync(x => x.ClerkId == clerkId);

        if (profile == null)
        {
            return NotFound();
        }

        var profiles = await _context.Profiles
            .Include(x => x.Skills)
            .Include(x => x.Needs)
            .Include(x => x.Connections)
            .Where(x => x.ClerkId != profile.ClerkId)
                .Where(x => x.Skills
                    .Any(s => s.TagName == skill))
                    .ToListAsync();

        var skillTags = profile.Skills
            .Select(x => x.TagName)
            .ToList();

        return profiles
            .Where(x => x.Needs != null && x.Needs
                .Any(n => skillTags
                    .Contains(n.TagName)))
                    .Where(x => x.Connections.Count == 0 || profile.Connections.Count == 0 || x.Connections
                        .Any(c => c.ProfileMatchPublicId == profile.PublicId && c.IsAccepted != true && profile.Connections
                            .Any(c => c.ProfileMatchPublicId == x.PublicId && c.IsAccepted != true)))
                            .Select(x => (ProfileGetMatchesResponse)x)
                            .ToList();
    }

    [HttpGet("Connections/{clerkId}")]
    public async Task<ActionResult<IEnumerable<ProfileGetConnectionsResponse>>> GetConnectingProfiles(string skill, string clerkId)
    {
        var profile = await _context.Profiles
            .Include(x => x.Skills)
            .Include(x => x.Connections)
            .FirstOrDefaultAsync(x => x.ClerkId == clerkId);

        if (profile == null)
        {
            return NotFound();
        }

        var profiles = await _context.Profiles
            .Include(x => x.Skills)
            .Include(x => x.Needs)
            .Include(x => x.Connections)
            .Include(x => x.ContactInformation)
                .Where(x => x.Connections
                    .Any(c => c.ProfileMatchPublicId == profile.PublicId && c.IsAccepted == true))
                .Where(x => x.Skills
                    .Any(x => x.TagName == skill))
                    .Select(x => (ProfileGetConnectionsResponse)x)
                    .ToListAsync();

        var skillTags = profile.Skills
            .Select(x => x.TagName)
            .ToList();

        return profiles
                    .Where(x => x.Needs != null && x.Needs
                        .Any(n => skillTags
                            .Contains(n.TagName)))
                    .Where(x => profile.Connections
                        .Any(c => c.ProfileMatchPublicId == x.PublicId && c.IsAccepted == true))
                        .ToList();
    }

    [HttpGet("{clerkId}")]
    public async Task<ActionResult<ProfileGetResponse>> GetProfile(string clerkId)
    {
        var profile = await _context.Profiles
            .Include(x => x.Skills)
            .Include(x => x.Needs)
            .Include(x => x.Connections)
            .Include(x => x.ContactInformation)
            .FirstOrDefaultAsync(x => x.ClerkId == clerkId);

        if (profile == null)
        {
            return NotFound();
        }
        return (ProfileGetResponse)profile;
    }

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

        return CreatedAtAction("GetProfile", new { profile.ClerkId }, (ProfileGetResponse)profile);
    }

    [HttpPost("Connections")]
    public async Task<IActionResult> ConnectToProfile(ConnectionCreateRequest requestBody)
    {
        var profile = await _context.Profiles
            .Include(x => x.Connections)
            .FirstOrDefaultAsync(x => x.ClerkId == requestBody.ClerkId);
        if (profile == null)
        {
            return NotFound("ClerkId not found");
        }

        var connection = await _context.Profiles
            .FirstOrDefaultAsync(x => x.PublicId == requestBody.ProfileMatchPublicId);
        if (connection == null)
        {
            return NotFound("ProfileMatchPublicId not found");
        }

        profile.Connections.Add(new Connection
        {
            ProfileMatchId = connection.Id,
            ProfileMatchPublicId = connection.PublicId,
            ProfileMatch = connection,
            IsAccepted = true
        });
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
