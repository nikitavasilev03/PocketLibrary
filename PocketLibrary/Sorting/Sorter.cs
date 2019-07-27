using System.Collections.Generic;

namespace PL.Sorting
{
    internal static class Sorter<T>
    {
        internal static T[] BubbleSort(T[] array, IComparer<T> comparer)
        {
            T temp;
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = 0; j < array.Length - 1; j++)
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
            return array;
        }
        internal static T[] UpgradeBubbleSort(T[] array, IComparer<T> comparer)
        {
            T temp;
            bool IsSorted;
            do
            {
                IsSorted = true;
                for (int j = 0; j < array.Length - 1; j++)
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        IsSorted = false;
                    }
            }
            while (!IsSorted);
            return array;
        }

        internal static T[] ShekerSort(T[] array, IComparer<T> comparer)
        {
            int left = 0; 
            int right = array.Length - 1;
            bool IsSorted;
            T temp;
            do
            {
                IsSorted = true;
                for (int i = left; i < right; i++)
                {
                    if (comparer.Compare(array[i], array[i + 1]) > 0)
                    {             
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        IsSorted = false;     
                    }
                }
                right--; 
                for (int i = right; i > left; i--)
                {
                    if (comparer.Compare(array[i], array[i - 1]) < 0) 
                    {   
                        temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                        IsSorted = false;  
                    }
                }
                left++;
            } while ((left < right) && !IsSorted);
            return array;
        }

        internal static T[] InsertionSort(T[] array, IComparer<T> comparer)
        {
            T temp;
            int j;
            for (int i = 1; i < array.Length; i++)
            {
                j = i - 1;
                while (j >= 0 && comparer.Compare(array[j], array[j + 1]) < 0)
                {
                    temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    j--;
                }
            }
            return array;
        }

        internal static T[] SelectionSort(T[] array, IComparer<T> comparer)
        {
            T temp;
            int min;
            for (int i = 0; i < array.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < array.Length; j++)
                    if (comparer.Compare(array[j], array[min]) < 0)
                        min = j;
                temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }
            return array;
        }

        internal static void QuickSort(T[] array, int l, int r, IComparer<T> comparer)
        {
            int i = l;
            int j = r;
            T temp;

            int middle = l + ((r - l) >> 1);
            SwapIfGreater(array, comparer, i, middle);  
            SwapIfGreater(array, comparer, i, j);  
            SwapIfGreater(array, comparer, middle, j);

            do
            {
                while (comparer.Compare(array[i], array[middle]) < 0) i++;
                while (comparer.Compare(array[j], array[middle]) > 0) j--;
                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }

            } while (i <= j);

            if (j > l) QuickSort(array, l, j, comparer);
            if (i < r) QuickSort(array, i, r, comparer);
        }

        private static void SwapIfGreater(T[] array, IComparer<T> comparer, int a, int b)
        {
            if (a != b)
            {
                if (comparer.Compare(array[a], array[b]) > 0)
                {
                    T key = array[a];
                    array[a] = array[b];
                    array[b] = key;
                }
            }
        }

        private static void Swap(T[] a, int i, int j)
        {
            if (i != j)
            {
                T t = a[i];
                a[i] = a[j];
                a[j] = t;
            }
        }
    }
}
