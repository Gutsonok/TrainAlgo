using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    class PriorityQueue
    {
        private int[] _arr;
        private int _count = 0;

        public PriorityQueue(int n, int[] arr)
        {
            _arr = new int[n];
            _count = n;
            _arr = arr;
            Build();
        }

        private void Build()
        {
            for (int i = _arr.Length / 2 - 1; i >= 0; i--)
                SiftDown(i);
        }

        public void SiftDown(int index)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;
            int larger = index;
            if (left<_arr.Length && _arr[left] > _arr[larger])
                larger = left;
            if (right < _arr.Length && _arr[right] > _arr[larger])
                larger = right;
            if(index!=larger)
            {
                int temp = _arr[larger];
                _arr[larger] = _arr[index];
                _arr[index] = temp;
                SiftDown(larger);
            }
        }

        public void SiftUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (_arr[parent] >= _arr[index])
                    break;

                int temp = _arr[parent];
                _arr[parent] = _arr[index];
                _arr[index] = temp;
                index = parent;
            }
        }

        public void UpdateMaximum(int element)
        {
            _arr[_count++] = element;
            SiftUp(_count-1);
        }

        public int GetMaximum()
        {
            if (_arr[0] != 0)
                return _arr[0];
            else return -1;
        }

        public void PopMaximum()
        {
            _arr[0] = _arr[--_count];
            _arr[_count] = 0;
            SiftDown(0);
        }
    }
}