using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    /// <summary>
    /// Бинарная куча
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Heap<T> where T : IComparable//<T>
    {
        private List<T> _arr;

        public Heap()
        {
            _arr = new List<T>();
        }

        public Heap(T[] arr)
        {
            _arr = new List<T>(arr.Length);
            _arr.AddRange(arr);
            Build();
        }

        /// <summary>
        /// Создать кучу из массива 
        /// Время работы O(n*logn)
        /// </summary>
        private void Build()
        {
            for (int i = _arr.Count / 2 - 1; i >= 0; i--)
                SiftDown(i);
        }


        private void SiftDown(int index)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int largest = index;
            if (left<_arr.Count && _arr[left].CompareTo(_arr[largest]) > 0)
                largest = left;
            if (right<_arr.Count && _arr[right].CompareTo(_arr[largest]) > 0)
                largest = right;
            if (largest != index)
            {
                Swap(index, largest);
                SiftDown(largest);
            }
        }

        private void SiftUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (_arr[parent].CompareTo(_arr[index]) >= 0)
                    break;
                Swap(index, parent);
                index = parent;
            }
        }

        private void Swap(int index1, int index2)
        {
            T temp = _arr[index1];
            _arr[index1] = _arr[index2];
            _arr[index2] = temp;
        }

        public T PopMax()
        {
            T temp = _arr[0];
            _arr[0] = _arr.Last();
            _arr.RemoveAt(_arr.Count - 1);
            SiftDown(0);
            return temp;
        }

        public void Insert(T element)
        {
            _arr.Add(element);
            SiftUp(_arr.Count - 1);
        }

        public int Size()
        {
            return _arr.Count;
        }
    }
}
