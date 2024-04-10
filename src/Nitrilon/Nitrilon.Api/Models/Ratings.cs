using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nitrilon.Api.Models
{
    public class Ratings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }

        [Required]
        public int RatingValue { get; set; } // tinyint in SQL is 0 to 255, so a byte would probably be better, but int might be easier to work with.

        [Required]
        public string Description { get; set; }
    }
}
