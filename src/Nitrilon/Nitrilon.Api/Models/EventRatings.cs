using System.ComponentModel.DataAnnotations;        // Using this namespace to use Key attribute
using System.ComponentModel.DataAnnotations.Schema; // Using this namespace to use ForeignKey attribute

namespace Nitrilon.Api.Models
{
    public class EventRatings
    {
        // int? is a nullable type in C#.                       It is used to represent a variable that can be assigned null.
        // int! is a non-nullable type in C#.                   It is used to represent a variable that cannot be assigned null.

        private int eventRatingId;
        private int eventId;
        private int ratingId;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventRatingId { get; set; }

        //[Required]
        [ForeignKey("Event")]
        public int EventId
        {
            get
            {
                return eventId;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("EventId should be greater than 0.");
                }
                else
                {
                    eventId = value;
                }
            }
        }

        //[Required]
        [ForeignKey("Rating")]
        public int RatingId
        {
            get
            {
                return ratingId;
            }
            set
            {
                if (value >= 1 && value <= 3)
                {
                    ratingId = value;
                }
                else
                {
                    throw new ArgumentException("RatingId has to be between 1 and 3.");
                }
            }
        }
    }
}
