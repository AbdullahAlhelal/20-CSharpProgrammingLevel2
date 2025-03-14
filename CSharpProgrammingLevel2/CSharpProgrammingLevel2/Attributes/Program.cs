using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Attributes
{
    internal class Program
    {

        [Obsolete("This method is deprecated. Use NewMethod instead.")]
        public static void DeprecatedMethod()
        {
            // Deprecated method implementation
        }


        [Conditional("DEBUG")]
        public void DebugMethod()
        {
            // Code to be executed only in debug mode
        }
        static void Main(string[] args)
        {
            DeprecatedMethod();
        }
    }
}
