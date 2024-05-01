using Microsoft.Data.SqlClient;
using Nitrilon.Entities;

namespace Nitrilon.DataAccess
{
    public class MemberRepository : Repository
    {
        public MemberRepository() : base() { }

        #region MemberMethods

        public int AddMember(Member member)
        {
            int id = default;
            string sql = default;

            try
            {
                // Add member to database
                sql = $"INSERT INTO Members (Membership, FullName, JoinDate, Email, PhoneNumber) VALUES ('{member.Membership.MembershipId}', '{member.FullName}', '{member.JoinDate.ToString("yyyy-MM-dd")}', {member.Email}, {member.PhoneNumber}); SELECT SCOPE_IDENTITY();";

                SqlDataReader reader = Execute(sql);

                while (reader.Read())
                {
                    id = (int)reader.GetDecimal(0);
                }

                // If the connection is open, close it.
                CloseConnection();
            }
            catch (Exception)
            {
                throw new Exception("Failed to add member to database");
            }
            finally
            {
                CloseConnection();
            }

            return id;
        }

        public int UpdateMember(Member member)
        {
            int id = default;
            string sql = default;

            try
            {
                // Update member in database, the MemberId is used to identify the member
                sql = $"UPDATE Members SET Membership = '{member.Membership.MembershipId}', FullName = '{member.FullName}', JoinDate = '{member.JoinDate.ToString("yyyy-MM-dd")}', Email = {member.Email}, PhoneNumber = {member.PhoneNumber} WHERE Id = {member.MemberId}; SELECT SCOPE_IDENTITY();";

                SqlDataReader reader = Execute(sql);

                while (reader.Read())
                {
                    id = (int)reader.GetDecimal(0);
                }

                // If the connection is open, close it.
                CloseConnection();
            }
            catch (Exception)
            {
                throw new Exception("Failed to update member in database");
            }
            finally
            {
                CloseConnection();
            }

            return id;
        }

        public int RemoveMemberBy(int memberId)
        {
            int id = default;
            string sql = default;

            try
            {
                sql = $"DELETE FROM Members WHERE Id = {memberId}; SELECT SCOPE_IDENTITY();";

                SqlDataReader reader = Execute(sql);

                while (reader.Read())
                {
                    id = (int)reader.GetDecimal(0);
                }

                // Close the connection if it's open
                CloseConnection();
            }
            catch (Exception)
            {
                throw new Exception("Failed to delete member from database");
            }
            finally
            {
                CloseConnection();
            }

            return id;
        }

        public List<Member> GetMembersByMembership(int membershipId)
        {
            List<Member> members = new();
            string sql = default;

            try
            {
                // Membership ID 2 is the active membership
                sql = $"SELECT * FROM Members WHERE Membership = {membershipId};";

                SqlDataReader reader = Execute(sql);

                while (reader.Read())
                {
                    members.Add(ReadMemberDataFrom(reader));
                }

                // Close the connection if it's open
                CloseConnection();
            }
            catch (Exception)
            {
                throw new Exception("Failed to get active member(s) from database");
            }
            finally
            {
                CloseConnection();
            }

            return members;
        }

        public Member GetMemberBy(int memberId)
        {
            Member member = default;
            string sql = default;

            try
            {
                // Get member from database by memberId
                sql = $"SELECT * FROM Members WHERE Id = {memberId};";

                SqlDataReader reader = Execute(sql);

                while (reader.Read())
                {
                    member = ReadMemberDataFrom(reader);
                }

                // If the connection is open, close it.
                CloseConnection();
            }
            catch (Exception)
            {
                throw new Exception("Failed to get member from database");
            }
            finally
            {
                CloseConnection();
            }

            return member;
        }

        private Member ReadMemberDataFrom(SqlDataReader reader)
        {
            Member memberData = default;

            memberData.MemberId = Convert.ToInt32(reader["Id"]);
            memberData.Membership = new Membership(Convert.ToInt32(reader["Membership"]), "", ""); // Should I also get the name and description of the membership?
            memberData.FullName = reader["FullName"].ToString();
            memberData.JoinDate = Convert.ToDateTime(reader["JoinDate"]);
            memberData.Email = reader["Email"].ToString();
            memberData.PhoneNumber = reader["PhoneNumber"].ToString();

            return memberData;
        }


        #endregion

        #region MembershipMethods

        public int AddMembership(Membership membership)
        {
            int id = default;
            string sql = default;

            try
            {
                sql = $"INSERT INTO Memberships (Name, Description) VALUES ('{membership.Name}', '{membership.Description}');";

                SqlDataReader reader = Execute(sql);

                while (reader.Read())
                {
                    id = (int)reader.GetDecimal(0);
                }

                // If the connection is open, close it.
                CloseConnection();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                CloseConnection();
            }

            return id;
        }

        public Membership GetMembershipBy(int id)
        {
            Membership membership = default;
            string sql = default;

            try
            {
                sql = $"SELECT * FROM Memberships WHERE Id = {id};";

                SqlDataReader reader = Execute(sql);

                while (reader.Read())
                {
                    ReadMembershipDataFrom(reader);
                }

                // If the connection is open, close it.
                CloseConnection();
            }
            catch (Exception)
            {
                throw new Exception("Failed to get membership from Database");
            }
            finally
            {
                CloseConnection();
            }

            return membership;
        }

        public List<Membership> GetMemberships()
        {
            List<Membership> memberships = new();
            string sql = default;

            try
            {
                sql = "SELECT * FROM Memberships;";
                SqlDataReader reader = Execute(sql);

                while (reader.Read())
                {
                    memberships.Add(ReadMembershipDataFrom(reader));
                }

                // If the connection is open, close it.
                CloseConnection();
            }
            catch (Exception)
            {
                throw new Exception("Failed to get membership(s) from database");
            }
            finally
            {
                CloseConnection();
            }

            return memberships;
        }

        private Membership ReadMembershipDataFrom(SqlDataReader reader)
        {
            Membership membershipData = default;

            membershipData.MembershipId = Convert.ToInt32(reader["Id"]);
            membershipData.Name = reader["Name"].ToString();
            membershipData.Description = reader["Description"].ToString();

            return membershipData;
        }

        #endregion

    }
}
