using System.Web.Optimization;

namespace MPD.Interviews.WebApplication
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);
            RegisterStyles(bundles);            
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/vendor/app")
                .Include("~/Scripts/jquery-1.9.1.min.js", "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/scripts/app")
                .Include("~/Scripts/app.js"));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/styles/vendor/app")
                .Include("~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/styles/app")
                .Include("~/Content/App/app.css"));
        }
    }
}