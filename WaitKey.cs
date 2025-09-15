using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLOOP2_L3
{
    internal class WaitKey
    {
        public static void WaitForKey()
        {
            Console.WriteLine(" Натисніть будь-яку клавішу для продовження");
            Console.ReadKey();
        }
        public static void WaitForKeyAndClear()
        {
            WaitKey.WaitForKey();
            Console.Clear();
        }
    }
}
