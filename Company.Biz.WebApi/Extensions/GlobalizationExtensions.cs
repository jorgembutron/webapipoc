using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace Company.Biz.WebApi.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class GlobalizationExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureLocalization(this IApplicationBuilder app)
        {
            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("es-MX"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                // This line will override OS Country or Region setting.
                DefaultRequestCulture = new RequestCulture("en-US"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures,
            });
        }
    }
}
