using Blazor.QRCodeJS.Interop;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.QRCodeJS.Extensions
{
    /// <summary>
    /// Contains extension methods on the service collection class.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the services necessary for Blazor.QRCode to the service collection.
        /// </summary>
        /// <param name="services">The service collection to add to.</param>
        /// <returns>The modified service collection for method chaining.</returns>
        public static IServiceCollection AddQRCode(this IServiceCollection services)
        {
            var service = services.BuildServiceProvider().GetService<IJSRuntime>();

            if (service is null)
            {
                throw new InvalidOperationException($"Blazor.QRCodeJS requires an implementation of {typeof(IJSRuntime).FullName} to be registered in order to run.");
            }

            return services.AddTransient<IQRCodeInterop, QRCodeInterop>();
        }
    }
}
