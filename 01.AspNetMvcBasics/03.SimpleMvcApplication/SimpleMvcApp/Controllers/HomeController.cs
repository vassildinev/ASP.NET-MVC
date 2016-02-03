namespace SimpleMvcApp.Controllers
{
    using ViewModels;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View(new AboutViewModel { Title = "About", Message = "I am the about page" });
        }

        public ActionResult Contact()
        {
            return View(new ContactViewModel { FirstName = "Pesho", LastName = "Peshov", PhoneNumber = "0888888" });
        }
    }
}