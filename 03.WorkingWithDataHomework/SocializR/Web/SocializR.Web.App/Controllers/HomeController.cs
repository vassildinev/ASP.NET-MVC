namespace SocializR.Web.App.Controllers
{
    using Data.Contracts;
    using Data;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;
    using Data.Models;
    using System;
    using System.Web.Caching;

    public class HomeController : Controller
    {
        private ISocializRData data = new SocializRData(new SocializRDbContext());

        public ActionResult Index()
        {
            IEnumerable<Shout> shouts = this.HttpContext.Cache.Get("failShouts") as IEnumerable<Shout>;
            if(shouts == null)
            {
                shouts = this.data.ShoutsRepository.All().Where(s => s.Content.Contains("#fail")).ToList();
                this.HttpContext.Cache.Add("failShouts", shouts, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(15), CacheItemPriority.Default, null);
            }

            return View(shouts);
        }
    }
}