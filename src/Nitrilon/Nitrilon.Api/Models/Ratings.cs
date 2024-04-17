using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nitrilon.Api.Models
{
    public class Ratings
    {
        // Used for encapsulation.
        //private int ratingId; // Don't think this is needed, as the ID is handled by the database.
        private int ratingValue;
        private string description;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }

        [Required]
        public int RatingValue
        {
            get
            {
                return ratingValue;
            }
            set
            {
                // If the value is between 1 and 3, set the value.
                if (value >= 1 && value <= 3)
                {
                    ratingValue = value;
                }
                else
                {
                    throw new ArgumentException("RatingValue has to be between 1 and 3.");
                }
            }
        } // tinyint in SQL is 0 to 255, so a byte would probably be better, but int might be easier to work with.

        [Required]
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
    }
}
