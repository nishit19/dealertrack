using System.IO;
using System.Web.Mvc;
using DealerTrack.Core.Services;
using Ninject;

namespace DealerTrack.Controllers
{
    public class BaseController : Controller
    {
        #region Service Declaration
        [Inject]
        public ApplicationService ApplicationService { get; set; }
        #endregion

        #region Controller Functions
        /// <summary>
        /// Renders partial view to string
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns>String representation of the Html</returns>
        public string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
        #endregion
    }
}