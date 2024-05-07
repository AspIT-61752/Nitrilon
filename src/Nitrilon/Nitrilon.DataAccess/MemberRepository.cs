using Microsoft.Data.SqlClient;
using Nitrilon.Entities;

namespace Nitrilon.DataAccess
{
    public class MemberRepository : Repository
    {
        public MemberRepository() : base() { }

        private const string getAllMembershipsSQL = "SELECT * FROM Memberships;";

        #region MemberMethods

        public int AddMember(Member member)
        {
            int id = default;
            string sql = default;

            try
            {
                // Add member to database
                sql = $"INSERT INTO Members (Membership, FullName, JoinDate, Email, PhoneNumber) VALUES ('{member.Membership.MembershipId}', '{member.FullName}', '{member.JoinDate.ToString("yyyy-MM-dd")}', '{member.Email}', '{member.PhoneNumber}'); SELECT SCOPE_IDENTITY();";

                SqlDataReader reader = Execute(sql);

                while (reader.Read())
                {
                    id = (int)reader.GetDecimal(0);
                }
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
                sql = $"UPDATE Members SET Membership = '{member.Membership.MembershipId}', FullName = '{member.FullName}', JoinDate = '{member.JoinDate.ToString("yyyy-MM-dd")}', Email = '{member.Email}', PhoneNumber = '{member.PhoneNumber}' WHERE Id = '{member.MemberId}'; SELECT SCOPE_IDENTITY();";

                SqlDataReader reader = Execute(sql);

                while (reader.Read())
                {
                    id = (int)reader.GetDecimal(0);
                }
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

        public List<Member> GetMembers()
        {
            List<Member> members = new();
            string sql = default;

            try
            {
                // Membership ID 2 is the active membership
                sql = $"SELECT * FROM Members;";

                List<Membership> memberships = new List<Membership>();
                memberships = GetMemberships();

                SqlDataReader memberReader = Execute(sql);

                while (memberReader.Read())
                {
                    Member tempMember = ReadMemberDataFrom(memberReader, memberships);
                    members.Add(tempMember);
                }
            }
            catch (Exception)
            {
                throw new Exception("Failed to get member(s) from database");
            }
            finally
            {
                CloseConnection();
            }

            return members;

        }

        public List<Member> GetMembersByMembership(int membershipId)
        {
            List<Member> members = new();
            string sql = default;

            try
            {
                // Membership ID 2 is the active membership
                sql = $"SELECT * FROM Members WHERE Membership = {membershipId};";

                List<Membership> memberships = new List<Membership>();
                memberships = GetMemberships();

                SqlDataReader memberReader = Execute(sql);

                while (memberReader.Read())
                {
                    Member tempMember = ReadMemberDataFrom(memberReader, memberships);
                    members.Add(tempMember);
                }
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

                List<Membership> memberships = new List<Membership>();
                memberships = GetMemberships();

                SqlDataReader memberReader = Execute(sql);

                while (memberReader.Read())
                {
                    member = ReadMemberDataFrom(memberReader, memberships);
                }
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

        private Member ReadMemberDataFrom(SqlDataReader reader, List<Membership> memberships)
        {

            int memberId = Convert.ToInt32(reader["Id"]);
            int membershipId = Convert.ToInt32(reader["Membership"]);
            Membership membershipToAdd = default;
            foreach (Membership membership in memberships)
            {
                if (membership.MembershipId == membershipId)
                {
                    membershipToAdd = membership;
                    break;
                }
            }
            string fullName = reader["FullName"].ToString();
            DateTime joinDate = Convert.ToDateTime(reader["JoinDate"].ToString());
            string email = reader["Email"].ToString();
            string phoneNumber = reader["PhoneNumber"].ToString();

            Member memberData = new(memberId, membershipToAdd, fullName, joinDate, email, phoneNumber);

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
            Membership membership = null;
            string sql = default;

            try
            {
                sql = $"SELECT * FROM Memberships WHERE Id = {id};";

                SqlDataReader reader = Execute(sql);

                while (reader.Read())
                {
                    membership = ReadMembershipDataFrom(reader);
                }
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
            List<Membership> memberships = new List<Membership>();
            string sql = default;

            try
            {
                SqlDataReader reader = Execute(getAllMembershipsSQL);

                while (reader.Read())
                {
                    Membership tempMembership = ReadMembershipDataFrom(reader);
                    memberships.Add(tempMembership);
                }
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
            int memberId = Convert.ToInt32(reader["Id"]);
            string name = reader["Name"].ToString();
            string description = reader["Description"].ToString();

            Membership membershipData = new(memberId, name, description);

            return membershipData;
        }

        #endregion

    }
}
