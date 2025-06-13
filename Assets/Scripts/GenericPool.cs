using UnityEngine;
using UnityEngine.Pool;

public class GenericPool<T> where T : Component
{
    private ObjectPool<T> _pool;
    private T _prefab;


    public GenericPool(T prefab, int poolCapacity = 10, int poolMaxSize = 20)
    {
        _prefab = prefab;
        _pool = new ObjectPool<T>(
            createFunc: () => Create(),
            actionOnGet: (T) => OnGet(T),
            actionOnRelease: (T) => OnRelease(T),
            actionOnDestroy: (T) => Object.Destroy(T.gameObject),
            collectionCheck: true,
            defaultCapacity: poolCapacity,
            maxSize: poolMaxSize
            );
    }

    public int CountActive => _pool.CountActive;
    public int CountAll => _pool.CountAll;
    public T Get () => _pool.Get();
    public void Release(T prefab) => _pool.Release(prefab);

    private T Create()
    {
        T prefab = Object.Instantiate(_prefab);
        prefab.gameObject.SetActive(false);
        return prefab;              
    }

    private void OnGet(T prefab)
    {
        prefab.gameObject.SetActive(true);
    }

    private void OnRelease(T prefab)
    {
        prefab.gameObject.SetActive(false);
    }
}
