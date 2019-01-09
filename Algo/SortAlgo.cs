using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    public static class SortAlgo<T> where T : IComparable<T>
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
            for (int i = 1; i < arr.Length; ++i)
            {
                T temp = arr[i];
                int j = 0;
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
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                int minIndex = i;
                //Ищем индекс минимального элемента
                for (int j = i + 1; j < arr.Length; ++j)
                {
                    if (arr[j].CompareTo(arr[minIndex])<0)
                        minIndex = j;
                }
                //Меняем местами
                T temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
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
        
        public static void MergeSort(T[] arr, int left, int right)
        {
            if (left >= right)
                return;
            
            int mid = left + (right - left) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, (mid + 1), right);

            Merge(arr, left, mid, right);
            
        }

        private static void Merge(T[] arr, int left, int mid, int right)
        {
            T[] newArr = new T[right - left + 1];
            int i = left, j = mid + 1;
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
    }
}
