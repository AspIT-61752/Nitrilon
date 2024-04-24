using Microsoft.Data.SqlClient;
using Nitrilon.Entities;

namespace Nitrilon.DataAccess
{
    public class Repository
    {
        // The connection string to the database
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NitrilonDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        /// <summary>
        /// POST: This method saves a new event to the database.
        /// </summary>
        /// <param name="newEvent">The event to be saved in the database.</param>
        /// <returns>The ID of the newly inserted event.</returns>
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

            try
            {
                // 3: Open the connection
                connection.Open();

                // TODO: Find a way to get the ID of the newly inserted event
                // 4: Execute the insert command and get the id of the newly inserted event
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Get the id of the newly inserted event.
                    // For some random reason, the id is returned as a decimal.
                    // So we cast it to an int and store it in the newId variable.
                    newId = (int)reader.GetDecimal(0);
                }

                // 5: Close the connection
                connection.Close();
            }
            catch (Exception excep)
            {

                Console.WriteLine(excep.Message);
            }

            return newId;
        }

        /// <summary>
        /// GET: This method retrieves an event from the database.
        /// </summary>
        /// <param name="id">The id of the event to be retrieved from the database.</param>
        /// <returns>The data retrieved from the database.</returns>
        public Event GetEvent(int id)
        {
            Event e = null;
            string sql = $"SELECT * FROM Events WHERE EventId = {id}";

            // Make a sqlConnection object
            SqlConnection connection = new SqlConnection(connectionString);

            // Make the sqlCommand object
            SqlCommand command = new SqlCommand(sql, connection);

            // Open the connection
            connection.Open();

            // Execute the command
            SqlDataReader reader = command.ExecuteReader();

            int eventId = default;
            DateTime date = default;
            string name = default;
            int attendees = default;
            string description = default;

            // Retrieve the data from the database
            while (reader.Read())
            {
                eventId = Convert.ToInt32(reader["EventId"]);
                date = Convert.ToDateTime(reader["Date"]);
                name = Convert.ToString(reader["Name"]);
                attendees = Convert.ToInt32(reader["Attendees"]);
                description = Convert.ToString(reader["Description"]);

                e = new Event(eventId, date, name, attendees, description);
            }

            if (e != null)
            {
                throw new Exception("Event not found.");
            }
            else
            {
                return e;
            }
        }

        /// <summary>
        /// GET: This method retrieves all events from the database.
        /// </summary>
        /// <returns>The data retrieved from the database.</returns>
        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();

            string sql = "SELECT * FROM Events";

            // 1: Make a sqlConnection object
            SqlConnection connection = new SqlConnection(connectionString);

            // 2: Make a sqlCommand object
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                // 3: Open the connection
                connection.Open();

                // 4. Execute the command
                SqlDataReader reader = command.ExecuteReader();

                int id = default;
                DateTime date = default;
                string name = default;
                int attendees = default;
                string description = default;

                // 5. Retrieve the data from the database
                while (reader.Read())
                {
                    try
                    {
                        id = Convert.ToInt32(reader["EventId"]);
                        date = Convert.ToDateTime(reader["Date"]);
                        name = Convert.ToString(reader["Name"]);
                        attendees = Convert.ToInt32(reader["Attendees"]);
                        description = Convert.ToString(reader["Description"]);

                        // Create a new event object and add it to the list of events
                        Event e = new(id, date, name, attendees, description);
                        events.Add(e);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

                // TODO: Ask Mads about this. How do we handle the return value if the list is empty? Does the connection close automatically if there's an exception? 
                // 6. Close the connection
                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }

            return events;
        }

        /// <summary>
        /// GET: This method retrieves all events from the database that are in the future.
        /// </summary>
        /// <returns>A list of events</returns>
        public List<Event> GetFutureEvents()
        {
            List<Event> events = new List<Event>();

            // The SQL query to get all events from the last 3 days and in the future
            string sql = "SELECT * FROM Events WHERE Date > DATEADD(DAY, -3, GETDATE())"; // This will get all events from the last 3 days and in the future.

            // 1: Make a sqlConnection object
            SqlConnection connection = new SqlConnection(connectionString);

            // 2: Make a sqlCommand object
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                // 3: Open the connection
                connection.Open();

                // 4. Execute the command
                SqlDataReader reader = command.ExecuteReader();

                int id = default;
                DateTime date = default;
                string name = default;
                int attendees = default;
                string description = default;

                // 5. Retrieve the data from the database
                while (reader.Read())
                {
                    try
                    {
                        id = Convert.ToInt32(reader["EventId"]);
                        date = Convert.ToDateTime(reader["Date"]);
                        name = Convert.ToString(reader["Name"]);
                        attendees = Convert.ToInt32(reader["Attendees"]);
                        description = Convert.ToString(reader["Description"]);

                        Event e = new(id, date, name, attendees, description);

                        events.Add(e);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

                // TODO: Ask Mads about this. How do we handle the return value if the list is empty? Does the connection close automatically if there's an exception? 
                // 6. Close the connection
                connection.Close();
            }
            catch (Exception excep)
            {

                Console.WriteLine(excep.Message);
            }


            return events;
        }

        public EventRatingData GetEventRatingDataBy(int eventId)
        {
            int badRatingCount = 0;
            int neutralRatingCount = 0;
            int goodRatingCount = 0;
            EventRatingData ratingData = default;

            string sql = $"EXEC CountAllowedRatingsForEvent @EventId = {eventId}";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                badRatingCount = Convert.ToInt32(reader["RatingBad"]);
                neutralRatingCount = Convert.ToInt32(reader["RatingAverage"]);
                goodRatingCount = Convert.ToInt32(reader["RatingGood"]);
                ratingData = new EventRatingData(badRatingCount, neutralRatingCount, goodRatingCount);
            }

            connection.Close();

            return ratingData;
        }

        /// <summary>
        /// UPDATE: This method updates an event in the database.
        /// </summary>
        /// <param name="newEvent">The new event data to be updated in the database. (It must have the same ID as the event to be updated)</param>
        public void EditEvent(Event newEvent)
        {
            // TODO: Comments
            string sql = $"UPDATE Events SET Date = '{newEvent.Date.ToString("yyyy-MM-dd")}', Name = '{newEvent.Name}', Attendees = {newEvent.Attendees}, Description = '{newEvent.Description}' WHERE EventId = {newEvent.Id}";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }

        /// <summary>
        /// POST: This method saves a new rating to the database.
        /// </summary>
        /// <param name="eventId">The id of the event to be rated.</param>
        /// <param name="ratingId">The id of the rating. (1-3)</param>
        /// <returns>The ID of the newly inserted event rating.</returns>
        public int SaveEventRating(int eventId, int ratingId)
        {
            int newId = 0;

            // TODO: Handle attendees when the event is not over
            // Remember to format the date correctly... 
            // Also remember to add '' around the date in the sql string...
            string sql = $"INSERT INTO EventRatings (EventId, RatingId) VALUES({eventId}, {ratingId});";

            // 1: Make a sqlConnection object
            SqlConnection connection = new SqlConnection(connectionString);

            // 2: Make a sqlCommand object
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                // 3: Open the connection
                connection.Open();

                // TODO: Find a way to get the ID of the newly inserted event
                // 4: Execute the insert command and get the id of the newly inserted event
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Get the id of the newly inserted event.
                    // For some random reason, the id is returned as a decimal.
                    // So we cast it to an int and store it in the newId variable.
                    newId = (int)reader.GetDecimal(0);
                }

                // 5: Close the connection
                connection.Close();
            }
            catch (Exception excep)
            {

                Console.WriteLine(excep.Message);
            }

            return newId;
        }
    }
}
