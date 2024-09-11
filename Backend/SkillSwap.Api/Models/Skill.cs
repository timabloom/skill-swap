using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSwap.Api.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid PublicId { get; set; } = Guid.NewGuid();
        public int ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public Profile? Profile { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string TagName { get; set; } = null!;
    }
}