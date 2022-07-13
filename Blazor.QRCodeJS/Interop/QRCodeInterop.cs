using Blazor.QRCodeJS.Options;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using System.Text.Json;
using Blazor.QRCodeJS.Abstractions.JsonConverters;
#if NET6_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace Blazor.QRCodeJS.Interop
{
    public interface IQRCodeInterop
    {
        /// <summary>
        /// Initialises a QRCode with the provided options on the provided element.
        /// </summary>
        /// <param name="tableReference">Reference of element to add QRCode to.</param>
        /// <param name="options">Options for QRCode.</param>
        ValueTask InitialiseAsync(ElementReference tableReference, QRCodeOptions options);

        ValueTask MakeCodeAsync(ElementReference tableReference, string text);

        /// <summary>
        /// Destroys the QRCode for the provided element.
        /// </summary>
        /// <param name="tableReference">Reference of element to add QRCode to.</param>
        ValueTask DestroyAsync(ElementReference tableReference);
    }

    internal class QRCodeInterop : IQRCodeInterop
    {
        /// <summary>
        /// Runtime used by the interop.
        /// </summary>
        private readonly IJSRuntime _runtime;

        /// <summary>
        /// We need to strip null values from the options, as these are treated differently to "undefined" by QRCode.
        /// To do so, we serialize the options ourselves using the specified options.
        /// This is then deserialized in qrCodeInterop.js.
        /// </summary>
        private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
        {
#if NET6_0_OR_GREATER
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
#else
            IgnoreNullValues = true,
#endif
            PropertyNameCaseInsensitive = true,
#if DEBUG
            WriteIndented = true,
#endif
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new DiscriminatedUnionJsonConverter() }
        };

        /// <summary>
        /// Should be instantiated from service collection.
        /// </summary>
        /// <param name="runtime">The IJSRuntime to use.</param>
        public QRCodeInterop(IJSRuntime runtime)
        {
            _runtime = runtime;
        }

        /// <inheritdoc/>
        public ValueTask InitialiseAsync(ElementReference elementReference, QRCodeOptions options)
        {
            var serializedOptions = JsonSerializer.Serialize(options, SerializerOptions);

            return _runtime.InvokeVoidAsync("qrCodeInterop.initialiseQrCode", elementReference, serializedOptions);
        }

        /// <inheritdoc/>
        public ValueTask MakeCodeAsync(ElementReference qrCodeReference, string text)
            => _runtime.InvokeVoidAsync("qrCodeInterop.makeQrCode", qrCodeReference, text);


        /// <inheritdoc/>
        public ValueTask DestroyAsync(ElementReference qrCodeReference)
            => _runtime.InvokeVoidAsync("qrCodeInterop.destroyQrCode", qrCodeReference);
    }
}
