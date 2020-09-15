public class LimitedSizeStack<T>
{
    #region Fields
    private int _count;
    private int _index;
    private int _limit;
    private T[] _data;
    #endregion Fields

    #region Properties
    public int Count => _count;

    public int Limit => _limit;
    #endregion Properties

    public LimitedSizeStack(int limit)
    {
#warning Zero size stack danger!
        if (limit <= 0) _limit = -1;
        else
        {
            _count = 0;
            _limit = limit;
            _data = new T[limit];
            _index = 0;
        }
    }

    #region Methods
    private void IncreaseIndex() => _index = (_index == _limit - 1) ? 0 : _index + 1;

    public void Push(T item)
    {
        if (_limit == -1) return;
        if (_count != _limit)
        {
            _data[_index] = item;
            _count++;
            IncreaseIndex();
        }
        else if (_count == _limit)
        {
            _data[_index] = item;
            IncreaseIndex();
        }
    }
    public T Pop()
    {
        if (_limit == -1) return default;
        if (_count == 0) return default;
        _index = (_index == 0) ? (_limit - 1) : _index - 1;
        T res = _data[_index];
        _data[_index] = default;
        _count--;
        return res;
    }
    #endregion Methods
}