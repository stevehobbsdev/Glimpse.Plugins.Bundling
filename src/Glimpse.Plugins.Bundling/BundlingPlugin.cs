using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Tab.Assist;

namespace Glimpse.Plugins.Bundling
{
    /// <summary>
    /// A plugin for Glimpse which allows the programmer to view and diagnose MVC bundling configuration.
    /// </summary>
    public class BundlingPlugin : TabBase
    {
        /// <summary>
        /// Gets the name of the tab
        /// </summary>
        public override string Name
        {
            get { return "Bundling"; }
        }

        /// <summary>
        /// Specifies when this plugin should be executed
        /// </summary>
        public override RuntimeEvent ExecuteOn
        {
            get
            {
                return RuntimeEvent.EndRequest;
            }
        }

        /// <summary>
        /// Gets the data for the plugin display.
        /// </summary>
        /// <param name="context">The tab cotext instance</param>
        public override object GetData(ITabContext context)
        {
            var plugin = Plugin.Create("Virtual Path", "Contents", "Type", "Orderer", "Transforms", "Cdn");

            foreach (var bundle in BundleTable.Bundles.OrderBy(c => c.Path))
            {
                bool wasIncluded = false;
                IEnumerable<string> bundleContents;

                if (BundleResolver.Current is GlimpsePluginBundleResolver)
                {
                    var resolver = (GlimpsePluginBundleResolver)BundleResolver.Current;

                    wasIncluded = resolver.RequestedBundles.Contains(bundle.Path);
                    bundleContents = resolver.GetBundleContentsFromResolver(bundle.Path);
                }
                else
                {
                    bundleContents = BundleResolver.Current.GetBundleContents(bundle.Path);
                }

                plugin.AddRow()
                    .Column(bundle.Path)
                    .Column(bundleContents)
                    .Column(bundle.GetType().Name)
                    .Column(bundle.Orderer.GetType().Name)
                    .Column(string.Join(", ", bundle.Transforms.Select(t => t.GetType().Name).ToArray()))
                    .Column(bundle.CdnPath)
                    .SelectedIf(wasIncluded);
            }

            return plugin;
        }
    }
}
