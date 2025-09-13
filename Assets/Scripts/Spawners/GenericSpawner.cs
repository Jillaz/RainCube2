using System;

public abstract class GenericSpawner<T> where T : Items
{    
    protected GenericPool<T> _pool;

    public GenericSpawner(T prefab, int poolCapacity, int poolMaxSize)
    {        
        _pool = new GenericPool<T>(prefab, poolCapacity, poolMaxSize);
    }

    public event Action<int> ActiveNumberChanged
    {
        add => _pool.ActiveNumberChanged += value;
        remove => _pool.ActiveNumberChanged -= value;
    }

    public event Action<int> TotalNumberChanged
    {
        add => _pool.TotalNumberChanged += value;
        remove => _pool.TotalNumberChanged -= value;
    }

    public event Action<int> TotalGeted
    {
        add { _pool.TotalGeted += value; }
        remove { _pool.TotalGeted -= value; }
    }

    public event Action<T> Realesed
    {
        add => _pool.Realesed += value;
        remove =>_pool.Realesed -= value;
    }

    public abstract void Init();

    public void Release(T releasedObject)
    {
        _pool.Release(releasedObject);
        UnSubscribe(releasedObject);
    }

    protected abstract void Subscribe(T item);
    protected abstract void UnSubscribe(T item);
}
