using System;
using System.Web;
using System.Web.Optimization;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

namespace Glimpse.Plugins.Bundling
{
    public class GlimpseBundlePluginHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
        }

        void OnBeginRequest(object sender, EventArgs e)
        {
            if (!(BundleResolver.Current is GlimpsePluginBundleResolver))
            {
                BundleResolver.Current = new GlimpsePluginBundleResolver(BundleResolver.Current);
            }
        }

        public void Dispose()
        {
        }
    }
}
