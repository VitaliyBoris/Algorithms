using System;

namespace Algorithms
{
    public static class SearchHelper
    {
        public static int LinearSearch<T>(this T[] a, T x) where T : IComparable
        {
            var result = -1;

            for (var i = 0; i < a.Length; i++)
            {
                if (a[i].CompareTo(x) == 0)
                    result = i;
            }

            return result;
        }

        public static int BetterLinearSearch<T>(this T[] a, T x) where T : IComparable
        {
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i].CompareTo(x) == 0)
                    return i;
            }

            return -1;
        }

        public static int SentinelLinearSearch<T>(this T[] a, T x) where T : IComparable
        {
            var n = a.Length - 1;

            var last = a[n];
            a[n] = x;

            var i = 0;
            while (a[i].CompareTo(x) != 0)
            {
                i++;
            }

            a[n] = last;

            if (i < n || a[n].CompareTo(x) == 0)
                return i;

            return -1;
        }

        public static int BinarySearch<T>(this T[] a, T x) where T : IComparable
        {
            var p = 0;
            var r = a.Length - 1;

            while (p <= r)
            {
                var q = (p + r)/2;
                if (a[q].CompareTo(x) == 0)
                    return q;

                if (a[q].CompareTo(x) > 0)
                    r = q - 1;
                else
                    p = q + 1;
            }

            return -1;
        }
    }
}