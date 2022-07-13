using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.QRCodeJS.Extensions
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string str) => $"{char.ToLower(str[0])}{str[1..]}";
    }
}
