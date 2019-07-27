using System.Collections.Generic;

namespace PL.Sorting
{
    public static class Sort
    {
        //Сортировка Пузырьком
        public static T[] BubbleSort<T>(T[] array)
        {
            Sorter<T>.BubbleSort(array, Comparer<T>.Default);
            return array;
        }
        public static T[] BubbleSort<T>(T[] array, IComparer<T> comparer)
        {
            Sorter<T>.BubbleSort(array, comparer);
            return array;
        }

        //Улучшеная сортировка Пузырьком
        public static T[] UpgradeBubbleSort<T>(T[] array)
        {
            Sorter<T>.UpgradeBubbleSort(array, Comparer<T>.Default);
            return array;
        }
        public static T[] UpgradeBubbleSort<T>(T[] array, IComparer<T> comparer)
        {
            Sorter<T>.UpgradeBubbleSort(array, comparer);
            return array;
        }

        //Сортировка Шейкер
        public static T[] ShekerSort<T>(T[] array)
        {
            Sorter<T>.ShekerSort(array, Comparer<T>.Default);
            return array;
        }
        public static T[] ShekerSort<T>(T[] array, IComparer<T> comparer)
        {
            Sorter<T>.ShekerSort(array, comparer);
            return array;
        }

        //Сортировка Вставками
        public static T[] InsertionSort<T>(T[] array)
        {
            Sorter<T>.InsertionSort(array, Comparer<T>.Default);
            return array;
        }
        public static T[] InsertionSort<T>(T[] array, IComparer<T> comparer)
        {
            Sorter<T>.InsertionSort(array, comparer);
            return array;
        }

        //Сортировка Выбором
        public static T[] SelectionSort<T>(T[] array)
        {
            Sorter<T>.SelectionSort(array, Comparer<T>.Default);
            return array;
        }
        public static T[] SelectionSort<T>(T[] array, IComparer<T> comparer)
        {
            Sorter<T>.SelectionSort(array, comparer);
            return array;
        }

        //Быстрая сортировка
        public static T[] QuickSort<T>(T[] array)
        {
            Sorter<T>.QuickSort(array, 0, array.Length - 1, Comparer<T>.Default);
            return array;
        }
        public static T[] QuickSort<T>(T[] array, IComparer<T> comparer)
        {
            Sorter<T>.QuickSort(array, 0, array.Length - 1, comparer);
            return array;
        }

        //Проверка на верность сортировки
        public static bool CheckTrueSorting<T>(T[] array, IComparer<T> comparer = null)
        {
            if (comparer == null)
                comparer = Comparer<T>.Default;
            for (int i = 0; i < array.Length - 1; i++)
                if (comparer.Compare(array[i], array[i + 1]) > 0)
                    return false;
            return true;
        }
        public static bool CheckTrueSorting<T>(T[] array, out int errorsCount, IComparer<T> comparer = null)
        {
            if (comparer == null)
                comparer = Comparer<T>.Default;
            errorsCount = 0;
            for (int i = 0; i < array.Length - 1; i++)
                if (comparer.Compare(array[i], array[i + 1]) > 0)
                    errorsCount++;
            if (errorsCount == 0)
                return true;
            else
                return false;
        }
    }
}
