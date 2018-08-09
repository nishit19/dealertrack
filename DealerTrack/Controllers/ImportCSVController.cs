using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DealerTrack.Models.ImportCSV;

namespace DealerTrack.Controllers
{
    public class ImportCSVController : BaseController
    {
        #region Actions
        /// <summary>
        /// Default Action
        /// </summary>
        /// <returns>Default View</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Import CSV File
        /// </summary>
        /// <param name="flDealerDetails"></param>
        /// <returns>List of deal detail</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HttpPostedFileBase flDealerDetails)
        {
            var dealViewModel = new DealViewModel();
            try
            {
                //check if the model state is valid
                if (ModelState.IsValid)
                {
                    var csvReader = new StreamReader(flDealerDetails.InputStream, Encoding.Default, true);
                    var lstDealDetails = ApplicationService.DealDetailsRepository.GetDealDataFromCsv(csvReader);
                    var dealGridViewModel = new DealGridViewModel()
                    {
                        DealDetails = lstDealDetails
                    };

                    dealViewModel.DealGrid =
                        RenderPartialViewToString("~/Views/ImportCsv/DealGrid.cshtml", dealGridViewModel);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "ImportCSV", "Index"));
            }
            finally
            {
                GC.Collect();
            }

            return View(dealViewModel);
        }
        #endregion
    }
}