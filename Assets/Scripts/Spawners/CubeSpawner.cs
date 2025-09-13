using System;
using System.Collections;
using UnityEngine;

public class CubeSpawner : GenericSpawner<Cube>
{
    private Coroutine _coroutines;
    private float _spawnRate = 0.5f;
    private CubeSpawnArea _spawnArea;

    public CubeSpawner(CubeSpawnArea spawnArea ,Cube prefab, int poolCapacity, int poolMaxSize) : base(prefab, poolCapacity, poolMaxSize)
    {
        _spawnArea = spawnArea;
    }

    public event Action<Cube> OnSpawn;

    public override void Init()
    {
        _coroutines = Coroutines.StartRoutine(SpawnCube());
    }

    protected override void Subscribe(Cube cube)
    {
        cube.Released += Release;
    }

    protected override void UnSubscribe(Cube cube)
    {
        cube.Released -= Release;
    }

    private IEnumerator SpawnCube()
    {
        WaitForSeconds waitForSeconds = new(_spawnRate);

        while (true)
        {
            Cube cube = _pool.Get();

            cube.Init();
            cube.transform.position = _spawnArea.GetSpawnPosition();
            Subscribe(cube);
            OnSpawn?.Invoke(cube);

            yield return waitForSeconds;
        }
    }
}