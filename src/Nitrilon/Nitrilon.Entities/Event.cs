using System.Text.Json.Serialization;

namespace Nitrilon.Entities
{
    public class Event
    {
        public readonly DateTime EarliestDate = new DateTime(2018, 1, 1);

        #region Fields and constants

        private int id;
        private DateTime date;
        private string name;
        private int attendees;
        private string description;
        private EventRatingData ratings;

        #endregion

        #region Properties
        public int Id
        {
            get => id;
            set
            {
                // Id can't be negative
                ArgumentOutOfRangeException.ThrowIfNegative(value);

                if (id != value) // It's faster to check if the value has changed before setting it, than to always set it.
                {
                    id = value;
                }
            }
        }

        public DateTime Date
        {
            get => date;
            set
            {
                // Date can't be earlier than EarliestDate
                ArgumentOutOfRangeException.ThrowIfLessThan(value, EarliestDate);
                if (date != value)
                {
                    date = value;
                }
            }
        }

        public string Name
        {
            get => name;
            set
            {
                // Name can't be null or empty
                ArgumentOutOfRangeException.ThrowIfNullOrWhiteSpace(value);

                if (name != value)
                {
                    name = value;
                }
            }
        }

        public int Attendees
        {
            get => attendees;
            set
            {
                // Attendees can be -1 or more
                ArgumentOutOfRangeException.ThrowIfLessThan(value, -1);

                if (attendees != value)
                {
                    attendees = value;
                }
            }
        }

        public string Description
        {
            get => description;
            set
            {
                // Description can be null or empty
                if (description != value)
                {
                    description = value;
                }
            }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// The constructor for the Event class
        /// </summary>
        /// <param name="id">The ID of the event</param>
        /// <param name="date">The date of the event</param>
        /// <param name="name">The name of the event</param>
        /// <param name="attendees">How many attendees the event has</param>
        /// <param name="description">The description of the event. CAN be null or empty</param>
        public Event(int id, DateTime date, string name, int attendees, string description)
        {
            this.id = id;
            this.date = date;
            this.name = name;
            this.attendees = attendees;
            this.description = description;
        }

        /// <summary>
        /// The overloaded constructor for the Event class
        /// </summary>
        /// <param name="id">The ID of the event</param>
        /// <param name="date">The date of the event</param>
        /// <param name="name">The name of the event</param>
        /// <param name="attendees">How many attendees the event has</param>
        /// <param name="description">The description of the event. CAN be null or empty</param>
        /// <param name="ratings">The ratings for the event</param>
        /// <exception cref="ArgumentNullException">If ratings is null, throw an ArgumentNullException.</exception>
        public Event(int id, DateTime date, string name, int attendees, string description, EventRatingData ratingsData)
            : this(id, date, name, attendees, description) // Calls the other constructor first
        {
            ratings = ratingsData;
        }

        /// <summary>
        /// It just works
        /// </summary>
        [JsonConstructor]
        public Event() { }

        #endregion

        #region Methods
        // REMOVED: GetRatingAverage method.
        // Might move it to the EventRatingData class.
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public double GetRatingAverage()
        //{
        //    if (ratings.Count > 0)
        //    {
        //        double average = 0.0;
        //        int sum = 0;
        //        foreach (EventRatingData rating in ratings)
        //        {
        //            sum += rating.RatingValue;
        //        }

        //        average = (double)sum / (double)ratings.Count;
        //        return average;
        //    }
        //    else
        //    {
        //        return -1.0;
        //    }
        //}
        #endregion

    }
}
