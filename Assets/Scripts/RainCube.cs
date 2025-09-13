using UnityEngine;

public class RainCube : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Bomb _bomb;
    [SerializeField] private CubeSpawnArea _spawnArea;
    CubeSpawner _cubeSpawner;
    BombSpawner _bombSpawner;

    private void Awake()
    {
        _cubeSpawner = new CubeSpawner(_spawnArea, _cube, 10, 10);
        _bombSpawner = new BombSpawner(_cubeSpawner, _bomb, 10, 10);
    }

    private void Start()
    {
        _cubeSpawner.Init();
        _bombSpawner.Init();
    }

    public CubeSpawner GetCubeSpawner() => _cubeSpawner;
    public BombSpawner GetBombSpawner() => _bombSpawner;
}
