namespace MoviesSystem.Data
{
    using System.Data.Entity;

    using Migrations;
    using Models;

    public class MoviesSystemDbContext : DbContext
    {
        public MoviesSystemDbContext() 
            : base("MoviesSystemConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesSystemDbContext, Configuration>());
        }

        public IDbSet<Movie> Movies {get;set; }
    }
}
