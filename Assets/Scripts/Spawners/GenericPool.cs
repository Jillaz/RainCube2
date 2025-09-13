using System;
using UnityEngine;
using UnityEngine.Pool;

public class GenericPool<T> where T : Component
{
    private ObjectPool<T> _pool;
    private T _prefab;
    private int _totalGetted = 0;

    public GenericPool(T prefab, int poolCapacity = 10, int poolMaxSize = 20)
    {
        _prefab = prefab;
        _pool = new ObjectPool<T>(
            createFunc: () => Create(),
            actionOnGet: (T) => OnGet(T),
            actionOnRelease: (T) => OnRelease(T),
            actionOnDestroy: (T) => UnityEngine.Object.Destroy(T.gameObject),
            collectionCheck: true,
            defaultCapacity: poolCapacity,
            maxSize: poolMaxSize
            );
    }

    public event Action<int> TotalNumberChanged;
    public event Action<int> ActiveNumberChanged;
    public event Action<int> TotalGeted;
    public event Action<T> Realesed;

    public T Get()
    {
        _totalGetted++;        
        TotalGeted?.Invoke(_totalGetted);

        return _pool.Get();
    }
    public void Release(T prefab) => _pool.Release(prefab);


    private T Create()
    {
        T prefab = UnityEngine.Object.Instantiate(_prefab);
        prefab.gameObject.SetActive(false);
        TotalNumberChanged?.Invoke(_pool.CountAll);
        return prefab;
    }

    private void OnGet(T prefab)
    {
        prefab.gameObject.SetActive(true);
        ActiveNumberChanged?.Invoke(_pool.CountActive);
    }

    private void OnRelease(T prefab)
    {
        prefab.gameObject.SetActive(false);
        Realesed?.Invoke(prefab);
    }
}