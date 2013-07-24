using System;
using System.Diagnostics;
using System.Web;
using System.Web.Optimization;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Freelancer.Plugins.Glimpse.PluginHttpModule), "Start")]

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
            context.BeginRequest += OnEndRequest;
            context.EndRequest += OnBeginRequest;
        }

        void OnBeginRequest(object sender, EventArgs e)
        {
            BundleResolver.Current = new GlimpsePluginBundleResolver(BundleResolver.Current);
        }

        void OnEndRequest(object sender, EventArgs e)
        {
        }

        public void Dispose()
        {
        }
    }
}
