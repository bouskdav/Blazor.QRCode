using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.QRCodeJS.Interop
{
    /// <summary>
    /// Represents a JavaScript function.
    /// </summary>
    public class JavascriptFunction
    {
        /// <summary>
        /// The namespace containing a JavaScript function.
        /// </summary>
        public string Namespace { get; }

        /// <summary>
        /// The name of the JavaScript function.
        /// </summary>
        public string Function { get; }

        /// <summary>
        /// Creates a new instance of <see cref="JavascriptFunction"/>.
        /// </summary>
        /// <param name="nameSpace">A JavaScript namespace containing the provided function (see <see cref="Namespace"/> for details).</param>
        /// <param name="function">The name of a JavaScript function (see <see cref="Function"/> for details).</param>
        public JavascriptFunction(string nameSpace, string function)
        {
            if (string.IsNullOrWhiteSpace(nameSpace))
            {
                throw new ArgumentException("Namespace for function must be provided!", nameof(nameSpace));
            }
            else if (string.IsNullOrWhiteSpace(function))
            {
                throw new ArgumentException("A function name must be provided!", nameof(function));
            }

            Namespace = nameSpace;
            Function = function;
        }

        /// <summary>
        /// Converts a string to a <see cref="JavascriptFunction"/> implicitly.
        /// </summary>
        /// <param name="methodName">The namespace and name of a JavaScript function to be called, separated by a point (see <see cref="MethodName"/> for details).</param>
        public static implicit operator JavascriptFunction(string javaScriptFunction)
        {
            var split = javaScriptFunction.Split('.');
            if (split.Length != 2)
            {
                throw new ArgumentException("Javascript function must be composed of a namespace and a function separated by a '.'", nameof(javaScriptFunction));
            }

            return new JavascriptFunction(split[0], split[1]);
        }
    }
}
