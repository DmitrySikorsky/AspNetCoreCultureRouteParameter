// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetCoreCultureRouteParameter
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
    }

    public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole();
      loggerFactory.AddDebug();

      if (hostingEnvironment.IsDevelopment())
      {
        applicationBuilder.UseDeveloperExceptionPage();
        applicationBuilder.UseDatabaseErrorPage();
        applicationBuilder.UseBrowserLink();
      }

      RequestLocalizationOptions requestLocalizationOptions = new RequestLocalizationOptions();

      requestLocalizationOptions.SupportedCultures = requestLocalizationOptions.SupportedUICultures =
        new CultureInfo[] { new CultureInfo("en"), new CultureInfo("ru"), new CultureInfo("uk") }.ToList();

      requestLocalizationOptions.RequestCultureProviders.Insert(0, new RouteValueRequestCultureProvider() { Options = requestLocalizationOptions });
      applicationBuilder.UseRequestLocalization(requestLocalizationOptions);
      applicationBuilder.UseMvc(configureRoutes =>
        {
          configureRoutes.MapRoute(name: "Default", template: "{culture}/{controller}/{action}/{id?}", defaults: new { culture = "en", controller = "Default", action = "Index" });
        }
      );
    }
  }
}