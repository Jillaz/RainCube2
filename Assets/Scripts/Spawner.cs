using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected int _poolCapacity = 5;
    [SerializeField] protected int _poolMaxSize = 10;

    public event Action Spawned;

    public virtual event Action<int> Geted
    {
        add {}
        remove {}
    }

    public virtual event Action<int> Created
    {
        add {}
        remove {}
    }

    protected void SpawnHandler()
    {
        Spawned?.Invoke();
    }
}
