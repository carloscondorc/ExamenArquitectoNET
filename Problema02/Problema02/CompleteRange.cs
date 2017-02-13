using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema02
{
    public class CompleteRange
    {
            public int[] build(int[] rango)
        {
            List<int> result = new List<int>();
            int max = rango.Max();

            for (int i = 1; i <= max; i++) {
                result.Add(i);
            }

            return result.ToArray();
        }
}
