using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSwap.Api.Models
{
    public class Connection
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid PublicId { get; set; } = Guid.NewGuid();
        [Required]
        public int ProfileMatchId { get; set; }
        [Required]
        public Guid ProfileMatchPublicId { get; set; }
        [ForeignKey("ProfileMatchId")]
        public Profile ProfileMatch { get; set; } = null!;
        [Required]
        public bool IsAccepted { get; set; } = false;
    }
}