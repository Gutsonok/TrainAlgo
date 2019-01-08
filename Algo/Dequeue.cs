using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo
{
    class Dequeue
    {
        private int[] _arr;
        private int _begin;
        private int _end;
        private int _size = 4;
        private int _count = 0;

        private int Begin
        {
            get { return _begin; }
            set
            {
                _begin = (value + _size) % _size;
            }
        }

        private int End
        {
            get { return _end; }
            set
            {
                _end = (value + _size) % _size;
            }
        }

        public int Count { get; set; }

        private Boolean isEmpty()
        {
            return Count == 0;
        }

        public Dequeue()
        {
            _arr = new int[_size];
            Begin = 0;
            End = _size - 1;
        }

        private void IncreaseArr()
        {
            var newSize = _size * 2;
            var newArr = new int[newSize];
            var j = 0;
            while (true)
            {
                var isBreak = false;
                if (Begin == End)
                    isBreak = true;
                newArr[j] = _arr[Begin];
                Begin++;
                if (isBreak)
                    break;
                j++;
            }
            _size = newSize;
            _arr = newArr;
            Begin = 0;
            End = j;
        }

        public void PushFront(int element)
        {
            --Begin;
            _arr[Begin] = element;
            Count++;
            if (Begin == (End + 1) % _size)
                IncreaseArr();
        }

        public int PopFront()
        {
            if (isEmpty())
                return -1;
            Count--;
            return _arr[Begin++];
        }

        public void PushBack(int element)
        {
            ++End;
            _arr[End] = element;
            Count++;
            if (Begin == (End + 1) % _size)
                IncreaseArr();
        }

        public int PopBack()
        {
            if (isEmpty())
                return -1;
            Count--;
            return _arr[End--];
        }
    }
}
