using Microsoft.Data.SqlClient;

namespace Nitrilon.DataAccess
{
    public class Repository
    {
        // The connection string to the database
        protected const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NitrilonDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private SqlConnection connection;

        public Repository()
        {
            if (!CanConnect())
            {
                throw new Exception("Can't connect to database. Try and check the connection string.");
            }
        }

        protected void CloseConnection()
        {
            if (connection != null && connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        protected SqlDataReader Execute(string query)
        {
            if (query == null) // Can also use (query is null) instead of this
            {
                throw new ArgumentNullException(nameof(query));
            }

            connection = new(connectionString);
            SqlCommand command = new(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        public bool CanConnect()
        {
            try
            {
                SqlConnection sqlConnection = new(connectionString);
                sqlConnection.Open();
                sqlConnection.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
