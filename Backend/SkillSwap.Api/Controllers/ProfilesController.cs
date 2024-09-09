using Microsoft.AspNetCore.Mvc;

namespace SkillSwap.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfilesController(SkillSwapContext context) : ControllerBase
{
    private readonly SkillSwapContext _context = context;
}
