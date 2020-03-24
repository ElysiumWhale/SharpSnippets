using System;

namespace TodoApplication
{
    public class LimitedSizeStack<T>
    {
        private T[] _data;
        private int _count;
        public int Count { get => _count; }
        private int _index;
        private int _limit;
        public int Limit { get => _limit; }
        public LimitedSizeStack(int limit)
        {
            if (limit <= 0)
                throw new ArgumentException("Size of stack can't be 0 or less");
            _limit = limit;
            _data = new T[limit];
            _count = 0;
            _index = 0;
        }
        private void IncreaseIndex()
        {
            if (_index == _limit - 1)
                _index = 0;
            else
                _index++;
        }
        public void Push(T item)
        {
            if (_count != _limit)
            {
                _data[_index] = item;
                _count++;
                IncreaseIndex();
            }
            else if (Count == _limit)
            {
                _data[_index] = item;
                IncreaseIndex();
            }
        }
        public T Pop()
        {
            if (_count == 0)
                return default;
            if (_index == 0)
                _index = _limit - 1;
            else
                _index--;
            T res = _data[_index];
            _data[_index] = default;
            _count--;
            return res;
        }
    }
}
