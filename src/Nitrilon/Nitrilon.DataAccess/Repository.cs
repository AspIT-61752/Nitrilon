using Microsoft.Data.SqlClient;
using Nitrilon.Entities;

namespace Nitrilon.DataAccess
{
    public class Repository
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NitrilonDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();

            string sql = "SELECT * FROM Events";

            // 1: Make a sqlConnection object
            SqlConnection connection = new SqlConnection(connectionString);

            // 2: Make a sqlCommand object
            SqlCommand command = new SqlCommand(sql, connection);

            // TODO: Add a try-catch block to handle exceptions

            // 3: Open the connection
            connection.Open();

            // 4. Execute the command
            SqlDataReader reader = command.ExecuteReader();

            // 5. Retrieve the data from the database
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["EventId"]);
                DateTime date = Convert.ToDateTime(reader["Date"]);
                string name = Convert.ToString(reader["Name"]);
                int attendees = Convert.ToInt32(reader["Attendees"]);
                string description = Convert.ToString(reader["Description"]);

                Event e = new()
                {
                    Id = id,
                    Date = date,
                    Name = name,
                    Attendees = attendees,
                    Description = description
                };

                events.Add(e);
            }

            // 6. Close the connection
            connection.Close();

            return events;
        }

        public int Save(Event newEvent)
        {
            int newId = 0;

            // TODO: Handle attendees when the event is not over
            // Remember to format the date correctly... 
            // Also remember to add '' around the date in the sql string...
            string sql = $"INSERT INTO Events (Date, Name, Attendees, Description) VALUES ('{newEvent.Date.ToString("yyyy-MM-dd")}', '{newEvent.Name}', {newEvent.Attendees}, '{newEvent.Description}'); SELECT SCOPE_IDENTITY();";

            // 1: Make a sqlConnection object
            SqlConnection connection = new SqlConnection(connectionString);

            // 2: Make a sqlCommand object
            SqlCommand command = new SqlCommand(sql, connection);

            // TODO: Add a try-catch block to handle exceptions

            // 3: Open the connection
            connection.Open();

            // TODO: Find a way to get the ID of the newly inserted event
            // 4: Execute the insert command and get the id of the newly inserted event
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                // Get the id of the newly inserted event.
                // For some rndom reason, the id is returned as a decimal.
                // So we cast it to an int and store it in the newId variable.
                newId = (int)reader.GetDecimal(0);
            }

            // 5: Close the connection
            connection.Close();

            return newId;
        }
    }
}
