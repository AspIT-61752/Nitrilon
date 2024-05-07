using System.Text.Json.Serialization;

namespace Nitrilon.Entities
{
    public class Membership
    {
        private int membershipId;
        private string name;
        private string description;

        public Membership(int membershipId, string name, string description)
        {
            MembershipId = membershipId;
            Name = name;
            Description = description;
        }

        /// <summary>
        /// It just works
        /// </summary>
        [JsonConstructor]
        public Membership() { }

        public int MembershipId
        {
            get => membershipId;
            set
            {
                // MembershipId can't be negative
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                if (membershipId != value)
                {
                    membershipId = value;
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
                if (value.Length > 128)
                {
                    throw new ArgumentOutOfRangeException("Name is too long");
                }

                if (name != value)
                {
                    name = value;
                }
            }
        }
        public string Description
        {
            get => description;
            set
            {
                // Description can be null or empty
                ArgumentOutOfRangeException.ThrowIfNullOrWhiteSpace(value);
                if (description != value)
                {
                    description = value;
                }
            }
        }
    }
}
