using System.Collections.Generic;
using System.Web.Optimization;

namespace Glimpse.Plugins.Bundling
{
    public class GlimpsePluginBundleResolver : IBundleResolver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlimpsePluginBundleResolver" /> class.
        /// </summary>
        public GlimpsePluginBundleResolver(IBundleResolver resolver)
        {
            this.Resolver = resolver;
            this.RequestedBundles = new HashSet<string>();
        }

        /// <summary>
        /// Gets the virtual paths of the bundles which have been requested
        /// </summary>
        public HashSet<string> RequestedBundles { get; private set; }

        /// <summary>
        /// Gets the resolver. This defaults to the Asp.Net Mvc resolver, but could be set to
        /// another if required.
        /// </summary>
        public IBundleResolver Resolver { get; set; }

        /// <summary>
        /// Gets the bundle contents.
        /// </summary>
        /// <param name="virtualPath">The virtual path.</param>
        public IEnumerable<string> GetBundleContents(string virtualPath)
        {
            this.TryRecordRequestedBundle(virtualPath);

            return this.Resolver.GetBundleContents(virtualPath);
        }

        /// <summary>
        /// Gets the contents of the bundle straight from the underlying resolver.
        /// </summary>
        /// <param name="virtualPath">The virtual path</param>
        public IEnumerable<string> GetBundleContentsFromResolver(string virtualPath)
        {
            return this.Resolver.GetBundleContents(virtualPath);
        }

        /// <summary>
        /// Gets the bundle URL.
        /// </summary>
        /// <param name="virtualPath">The virtual path.</param>
        /// <returns></returns>
        public string GetBundleUrl(string virtualPath)
        {
            this.TryRecordRequestedBundle(virtualPath);

            return this.Resolver.GetBundleUrl(virtualPath);
        }

        /// <summary>
        /// Determines whether the specified virtual path is a bundle Url
        /// </summary>
        /// <param name="virtualPath">The virtual path to test</param>
        public bool IsBundleVirtualPath(string virtualPath)
        {
            return this.Resolver.IsBundleVirtualPath(virtualPath);
        }

        /// <summary>
        /// Records the path of the bundle which has been requested
        /// </summary>
        private void TryRecordRequestedBundle(string virtualPath)
        {
            if (RequestedBundles.Contains(virtualPath) == false)
            {
                lock (this.RequestedBundles)
                {
                    if (RequestedBundles.Contains(virtualPath) == false)
                    {
                        RequestedBundles.Add(virtualPath);
                    }
                }
            }
        }
    }
}
