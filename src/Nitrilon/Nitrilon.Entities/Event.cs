namespace Nitrilon.Entities
{
    public class Event
    {
        public readonly DateTime EarliestDate = new DateTime(2018, 1, 1);

        #region MyRegion

        private int id;
        private DateTime date;
        private string name;
        private int attendees;
        private string description;

        #endregion

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="name"></param>
        /// <param name="attendees"></param>
        /// <param name="description"></param>
        public Event(int id, DateTime date, string name, int attendees, string description)
        {
            Id = id;
            Date = date;
            Name = name;
            Attendees = attendees;
            Description = description;
        }

    }
}
