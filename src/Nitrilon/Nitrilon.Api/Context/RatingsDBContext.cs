using Microsoft.EntityFrameworkCore;
using Nitrilon.Api.Models;

namespace Nitrilon.Api.Context
{
    // DbContext is a class provided by Entity Framework Core that represents a session with the database, allowing us to query and save instances of our entities.
    // For mroe info: https://learn.microsoft.com/en-us/dotnet/api/system.data.entity.dbcontext?view=entity-framework-6.2.0
    public class RatingsDBContext : DbContext
    {
        public DbSet<Ratings> Ratings { get; set; }
        public DbSet<Events> Events { get; set; }
    }
}
