using System.ComponentModel;

namespace Blazor.QRCodeJS
{
    public enum QRErrorCorrectLevel
    {
        [Description("QRCode.CorrectLevel.L")] L,
        [Description("QRCode.CorrectLevel.M")] M,
        [Description("QRCode.CorrectLevel.Q")] Q,
        [Description("QRCode.CorrectLevel.H")] H
    }
}
