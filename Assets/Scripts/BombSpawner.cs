using System;
using UnityEngine;

public class BombSpawner : Spawner
{
    [SerializeField] private Bomb _prefabBomb;
    private GenericPool<Bomb> _pool;

    public override event Action<int> Geted
    {
        add => _pool.Geted += value;
        remove => _pool.Geted -= value;
    }

    public override event Action<int> Created
    {
        add => _pool.Created += value;
        remove => _pool.Created -= value;
    }

    public void AddCube(Cube cube)
    {
        cube.Release += Get;
    }

    public void RemoveCube(Cube cube)
    {
        cube.Release -= Get;
    }

    private void Awake()
    {
        _pool = new GenericPool<Bomb>(_prefabBomb, _poolCapacity, _poolMaxSize);
    }

    private void Get(Cube cube)
    {
        Bomb bomb = _pool.Get();
        SpawnHandler();
        bomb.transform.position = cube.transform.position;
        bomb.Init();
        bomb.Release += Release;
    }

    private void Release(Bomb bomb)
    {
        _pool.Release(bomb);
        bomb.Release -= Release;
    }
}
