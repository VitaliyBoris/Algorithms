namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var result = a.SentinelLinearSearch(11);

            a = new[] {12, 9, 3, 7, 14, 11, 6, 2, 10, 5};
            //SortHelper.MergeSort(a, 0, a.Length - 1);
            SortHelper.QuickSort(a, 0, a.Length - 1);
        }
    }
}
