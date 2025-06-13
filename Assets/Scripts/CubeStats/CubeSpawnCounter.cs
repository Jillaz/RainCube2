using System;
using UnityEngine;

public class CubeSpawnCounter : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;

    public event Action Counted;

    public int Number { get; private set; } = 0;

    private void OnEnable()
    {
        _spawner.Spawned += Spawned;
    }

    private void OnDisable()
    {
        _spawner.Spawned -= Spawned;
    }

    private void Spawned()
    {
        Number++;
        Counted?.Invoke();
    }
}
