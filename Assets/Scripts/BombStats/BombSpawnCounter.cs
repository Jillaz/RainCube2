using UnityEngine;

public class BombSpawnCounter : MonoBehaviour
{
    [SerializeField] private BombSpawner _spawner;

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
    }
}
