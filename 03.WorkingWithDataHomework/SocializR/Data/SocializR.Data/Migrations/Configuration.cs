namespace SocializR.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<SocializRDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SocializRDbContext context)
        {
            if(context.Users.Count() > 0)
            {
                return;
            }

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            roleManager.Create(new IdentityRole()
            {
                Name = "Admin"
            });

            roleManager.Create(new IdentityRole()
            {
                Name = "User"
            });

            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            userManager.UserValidator = new UserValidator<User>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 5,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            userManager.Create(new User()
            {
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "Administrator",
                Email = "admin@socializr.com",
                
            }, "admin");

            var adminRole = roleManager.FindByName("Admin");
            var userRole = roleManager.FindByName("User");
            var admin = userManager.FindByEmail("admin@socializr.com");

            userManager.AddToRole(admin.Id, adminRole.Name);

            for (int i = 0; i < 10; i++)
            {
                var shouts = new List<Shout>();

                for (int j = 0; j < 20; j++)
                {
                    if(j % 2 == 0)
                    {
                        shouts.Add(new Shout()
                        {
                            Content = "#fail User " + (i + 1) + " Shout " + (j + 1) + " Content"
                        });

                        continue;
                    }

                    shouts.Add(new Shout()
                    {
                        Content = "User " + (i + 1) + " Shout " + (j + 1) + " Content"
                    });
                }

                string password = "123456";

                userManager.Create(new User()
                {
                    FirstName = "User",
                    LastName = (i + 1).ToString(),
                    UserName = "user" + (i + 1),
                    Email = "user" + (i + 1) + "@socializr.com",
                    Shouts = shouts
                }, password);
            }
        }
    }
}
