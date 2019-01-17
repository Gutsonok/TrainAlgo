using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public static class SortAlgo<T> where T : IComparable//<T>
    {
        /// <summary>
        /// Сортировка вставками
        /// Устойчива
        /// Худшее время  О(n2) сравнений и обменов
        /// Лучшее время  O(n)  сравнений и 0 обменов
        /// Среднее время О(n2) сравнений и обменов
        /// Затраты памяти О(n) всего, O(1) вспомогательный
        /// </summary>
        /// <param name="arr">Входной массив</param>
        public static void InsertionSort(T[] arr)
        {
            for (Int64 i = 1; i < arr.Length; ++i)
            {
                T temp = arr[i];
                Int64 j = 0;
                //Сдвигаем на один все элементы большие текущего
                for (j = i - 1; j >= 0 && temp.CompareTo(arr[j]) < 0; --j)
                    arr[j + 1] = arr[j];
                //Вставляем текущий на освободившеся место
                arr[j + 1] = temp;
            }
        }

        /// <summary>
        /// Сортировка выбором
        /// Не устойчива
        /// Худшее время  О(n2) сравнений и О(n) обменов
        /// Лучшее время  О(n2) сравнений и О(n) обменов
        /// Среднее время О(n2) сравнений и О(n) обменов
        /// Затраты памяти  О(n) всего, O(1) дополнительно
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(T[] arr)
        {
            for (Int64 i = 0; i < arr.Length - 1; ++i)
            {
                Int64 minIndex = i;
                //Ищем индекс минимального элемента
                for (Int64 j = i + 1; j < arr.Length; ++j)
                {
                    if (arr[j].CompareTo(arr[minIndex])<0)
                        minIndex = j;
                }
                //Меняем местами
                Swap(ref arr[i], ref arr[minIndex]);
            }
        }

        /// <summary>
        /// Пирамидальная сортировка
        /// Не устойчива
        /// Худшее время  O(n*logn) сравнений и обменов
        /// Лучшее время  O(n*logn) сравнений и обменов
        /// Среднее время O(n*logn) сравнений и обменов
        /// Затраты памяти  О(n) всего, O(1) дополнительно
        /// </summary>
        /// <param name="arr"></param>
        public static void Heapsort(T[] arr)
        {
            //Создаем кучу
            var heap = new Heap<T>(arr);
            //Пока куча не пуста, берем максимальный элемент и ставим в массив начиная с конца
            while (heap.Size() > 0)
            {
                arr[heap.Size() - 1] = heap.PopMax();
            }
        }

        /// <summary>
        /// Сортировка слиянием
        /// </summary>
        /// Худшее время  O(n log2 n)
        /// Лучшее время  O(n log2 n)
        /// Среднее время O(n log2 n)
        /// Затраты памяти O(n) вспомогательных
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void MergeSort(T[] arr, Int64 left, Int64 right)
        {
            if (left >= right)
                return;

            Int64 mid = left + (right - left) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, (mid + 1), right);

            Merge(arr, left, mid, right);
            
        }

        /// <summary>
        /// Вспомогательный метод для сортировки слиянием, выполняет слияние двух массивов
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="mid"></param>
        /// <param name="right"></param>
        private static void Merge(T[] arr, Int64 left, Int64 mid, Int64 right)
        {
            T[] newArr = new T[right - left + 1];
            Int64 i = left, j = mid + 1;
            while(i <= mid && j <= right)
            {
                if (arr[i].CompareTo(arr[j]) < 0)
                    newArr[i - left + j - (mid + 1)] = arr[i++];
                else
                    newArr[i - left + j - (mid + 1)] = arr[j++];
            }
            if (i <= mid)
                for (; i <= mid; ++i)
                    newArr[i - left + j - (mid + 1)] = arr[i];
            else
                for (; j <= right; ++j)
                    newArr[i - left + j - (mid + 1)] = arr[j];
            for (i = left, j = 0; i <= right; ++i, ++j)
                arr[i] = newArr[j];
        }

        /// <summary>
        /// Быстрая сортировка
        /// Не устойчива
        /// Худшее время  O(n2)
        /// Лучшее время  O(n log n) (обычное разделение) или O(n) (разделение на 3 части)
        /// Среднее время O(n log n)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void QuickSort(T[] arr, Int64 left, Int64 right)
        {
            if(left < right && right-left<=3)
                InsertionSort(arr, left, right);
            else if (left < right)
            {
                Int64 part = Partition(arr, left, right);
                QuickSort(arr, left, part);
                QuickSort(arr, part+1, right);
            }
        }

        /// <summary>
        /// Вспомогательный метод для быстрой сортировки
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static Int64 Partition(T[] arr, Int64 left, Int64 right)
        {
            var median = new Tuple<T, Int64>[] { Tuple.Create(arr[left], left), Tuple.Create(arr[right], right), Tuple.Create(arr[left + (right - left) / 2],left + (right - left) / 2) }
                .OrderBy(x => x).ToArray()[1];
            T pivot = median.Item1;
            Int64 i = left, j = right;
            while (i<j)
            {
                for (; arr[i].CompareTo(pivot) < 0; ++i) ;
                for (; arr[j].CompareTo(pivot) > 0; --j) ;
                
                if (i >= j)
                    break;

                Swap(ref arr[i++], ref arr[j--]);
            }

            return j;
        }

        /// <summary>
        /// Вспомогательный метод для обмена элементов местами
        /// </summary>
        /// <param name="elem1"></param>
        /// <param name="elem2"></param>
        private static void Swap(ref T elem1, ref T elem2)
        {
            T temp = elem1;
            elem1 = elem2;
            elem2 = temp;
        }
    }
}
