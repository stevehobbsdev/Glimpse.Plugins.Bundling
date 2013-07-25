using System;
using System.Web;
using System.Web.Optimization;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Glimpse.Plugins.Bundling.PluginHttpModule), "Start")]

namespace Glimpse.Plugins.Bundling
{
    public class PluginHttpModule : IHttpModule
    {
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(PluginHttpModule));
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
        }

        void OnBeginRequest(object sender, EventArgs e)
        {
            BundleResolver.Current = new GlimpsePluginBundleResolver(BundleResolver.Current);
        }

        public void Dispose()
        {
        }
    }
}
