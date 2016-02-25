namespace MvcTemplate.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Common;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<MvcTemplateDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MvcTemplateDbContext context)
        {
            if(context.Users.Any())
            {
                return;
            }

            this.SeedUserRoles(context);
            this.SeedUsers(context);
        }

        private void SeedUserRoles(MvcTemplateDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            roleManager.Create(new IdentityRole() { Name = Roles.AdminRoleName });
            roleManager.Create(new IdentityRole() { Name = Roles.UsersRoleName });

            context.SaveChanges();
        }

        private void SeedUsers(MvcTemplateDbContext context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            string userPassword = "123456";
            string adminEmail = "admin@site.com";

            User admin = new User() { UserName = adminEmail, Email = adminEmail };

            userManager.Create(admin, userPassword);
            userManager.AddToRole(admin.Id, Roles.AdminRoleName);
            
            string userEmailTemplate = "user{0}@site.com";
            for (int i = 0; i < 20; i++)
            {
                string userEmail = string.Format(userEmailTemplate, i);
                User user = new User() { UserName = userEmail, Email = userEmail };
                userManager.Create(user, userPassword);
                userManager.AddToRole(user.Id, Roles.UsersRoleName);
            }

            context.SaveChanges();
        }
    }
}
