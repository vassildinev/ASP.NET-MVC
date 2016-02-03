namespace SimpleMvcApp.Controllers
{
    using System.Web.Mvc;

    using Services;

    public class StatisticsController : Controller
    {
        private readonly ProjectsService projects;

        public StatisticsController()
        {
            this.projects = new ProjectsService();
        }

        public ActionResult All()
        {
            return View(this.projects.All().Count);
        }
    }
}