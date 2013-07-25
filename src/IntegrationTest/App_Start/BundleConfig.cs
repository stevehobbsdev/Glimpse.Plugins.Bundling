using System.Web.Optimization;

namespace IntegrationTest
{
    public static class BundleConfig
    {
        public static void Configure(BundleCollection bundles)
        {
            // Used on the site
            bundles.Add(new StyleBundle("~/site/css")
                .Include("~/content/site.css"));

            // Unused bundle - test that the plugin can distinguish
            bundles.Add(new ScriptBundle("~/jquery")
                .Include("~/scripts/jquery-{version}.js"));
        }
    }
}