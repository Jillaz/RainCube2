using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected int _poolCapacity = 5;
    [SerializeField] protected int _poolMaxSize = 10;
    protected GenericSpawner<Items> _spawner;

    public event Action<int> Geted
    {
        add => _spawner.Geted += value;
        remove => _spawner.Geted -= value;
    }

    public event Action<int> Created
    {
        add => _spawner.Created += value;
        remove => _spawner.Created -= value;
    }

    public event Action Spawned
    {
        add => _spawner.Spawned += value;
        remove => _spawner.Spawned -= value;
    }
}
