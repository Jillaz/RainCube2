using System;

public class GenericSpawner<T> where T : Items
{
    private T _prefab;
    private GenericPool<T> _pool;
    int _poolCapacity;
    int _poolMaxSize;

    public GenericSpawner(T prefab, int poolCapacity, int poolMaxSize)
    {
        _prefab = prefab;
        _poolCapacity = poolCapacity;
        _poolMaxSize = poolMaxSize;

        _pool = new GenericPool<T>(_prefab, _poolCapacity,_poolMaxSize);
    }

    public event Action Spawned;

    public event Action<int> Geted
    {
        add => _pool.Geted += value;
        remove => _pool.Geted -= value;
    }

    public event Action<int> Created
    {
        add => _pool.Created += value;
        remove => _pool.Created -= value;
    }

    public T Get()
    {
        Spawned?.Invoke();
        return _pool.Get();
    }

    public void Release (T releasedObject)
    {
        _pool.Release(releasedObject);
    }
}
