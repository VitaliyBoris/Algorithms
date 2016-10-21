using System.Collections.Generic;

namespace Algorithms
{
    public class ArrayHelper
    {
        public static int[] Intersect(int[] a, int[] b)
        {
            var i = 0;
            var j = 0;

            var n = a.Length - 1;
            var m = b.Length - 1;

            var c = new List<int>();

            while (i < a.Length && j < b.Length)
            {
                while (i < a.Length && a[i] < b[j])
                {
                    ++i;
                }
                if (i == a.Length)
                    break;

                if (a[i] == b[j])
                {
                    c.Add(a[i]);
                    ++i;
                }
                if (a[i] > b[j])
                {
                    while (j < b.Length && a[i] > b[j])
                    {
                        ++j;
                    }
                    if (j == b.Length)
                        break;

                    if (a[i] == b[j])
                    {
                        c.Add(b[j]);
                        ++j;
                    }
                }
            }

            return c.ToArray();
        }
    }
}