using System.ComponentModel.DataAnnotations;

namespace SkillSwap.Api.Models
{
    public class ContactInformation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid PublicId { get; set; } = Guid.NewGuid();
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
    }
}