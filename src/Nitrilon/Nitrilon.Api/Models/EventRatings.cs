using System.ComponentModel.DataAnnotations;        // Using this namespace to use Key attribute
using System.ComponentModel.DataAnnotations.Schema; // Using this namespace to use ForeignKey attribute

namespace Nitrilon.Api.Models
{
    public class EventRatings
    {
        // int? is a nullable type in C#.                       It is used to represent a variable that can be assigned null.
        // int! is a non-nullable type in C#.                   It is used to represent a variable that cannot be assigned null.

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventRatingId { get; }

        [ForeignKey("Event")]
        public int EventId { get; }

        [ForeignKey("Rating")]
        public int RatingId { get; }

        // Navigation properties. 
        //public virtual Event Event { get; set; }
        //public virtual Rating Rating { get; set; }

    }
}
