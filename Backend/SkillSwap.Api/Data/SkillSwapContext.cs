using Microsoft.EntityFrameworkCore;
using SkillSwap.Api.Models;

public class SkillSwapContext : DbContext
{
    public SkillSwapContext(DbContextOptions<SkillSwapContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Profile>().HasData(
            new Profile
            {
                Id = 1,
                ClerkId = "emma_w_303",
                Name = "Emma Watson",
                Bio = "Backend developer focused on building scalable and efficient server-side applications",
                ImageUrl = "https://images.pexels.com/photos/7020543/pexels-photo-7020543.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                ContactInformationId = 1,
            },
            new Profile
            {
                Id = 2,
                ClerkId = "jimmy_j_303",
                Name = "Jimmy John",
                Bio = "Graphic designer with a keen eye for branding and marketing materials",
                ImageUrl = "https://images.pexels.com/photos/8159657/pexels-photo-8159657.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                ContactInformationId = 2,
            },
            new Profile
            {
                Id = 3,
                ClerkId = "sarah_j_303",
                Name = "Sarah Johnson",
                Bio = "Data scientist with expertise in machine learning and statistical analysis",
                ImageUrl = "https://images.pexels.com/photos/4350178/pexels-photo-4350178.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                ContactInformationId = 3,
            },
            new Profile
            {
                Id = 4,
                ClerkId = "ethan_p_303",
                Name = "Ethan Patel",
                Bio = "UI developer specializing in responsive design and accessibility",
                ImageUrl = "https://images.pexels.com/photos/6652928/pexels-photo-6652928.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                ContactInformationId = 4,
            }
        );

        modelBuilder.Entity<ContactInformation>().HasData(
            new ContactInformation
            {
                Id = 1,
                Email = "emma.watson@email.com"
            },
            new ContactInformation
            {
                Id = 2,
                Email = "jimmy.john@email.com"
            },
            new ContactInformation
            {
                Id = 3,
                Email = "sarah.johnson@email.com"
            },
            new ContactInformation
            {
                Id = 4,
                Email = "ethan.patel@email.com"
            }
        );

        modelBuilder.Entity<Need>().HasData(
            new Need { Id = 1, TagName = "JavaScript", ProfileId = 1 },
            new Need { Id = 2, TagName = "CSS", ProfileId = 1 },
            new Need { Id = 3, TagName = "JavaScript", ProfileId = 2 },
            new Need { Id = 4, TagName = "HTML", ProfileId = 2 },
            new Need { Id = 5, TagName = "JavaScript", ProfileId = 3 },
            new Need { Id = 6, TagName = "CSS", ProfileId = 3 },
            new Need { Id = 7, TagName = "Python", ProfileId = 4 },
            new Need { Id = 8, TagName = "PostgreSQL", ProfileId = 4 }
        );

        modelBuilder.Entity<Skill>().HasData(
            new Skill { Id = 1, TagName = "Python", ProfileId = 1 },
            new Skill { Id = 2, TagName = "CSS", ProfileId = 1 },
            new Skill { Id = 3, TagName = "Python", ProfileId = 2 },
            new Skill { Id = 4, TagName = "HTML", ProfileId = 2 },
            new Skill { Id = 5, TagName = "Python", ProfileId = 3 },
            new Skill { Id = 6, TagName = "CSS", ProfileId = 3 },
            new Skill { Id = 7, TagName = "JavaScript", ProfileId = 4 },
            new Skill { Id = 8, TagName = "CSS", ProfileId = 4 }
        );
    }

    public DbSet<Profile> Profiles { get; set; } = default!;
    public DbSet<Need> Needs { get; set; } = default!;
    public DbSet<Skill> Skills { get; set; } = default!;
    public DbSet<ContactInformation> ContactInformations { get; set; } = default!;
    public DbSet<Connection> Connections { get; set; } = default!;
}