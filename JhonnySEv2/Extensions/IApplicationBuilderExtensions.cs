using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace JhonnySEv2.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        /// <summary>
        /// Sets the default culture that will be used by the application
        /// </summary>
        /// <param name="culture">The culture settings you want. Default value is "sv-SE"</param>
        /// <remarks>This is a remarkfield !</remarks>
        public static IApplicationBuilder UseCultureSettings(this IApplicationBuilder app, string culture = "sv-SE")
        {
            var options = new CultureOptions 
            { 
                Culture = culture
            };
            
            SetCultureOptions(ref app, options);
           
            return app;
        }

        public static IApplicationBuilder UseCultureSettings(this IApplicationBuilder app, Action<CultureOptions> cultureOptions)
        {
            var options = new CultureOptions();
            cultureOptions(options);

            SetCultureOptions(ref app, options);

            return app;
        }

        private static IApplicationBuilder SetCultureOptions(ref IApplicationBuilder app, CultureOptions options)
        {
            var cultureInfo = new CultureInfo(options.Culture);

            CultureInfo.DefaultThreadCurrentCulture = options.DefaultThreadCurrentCulture ?? cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = options.DefaultThreadCurrentCulture ?? cultureInfo;

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(cultureInfo),
                SupportedCultures = options.SupportedCultures ?? new List<CultureInfo>
                {
                    cultureInfo
                },
                SupportedUICultures = options.SupportedUICultures ?? new List<CultureInfo>
                {
                    cultureInfo
                }
            });

            return app;
        }
        public class CultureOptions
        {
            private const string DefaultCulture = "sv-SE";
            public string Culture { get; set; } = DefaultCulture;
            public CultureInfo CultureInfo { get; set; }
            public CultureInfo DefaultThreadCurrentCulture { get; set; }
            public CultureInfo DefaultThreadCurrentUICulture { get; set; }
            public IList<CultureInfo> SupportedCultures { get; set; }
            public IList<CultureInfo> SupportedUICultures { get; set; }
        }
    }
}
