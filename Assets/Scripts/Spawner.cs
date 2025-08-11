using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected int _poolCapacity = 5;
    [SerializeField] protected int _poolMaxSize = 10;
    private GenericPool<Cube> _pool;    

    public event Action Spawned;

    public virtual event Action<int> Geted
    {
        add => _pool.Geted += value;
        remove => _pool.Geted -= value;
    }

    public virtual event Action<int> Created
    {
        add => _pool.Created += value;
        remove => _pool.Created -= value;
    }

    protected void SpawnHandler()
    {
        Spawned?.Invoke();
    }
}
