namespace MoviesSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<MoviesSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MoviesSystemDbContext context)
        {
            if(context.Movies.Count() > 0)
            {
                return;
            }

            var movie1 = new Movie
            {
                Title = "Hi MVC",
                Year = 2016,
                Director = "Stamat Petrov",
                LeadMaleRole = "Gosho Goshov",
                LeadFemaleRole = "Maria Petrova"
            };

            var movie2 = new Movie
            {
                Title = "Bye MVC",
                Year = 2016,
                Director = "Ivan Petrov",
                LeadMaleRole = "Tosho Goshov",
                LeadFemaleRole = "Maria Ivanova"
            };

            var movie3 = new Movie
            {
                Title = "Wow MVC",
                Year = 2016,
                Director = "Vasil Petrov",
                LeadMaleRole = "Petyr Goshov",
                LeadFemaleRole = "Anka Stamatova"
            };

            context.Movies.Add(movie1);
            context.Movies.Add(movie2);
            context.Movies.Add(movie3);

            context.SaveChanges();
        }
    }
}
