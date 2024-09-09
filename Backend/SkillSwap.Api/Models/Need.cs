using System.ComponentModel.DataAnnotations;

namespace SkillSwap.Api.Models
{
    public class Need
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid PublicId { get; set; } = Guid.NewGuid();
        [Required, MinLength(3), MaxLength(50)]
        public string TagName { get; set; } = null!;
    }
}