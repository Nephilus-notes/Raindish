using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raindish.Models
{
    public class Song
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string? Title { get; set; }
        [Display(Name = "Prod Rec")]
        [Required]
        public Boolean ProductionRecording { get; set; }
        [Display(Name = "Old Names")]
        public string? OldNames { get; set; }
        [RegularExpression(@"^[A-G]\s+[A-Za-z]*$"), StringLength(7), Required]
        public string? Key { get; set; }
        public int? Tempo { get; set; }
        [DataType(DataType.Time)]
        public DateTime? Duration { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), Required, StringLength(30)]
        public string? Genre { get; set; }
        [Display(Name = "Written on:"), DataType(DataType.Date)]
        public DateTime? Written { get; set; }    }
}
