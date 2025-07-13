using UnityEngine;

public class CubeStatsDisplayer : StatsDisplayer
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private CubeSpawnCounter _spawnCounter;

    private void OnDisable()
    {
        _cubeSpawner.Spawned -= Display;
        _cubeSpawner.Geted -= DisplayGetted;
        _cubeSpawner.Created -= DisplayCreated;
    }

    private void Start()
    {
        _cubeSpawner.Spawned += Display;
        _cubeSpawner.Geted += DisplayGetted;
        _cubeSpawner.Created += DisplayCreated;
    }

    private void Display()
    {
        Spawned(_spawnCounter.Number.ToString());
    }

    private void DisplayGetted(int value)
    {
        Active(value.ToString());
    }

    private void DisplayCreated(int value)
    {
        Created(value.ToString());
    }
}
