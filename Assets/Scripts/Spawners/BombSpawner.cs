using System;

public class BombSpawner : GenericSpawner<Bomb>, IDisposable
{
    private CubeSpawner _cubeSpawner;

    public BombSpawner(CubeSpawner cubeSpawner, Bomb prefab, int poolCapacity, int poolMaxSize) : base(prefab, poolCapacity, poolMaxSize)
    {
        _cubeSpawner = cubeSpawner;
    }

    public override void Init()
    {
        _cubeSpawner.OnSpawn += AddCube;
    }

    public void Dispose()
    {
        _cubeSpawner.OnSpawn -= AddCube;
    }

    protected override void Subscribe(Bomb bomb)
    {
        bomb.Released += Release;
    }

    protected override void UnSubscribe(Bomb bomb)
    {
        bomb.Released -= Release;
    }

    private void AddCube(Cube cube)
    {
        cube.Released += SpawnBomb;
    }

    private void RemoveCube(Cube cube)
    {
        cube.Released -= SpawnBomb;
    }

    private void SpawnBomb(Cube cube)
    {
        Bomb bomb = _pool.Get();
        bomb.Init();
        bomb.transform.position = cube.transform.position;
        Subscribe(bomb);
        RemoveCube(cube);
    }
}