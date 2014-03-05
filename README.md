Glimpse.Plugins.Bundling
========================

A plugin for Glimpse which exposes Asp.Net MVC Bundles and whether they were used on the current page request.

Install through Nuget:
---------------

    Install-Package Glimpse.Plugins.Bundling

The plugin simply shows which bundles have been created and what their contents are. You can also see which transforms are in use, the CDN path (if any) and
what Orderer instance is being used.

No boilerplate code is necessary - simply install the package through Nuget, and rebuild.

![Plugin Screenshot](https://raw.github.com/elkdanger/Glimpse.Plugins.Bundling/master/media/screenshot.jpg)

Viewing included Bundles
------------------------
The bundles that have been included and used on the current page can be viewed (seen highlighted in green in the screenshot above) by registering a HTTP handler, as follows:

	<modules>
		<add name="Glimpse" type="Glimpse.AspNet.HttpModule, Glimpse.AspNet" preCondition="integratedMode" />
		
		<!-- Register this handler to view process bundles on the page -->
		<add name="GlimpseBundlePluginHttpModule" type="Glimpse.Plugins.Bundling.GlimpseBundlePluginHttpModule, Glimpse.Plugins.Bundling" preCondition="integratedMode" />
	</modules>