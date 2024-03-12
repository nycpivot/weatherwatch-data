using Microsoft.EntityFrameworkCore;
using WeatherWatch.Domain;

namespace WeatherWatch.Data
{
    public class WeatherDb : DbContext
    {
        // public WeatherDb(DbContextOptions<WeatherDb> options) : base(options)
        // {
        //     //var dbCreator = (RelationalDatabaseCreator)this.Database.GetService<IDatabaseCreator>();

        //     //if (!dbCreator.HasTables())
        //     //{
        //     //    dbCreator.CreateTables();
        //     //}
        // }

        // public DbSet<Favorite> Favorites { get; set; }
        // //public DbSet<Location> Locations { get; set; }
    }
}
