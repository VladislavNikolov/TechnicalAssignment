namespace TA.MVC.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        public ActionResult DisplayError()
        {
            return View();
        }
    }
}