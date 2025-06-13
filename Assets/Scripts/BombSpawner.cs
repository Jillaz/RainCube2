using System;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private Bomb _prefabBomb;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 10;
    private GenericPool<Bomb> _pool;
    private Cube _cube;

    public event Action Spawned;

    public int CountActive => _pool.CountActive;
    public int CountAll => _pool.CountAll;

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
        Spawned?.Invoke();
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
