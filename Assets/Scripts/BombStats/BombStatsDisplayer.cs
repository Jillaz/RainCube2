using UnityEngine;

public class BombStatsDisplayer : StatsDisplayer
{
    [SerializeField] private BombSpawner _bombSpawner;
    [SerializeField] private BombSpawnCounter _spawnCounter;

    private void OnDisable()
    {
        _bombSpawner.Spawned -= Display;
        _bombSpawner.Geted -= DisplayGeted;
        _bombSpawner.Created -= DisplayCreated;
    }

    private void Start()
    {
        _bombSpawner.Spawned += Display;
        _bombSpawner.Geted += DisplayGeted;
        _bombSpawner.Created += DisplayCreated;
    }
    private void Display()
    {
        Spawned(_spawnCounter.Number.ToString());
    }

    private void DisplayGeted(int value)
    {
        Active(value.ToString());
    }

    private void DisplayCreated(int value)
    {
        Created(value.ToString());
    }
}
