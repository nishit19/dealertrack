using System.Web.Mvc;

namespace DealerTrack.Controllers
{
    public class ErrorController : Controller
    {
        #region Actions
        public ViewResult Index()
        {
            return View("Error");
        }
        public ViewResult NotFound()
        {
            Response.StatusCode = 404;
            return View("Error");
        }
        #endregion
    }
}