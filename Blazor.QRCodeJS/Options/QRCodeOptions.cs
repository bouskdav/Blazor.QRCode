using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public QRErrorCorrectLevel ErrororrectLevel { get; set; }

        public static QRCodeOptions FromComponent(QRCode qrCode)
        {
            var options = qrCode.Options ?? new QRCodeOptions();

            return options;
        }
    }
}
