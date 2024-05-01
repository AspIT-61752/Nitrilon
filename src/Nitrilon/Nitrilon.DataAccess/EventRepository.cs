using Microsoft.Data.SqlClient;
using Nitrilon.Entities;

namespace Nitrilon.DataAccess
{
    public class EventRepository : Repository
    {
        // Calls the base constructor (Repository) to check if the connection can be established
        public EventRepository() : base() { }

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
            string sql = default;

            try
            {
                sql = $"INSERT INTO Events (Date, Name, Attendees, Description) VALUES ('{newEvent.Date.ToString("yyyy-MM-dd")}', '{newEvent.Name}', {newEvent.Attendees}, '{newEvent.Description}'); SELECT SCOPE_IDENTITY();";

                // TODO: Find a way to get the ID of the newly inserted event
                // 4: Execute the insert command and get the id of the newly inserted event
                SqlDataReader reader = Execute(sql);
                while (reader.Read())
                {
                    // Get the id of the newly inserted event.
                    // For some random reason, the id is returned as a decimal.
                    // So we cast it to an int and store it in the newId variable.
                    newId = (int)reader.GetDecimal(0);
                }
                // If the connection is open, close it.
                CloseConnection();
            }
            catch (Exception excep)
            {
                // TODO: Handle the exception
            }
            finally
            {
                // 5: Close the connection
                CloseConnection();
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
            string sql = default;

            try
            {
                sql = $"SELECT * FROM Events WHERE EventId = {id}";

                // Execute query
                SqlDataReader reader = Execute(sql);

                int eventId = default;
                DateTime date = default;
                string name = default;
                int attendees = default;
                string description = default;

                // Retrieve the data from data reader
                while (reader.Read())
                {
                    eventId = Convert.ToInt32(reader["EventId"]);
                    date = Convert.ToDateTime(reader["Date"]);
                    name = Convert.ToString(reader["Name"]);
                    attendees = Convert.ToInt32(reader["Attendees"]);
                    description = Convert.ToString(reader["Description"]);

                    e = new Event(eventId, date, name, attendees, description);
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
                // Close the connection
                CloseConnection();
            }

            return e;
        }

        /// <summary>
        /// GET: This method retrieves all events from the database.
        /// </summary>
        /// <returns>The data retrieved from the database.</returns>
        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();
            string sql = default;
            SqlConnection connection = default;

            try
            {
                sql = "SELECT * FROM Events";

                // 4. Execute the command
                SqlDataReader reader = Execute(sql);

                int id = default;
                DateTime date = default;
                string name = default;
                int attendees = default;
                string description = default;

                // 5. Retrieve the data from the database
                while (reader.Read())
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
                // If the connection is open, close it.
                CloseConnection();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // If the connection is open, close it.
                CloseConnection();
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
            string sql = default;

            try
            {
                // The SQL query to get all events from the last 3 days and in the future
                sql = "SELECT * FROM Events WHERE Date > DATEADD(DAY, -3, GETDATE())"; // This will get all events from the last 3 days and in the future.
                // 4. Execute the command
                SqlDataReader reader = Execute(sql);

                int id = default;
                DateTime date = default;
                string name = default;
                int attendees = default;
                string description = default;

                // 5. Retrieve the data from the database
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["EventId"]);
                    date = Convert.ToDateTime(reader["Date"]);
                    name = Convert.ToString(reader["Name"]);
                    attendees = Convert.ToInt32(reader["Attendees"]);
                    description = Convert.ToString(reader["Description"]);

                    Event e = new(id, date, name, attendees, description);

                    events.Add(e);
                }
                // If the connection is open, close it.
                CloseConnection();
            }
            catch (Exception excep)
            {
                throw;
            }
            finally
            {
                // If the connection is open, close it.
                CloseConnection();
            }


            return events;
        }

        /// <summary>
        /// Gets the rating data for a specific event
        /// </summary>
        /// <param name="eventId">The ID of the event to get the rating data for</param>
        /// <returns>The rating data for the event</returns>
        public EventRatingData GetEventRatingDataBy(int eventId)
        {
            int badRatingCount = 0;
            int neutralRatingCount = 0;
            int goodRatingCount = 0;

            string sql = default;
            EventRatingData ratingData = default;

            try
            {
                sql = $"EXEC CountAllowedRatingsForEvent @EventId = {eventId}";

                SqlDataReader reader = Execute(sql);

                while (reader.Read())
                {
                    badRatingCount = Convert.ToInt32(reader["RatingBad"]);
                    neutralRatingCount = Convert.ToInt32(reader["RatingAverage"]);
                    goodRatingCount = Convert.ToInt32(reader["RatingGood"]);
                    ratingData = new EventRatingData(badRatingCount, neutralRatingCount, goodRatingCount);
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
                // If the connection is open, close it.
                CloseConnection();
            }

            return ratingData;
        }

        /// <summary>
        /// UPDATE: This method updates an event in the database.
        /// </summary>
        /// <param name="newEvent">The new event data to be updated in the database. (It must have the same ID as the event to be updated)</param>
        public void EditEvent(Event newEvent)
        {
            string sql = default;

            try
            {
                sql = $"UPDATE Events SET Date = '{newEvent.Date.ToString("yyyy-MM-dd")}', Name = '{newEvent.Name}', Attendees = {newEvent.Attendees}, Description = '{newEvent.Description}' WHERE EventId = {newEvent.Id}";

                // Execute the command (Update the event)
                SqlDataReader reader = Execute(sql);
                // If the connection is open, close it.
                CloseConnection();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // Close the connection if it's open
                CloseConnection();
            }
        }

        /// <summary>
        /// POST: This method saves a new rating to the database.
        /// </summary>
        /// <param name="eventId">The id of the event to be rated.</param>
        /// <param name="ratingId">The id of the rating. (1-3)</param>
        /// <returns>The ID of the newly inserted event rating.</returns>
        public int SaveEventRating(int eventId, int ratingId)
        {
            int newId = default;
            string sql = default;

            try
            {
                // TODO: Handle attendees when the event is not over
                // Remember to format the date correctly... 
                // Also remember to add '' around the date in the sql string...
                sql = $"INSERT INTO EventRatings (EventId, RatingId) VALUES({eventId}, {ratingId});";

                // 4: Execute the insert command and get the id of the newly inserted event
                SqlDataReader reader = Execute(sql);
                while (reader.Read())
                {
                    // Get the id of the newly inserted event.
                    // For some random reason, the id is returned as a decimal.
                    // So we cast it to an int and store it in the newId variable.
                    newId = (int)reader.GetDecimal(0);
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
                // Close the connection
                CloseConnection();
            }

            return newId;
        }
    }
}
