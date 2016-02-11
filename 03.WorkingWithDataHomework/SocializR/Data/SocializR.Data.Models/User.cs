namespace SocializR.Data.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        private ICollection<Shout> shouts;

        public User()
        {
            this.shouts = new HashSet<Shout>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Shout> Shouts
        {
            get { return this.shouts; }
            set { this.shouts = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public override string ToString()
        {
            return this.UserName + " - " + this.FirstName + " " + this.LastName;
        }
    }
}
