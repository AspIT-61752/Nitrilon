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
        public int EventRatingId { get; set; }

        //[Required]
        [ForeignKey("Event")]
        public int EventId { get; set; }

        //[Required]
        [ForeignKey("Rating")]
        public int RatingId { get; set; }

        // Navigation properties. 
        //public virtual Event Event { get; set; }
        //public virtual Rating Rating { get; set; }

        //public static List<EventRatings> dummyDB = new List<EventRatings>{
        //    new EventRatings { EventRatingId=1, EventId = 1, RatingId = 3 },
        //    new EventRatings { EventRatingId=2,EventId = 1, RatingId = 3 },
        //    new EventRatings { EventRatingId=3,EventId = 1, RatingId = 2 },
        //    new EventRatings { EventRatingId=4,EventId = 1, RatingId = 1 },
        //    new EventRatings { EventRatingId=5,EventId = 1, RatingId = 2 },
        //    new EventRatings { EventRatingId=6,EventId = 2, RatingId = 3 },
        //    new EventRatings { EventRatingId=7,EventId = 2, RatingId = 3 },
        //    new EventRatings { EventRatingId=8,EventId = 2, RatingId = 2 },
        //    new EventRatings { EventRatingId=9,EventId = 3, RatingId = 1 },
        //    new EventRatings { EventRatingId=10,EventId = 3, RatingId = 2 },
        //    new EventRatings { EventRatingId=11,EventId = 3, RatingId = 3 },
        //    new EventRatings { EventRatingId=12,EventId = 4, RatingId = 3 },
        //    new EventRatings { EventRatingId=13,EventId = 5, RatingId = 2 },
        //    new EventRatings { EventRatingId=14,EventId = 5, RatingId = 1 },
        //    new EventRatings { EventRatingId=15,EventId = 5, RatingId = 2 },
        //};

        //public static List<EventRatings> GetDummyDB()
        //{
        //    return dummyDB;
        //}

        //public static void AddNewRating(EventRatings rating, int Id)
        //{
        //    rating.EventRatingId = Id + 1;
        //    if (rating.RatingId > 3)
        //    {
        //        rating.RatingId = 3;
        //    }
        //    if (rating.RatingId < 1)
        //    {
        //        rating.RatingId = 1;
        //    }
        //    dummyDB.Add(rating);
        //}
    }
}
