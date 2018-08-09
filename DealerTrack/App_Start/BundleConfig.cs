using System.Web.Optimization;

namespace DealerTrack
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Script Bundles
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/Libraries/jQuery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/Libraries/jQueryValidate/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/Libraries/Bootstrap/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                "~/Scripts/Libraries/DataTables/jquery.dataTables.min.js",
                "~/Scripts/Libraries/DataTables/dataTables.bootstrap.min.js"));
            #endregion

            #region Style Bundles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Libraries/Bootstrap/bootstrap.css",
                "~/Content/Common/site.css"));
            #endregion
        }
    }
}
