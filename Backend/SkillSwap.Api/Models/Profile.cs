using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SkillSwap.Api.Models;

public class Profile
{
    [Key]
    public int Id { get; set; }
    [Required]
    public Guid PublicId { get; set; } = Guid.NewGuid();
    [Required]
    public string ClerkId { get; set; } = null!;
    [Required]
    public string Name { get; set; } = null!;
    [MaxLength(300)]
    public string? Bio { get; set; }
    [Required, DataType(DataType.Date)]
    public DateTime RecentActivity { get; set; } = DateTime.Now;

    public ICollection<Skill> Skills { get; set; } = [];

    public ICollection<Need> Needs { get; set; } = [];
    [Url]
    public string? ImageUrl { get; set; }

    public int ContactInformationId { get; set; }
    [NotMapped]
    public Guid ContactInformationPublicId { get; set; }
    [ForeignKey("ContactInformationId")]
    public ContactInformation? ContactInformation { get; set; }

    public ICollection<Connection> Connections { get; set; } = [];
}