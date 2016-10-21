using System;
using System.Reflection;

namespace Algorithms
{
    public static class SortHelper
    {
        #region BubbleSort

        public static void BubbleSort<T>(T[] a) where T : struct, IComparable
        {
            var length = a.Length;

            for (var i = 0; i < length; i++)
            {
                for (var j = i + 1; j < length; j++)
                {
                    if (a[i].CompareTo(a[j]) > 0)
                    {
                        var temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }

        #endregion

        #region SelectionSort

        public static void SelectionSort(int[] a)
        {
            int min, temp;
            int length = a.Length;

            for (var i = 0; i < length - 1; i++)
            {
                min = i;

                for (var j = i + 1; j < length; j++)
                {
                    if (a[j] < a[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    temp = a[i];
                    a[i] = a[min];
                    a[min] = temp;
                }
            }
        }

        #endregion

        #region MergeSort

        public static void MergeSort<T>(T[] a, int p, int r) where T : struct, IComparable
        {
            if (p >= r)
                return;

            var q = (p + r)/2;

            MergeSort(a, p, q);
            MergeSort(a, q + 1, r);

            Merge(a, p, q, r);
        }

        private static void Merge<T>(T[] a, int p, int q, int r) where T : struct, IComparable
        {
            var n1 = q - p + 1;
            var n2 = r - q;

            var b = new T[n1 + 1];
            var c = new T[n2 + 1];

            Array.Copy(a, p, b, 0, n1);
            Array.Copy(a, q + 1, c, 0, n2);

            b[n1] = c[n2] = MaxValue<T>();

            var i = 0;
            var j = 0;

            for (var k = p; k <= r; k++)
            {
                if ( b[i].CompareTo(c[j]) == 0 || b[i].CompareTo(c[j]) < 0)
                {
                    a[k] = b[i];
                    i++;
                }
                else
                {
                    a[k] = c[j];
                    j++;
                }
            }
        }

        private static T MaxValue<T>() where T : struct, IComparable
        {
            var maxValueField = typeof(T).GetField("MaxValue", BindingFlags.Public | BindingFlags.Static);

            if (maxValueField == null)
                throw new NotSupportedException(typeof(T).Name);

            return (T) maxValueField.GetValue(null);
        }

        #endregion

        #region QuickSort

        public static void QuickSort<T>(T[] a, int p, int r) where T : IComparable
        {
            if (p >= r)
                return;

            var q = Partition(a, p, r);

            QuickSort(a, p, q-1);
            QuickSort(a, q+1, r);
        }

        private static int Partition<T>(T[] a, int p, int r) where T : IComparable
        {
            var q = p;
            for (var u = p; u < r; u++)
            {
                if ( a[u].CompareTo(a[r]) < 0 || a[u].CompareTo(a[r]) == 0)
                {
                    a.ShiftElement(q, u);
                    q++;
                }
            }

            a.ShiftElement(q, r);

            return q;
        }

        private static void ShiftElement<T>(this T[] array, int oldIndex, int newIndex)
        {
            if (oldIndex == newIndex)
                return;

            var tmp = array[oldIndex];
            array[oldIndex] = array[newIndex];
            array[newIndex] = tmp;
        }

        #endregion
    }
}