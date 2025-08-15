using UnityEngine;

public class BombSpawner : Spawner
{
    [SerializeField] private Bomb _prefabBomb;

    private void Awake()
    {
        _spawner = new GenericSpawner<Items>(_prefabBomb, _poolCapacity, _poolMaxSize);
    }

    public void AddCube(Cube cube)
    {
        cube.Released += Get;
    }

    public void RemoveCube(Cube cube)
    {
        cube.Released -= Get;
    }    

    private void Get(Cube cube)
    {
        Bomb bomb = (Bomb)_spawner.Get();
        bomb.transform.position = cube.transform.position;
        bomb.Init();
        bomb.Released += Release;
    }

    private void Release(Bomb bomb)
    {
        _spawner.Release(bomb);
        bomb.Released -= Release;
    }
}
