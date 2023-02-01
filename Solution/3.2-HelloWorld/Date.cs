// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

namespace HelloWorld
{
    /// <summary>
    /// temp.
    /// </summary>
    public class Date
    {
        /// <summary>
        /// temp.
        /// </summary>
        /// <param name="year"> the year. </param>
        /// <returns> bool. </returns>
        public static bool IsLeap(double year)
        {
            if (year % 4 == 0)
            {
                return true;
            }
            return false;
        }
    }
}
