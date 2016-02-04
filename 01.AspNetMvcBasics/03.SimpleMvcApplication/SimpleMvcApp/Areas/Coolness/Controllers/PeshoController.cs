namespace SimpleMvcApp.Areas.Coolness.Controllers
{
    using System.Web.Mvc;

    public class PeshoController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}