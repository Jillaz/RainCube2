using UnityEngine;

public class RainCube : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private Bomb _bomb;
    [SerializeField] private CubeSpawnArea _spawnArea;
    private CubeSpawner _cubeSpawner;
    private BombSpawner _bombSpawner;

    private void Awake()
    {
        _cubeSpawner = new CubeSpawner(_spawnArea, _cube, 10, 10);
        _bombSpawner = new BombSpawner(_cubeSpawner, _bomb, 10, 10);
    }

    private void Start()
    {
        _bombSpawner.Init();
        _cubeSpawner.Init();
    }

    public CubeSpawner GetCubeSpawner() => _cubeSpawner;
    public BombSpawner GetBombSpawner() => _bombSpawner;
}
