namespace BitCalculator.Controllers
{
    using ViewModels;
    using System.Web.Mvc;
    using System.Numerics;

    public class BitCalculatorController : Controller
    {
        public ActionResult Index()
        {
            if (TempData["bits"] == null)
            {
                return View(BigInteger.One);
            }

            BigInteger result = BigInteger.Parse((string)TempData["bits"]);

            return View(result);
        }

        [HttpPost]
        public ActionResult Post(Info info)
        {
            BigInteger bits = info.Quantity;
            switch (info.Type)
            {
                case "b":
                    break;
                case "B":
                    bits *= 8;
                    break;
                case "Kb":
                    bits *= 1024;
                    break;
                case "KB":
                    bits *= (8 * 1024);
                    break;
                case "Mb":
                    bits *= (1024 * 1024);
                    break;
                case "MB":
                    bits *= (8 * 1024 * 1024);
                    break;
                case "Gb":
                    bits *= (1024 * 1024 * 1024);
                    break;
                case "GB":
                    bits = bits * 8 * 1024 * 1024 * 1024;
                    break;
                case "Tb":
                    bits = bits * 1024 * 1024 * 1024 * 1024;
                    break;
                case "TB":
                    bits = bits * 8 * 1024 * 1024 * 1024 * 1024;
                    break;
                case "Pb":
                    bits = bits * 1024 * 1024 * 1024 * 1024 * 1024;
                    break;
                case "PB":
                    bits = bits * 8 * 1024 * 1024 * 1024 * 1024 * 1024;
                    break;
                case "Eb":
                    bits = bits * 1024 * 1024 * 1024 * 1024 * 1024 * 1024;
                    break;
                case "EB":
                    bits = bits * 8 * 1024 * 1024 * 1024 * 1024 * 1024 * 1024;
                    break;
                case "Zb":
                    bits = bits * 1024 * 1024 * 1024 * 1024 * 1024 * 1024 * 1024;
                    break;
                case "ZB":
                    bits = bits * 8 * 1024 * 1024 * 1024 * 1024 * 1024 * 1024 * 1024;
                    break;
                case "Yb":
                    bits = bits * 1024 * 1024 * 1024 * 1024 * 1024 * 1024 * 1024 * 1024;
                    break;
                case "YB":
                    bits = bits * 8 * 1024 * 1024 * 1024 * 1024 * 1024 * 1024 * 1024 * 1024;
                    break;
                default:
                    break;
            }

            TempData["bits"]= bits.ToString();
            return RedirectToAction("Index");
        }
    }
}