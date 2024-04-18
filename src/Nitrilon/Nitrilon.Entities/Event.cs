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
        private List<Rating> ratings;

        #endregion

        #region Properties
        public int Id
        {
            get => id;
            set
            {
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
                if (description != value)
                {
                    description = value;
                }
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="name"></param>
        /// <param name="attendees"></param>
        /// <param name="description"></param>
        /// <param name="ratings"></param>
        /// <exception cref="ArgumentNullException">If ratings is null, throw an ArgumentNullException.</exception>
        public Event(int id, DateTime date, string name, int attendees, string description/*, List<Rating> ratings*/)
        {
            Id = id;
            Date = date;
            Name = name;
            Attendees = attendees;
            Description = description;
            // this.ratings = ratings ?? throw new ArgumentNullException(nameof(ratings)); // If ratings is null, throw an ArgumentNullException.
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double GetRatingAverage()
        {
            if (ratings.Count > 0)
            {
                double average = 0.0;
                int sum = 0;
                foreach (Rating rating in ratings)
                {
                    sum += rating.RatingValue;
                }

                average = (double)sum / (double)ratings.Count;
                return average;
            }
            else
            {
                return -1.0;
            }
        }
        #endregion

    }
}
