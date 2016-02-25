namespace UserVoiceSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private IIdeasService ideas;

        public HomeController(IIdeasService ideas)
            : base()
        {
            this.ideas = ideas;
        }

        public ActionResult Index(int page = 1)
        {
            var ideas = this.ideas
                .All()
                .To<IdeaHomeViewModel>()
                .OrderByDescending(x => x.Votes)
                .Skip((page - 1) * 3)
                .Take(3)
                .ToList();

            return this.View(ideas);
        }

        public ActionResult Error()
        {
            return this.View();
        }
    }
}
