Glimpse.Plugins.Bundling
========================

A plugin for Glimpse which exposes Asp.Net MVC Bundles and whether they were used on the current page request.

Install through Nuget:
---------------

    Install-Package Glimpse.Plugins.Bundling

The plugin simply shows which bundles have been created and what their contents are. You can also see which transforms are in use, the CDN path (if any) and
what Orderer instance is being used.

It is also possible to see which bundles have actually been included on the current page. These bundles are highlighed in green.

No boilerplate code is necessary - simply install the package through Nuget, and rebuild.

![Plugin Screenshot](https://raw.github.com/elkdanger/Glimpse.Plugins.Bundling/master/media/screenshot.jpg)
