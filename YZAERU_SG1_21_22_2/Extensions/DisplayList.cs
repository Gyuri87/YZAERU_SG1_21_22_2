using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YZAERU_SG1_21_22_2.Program.Extensions
{
    public static class DisplayList
    {
        public static void DisplayListToConsol<T>(this IEnumerable<T> result)
        {
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
