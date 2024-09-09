using Microsoft.EntityFrameworkCore;
using SkillSwap.Api.Models;

public class SkillSwapContext : DbContext
{
    public SkillSwapContext(DbContextOptions<SkillSwapContext> options)
        : base(options)
    {
    }

    public DbSet<Profile> Profiles { get; set; } = default!;
    public DbSet<Need> Needs { get; set; } = default!;
    public DbSet<Skill> Skills { get; set; } = default!;
    public DbSet<ContactInformation> ContactInformations { get; set; } = default!;
    public DbSet<Connection> Connections { get; set; } = default!;
}