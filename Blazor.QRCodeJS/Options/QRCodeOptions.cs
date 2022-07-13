using Blazor.QRCodeJS.Abstractions.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.QRCodeJS.Options
{
    /// <summary>
    /// Represents QRCCode
    /// </summary>
    public class QRCodeOptions
    {
        public string Text { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public string ColorDark { get; set; }

        public string ColorLight { get; set; }

        [JsonConverter(typeof(CustomEnumDescriptionConverter<QRErrorCorrectLevel>))]
        public QRErrorCorrectLevel ErrorCorrectLevel { get; set; }

        public bool Debug { get; set; }

        public static QRCodeOptions FromComponent(QRCode qrCode)
        {
            var options = qrCode.Options ?? new QRCodeOptions()
            {
                Text = qrCode.Text,
                Height = qrCode.Height,
                Width = qrCode.Width,
                ColorDark = qrCode.ColorDark,
                ColorLight = qrCode.ColorLight,
                Debug = qrCode.Debug,
                ErrorCorrectLevel = qrCode.ErrorCorrectLevel
            };

            return options;
        }
    }
}
