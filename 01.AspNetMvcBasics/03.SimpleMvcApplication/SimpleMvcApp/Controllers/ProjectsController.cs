namespace SimpleMvcApp.Controllers
{
    using Services;
    using System.Web.Mvc;

    public class ProjectsController : Controller
    {
        private readonly ProjectsService projects;

        public ProjectsController()
        {
            this.projects = new ProjectsService();
        }

        public ActionResult All()
        {
            return View(projects.All());
        }

        public ActionResult Details(int id)
        {
            if (projects.All()[id] == null)
            {
                return RedirectToAction("All");
            }

            return View(projects.All()[id]);
        }
    }
}