using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Nitrilon.Entities
{
    public class Member
    {
        private int memberId;
        private Membership membership;
        private string fullName;
        private DateTime joinDate;
        private string email;
        private string phoneNumber;

        public Member(int memberId, Membership membership, string fullName, DateTime joinDate)
        {
            MemberId = memberId;
            Membership = membership;
            FullName = fullName;
            JoinDate = joinDate;
        }

        public Member(int memberId, Membership membership, string fullName, DateTime joinDate, string email, string phoneNumber)
            : this(memberId, membership, fullName, joinDate)
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// It just works
        /// </summary>
        [JsonConstructor]
        public Member() { }

        public int MemberId
        {
            get => memberId;
            set
            {
                // MemberId can't be negative
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                if (memberId != value)
                {
                    memberId = value;
                }
            }
        }

        public Membership Membership
        {
            get => membership;
            set
            {
                ArgumentNullException.ThrowIfNull(value);
                if (membership != value)
                {
                    membership = value;
                }
            }
        }

        public string FullName
        {
            get => fullName;
            set
            {
                ArgumentOutOfRangeException.ThrowIfNullOrWhiteSpace(value);
                if (fullName != value)
                {
                    fullName = value;
                }
            }
        }

        public DateTime JoinDate
        {
            get => joinDate;
            set
            {
                ArgumentNullException.ThrowIfNull(value);
                if (joinDate != value)
                {
                    joinDate = value;
                }
            }
        }

        public string Email
        {
            get => email;
            set
            {
                ArgumentNullException.ThrowIfNull(value);
                if (email != value)
                {
                    // Validate email address here. For now, just check if it contains an @ symbol.
                    //if (!value.Contains("@"))
                    //{
                    //    throw new ArgumentException("Invalid email address");
                    //}

                    // Source: https://regexr.com/3e48o
                    string regexPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"; // This is a regex pattern that matches email addresses. I got if from the link above.

                    if (!Regex.IsMatch(value, regexPattern))
                    {
                        throw new ArgumentException("Invalid email address");
                    }

                    // The maximum length of an email address (in the DB) is 128 characters
                    if (value.Length > 128)
                    {
                        throw new ArgumentException("Email address is too long");
                    }

                    email = value;
                }
            }
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                ArgumentNullException.ThrowIfNull(value);
                if (phoneNumber != value)
                {
                    // https://regex101.com/library/wZ4uU6?orderBy=RELEVANCE&search=phone
                    // https://regex101.com/r/wZ4uU6/2
                    string regexPattern = @"(?:([+]\d{1,4})[-.\s]?)?(?:[(](\d{1,3})[)][-.\s]?)?(\d{1,4})[-.\s]?(\d{1,4})[-.\s]?(\d{1,9})"; // This is a regex pattern that matches phone numbers. I got if from the link above.

                    // https://regexr.com/3c53v
                    //string regexPattern = @"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"; // This is a regex pattern that matches phone numbers. I got if from the link above.

                    // Validates the phone number using the regex pattern
                    if (!Regex.IsMatch(value, regexPattern))
                    {
                        throw new ArgumentException("Invalid phone number");
                    }

                    // Then check if the phone number is too long (16 characters)
                    if (value.Length > 16)
                    {
                        throw new ArgumentException("Phone number is too long");
                    }

                    // Validate phone number here. For now, just check if it contains only numbers and is 10 characters long.
                    //if (!value.All(char.IsDigit) || ( || value.Length <= 16))
                    //{
                    //    throw new ArgumentException("Invalid phone number");
                    //}

                    phoneNumber = value;
                }
            }
        }
    }
}
