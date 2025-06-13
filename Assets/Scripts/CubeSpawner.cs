using System;
using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _prefabCube;
    [SerializeField] private BombSpawner _bombSpawner;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 10;
    [SerializeField] private int _cubeCount = 0;
    [SerializeField] private float _spawnDelay = .5f;
    private GenericPool<Cube> _pool;
    
    public event Action Spawned;

    public int CountActive => _pool.CountActive;
    public int CountAll => _pool.CountAll;

    private void Awake()
    {
        _pool = new GenericPool<Cube>(_prefabCube, _poolCapacity, _poolMaxSize);
    }

    private void Start()
    {
        StartCoroutine(SpawnCubes());
    }

    private IEnumerator SpawnCubes()
    {
        var delay = new WaitForSeconds(_spawnDelay);

        if (_cubeCount == 0)
        {
            while (true)
            {
                Get();
                Spawned?.Invoke();
                yield return delay;
            }
        }
        else
        {
            while (_cubeCount > 0)
            {
                Get();
                _cubeCount--;
                yield return delay;
            }
        }
    }

    private void Get()
    {
        Cube cube = _pool.Get();
        cube.transform.position = GetSpawnPosition();
        cube.Release += Release;
        _bombSpawner.AddCube(cube);
    }

    private void Release(Cube cube)
    {
        _pool.Release(cube);
        cube.Release -= Release;     
        _bombSpawner.RemoveCube(cube);
    }

    private Vector3 GetSpawnPosition()
    {
        float defaultLenghtFromCenter = 5f;
        float scaleFactorX;
        float scaleFactorZ;
        float minPositionX;
        float maxPositionX;
        float postitionX;
        float minPositionZ;
        float maxPositionZ;
        float postitionZ;
        float postitionY;

        scaleFactorX = transform.localScale.x;
        scaleFactorZ = transform.localScale.z;

        minPositionX = transform.position.x - defaultLenghtFromCenter * scaleFactorX;
        maxPositionX = transform.position.x + defaultLenghtFromCenter * scaleFactorX;

        minPositionZ = transform.position.z - defaultLenghtFromCenter * scaleFactorZ;
        maxPositionZ = transform.position.z + defaultLenghtFromCenter * scaleFactorZ;

        postitionX = UnityEngine.Random.Range(minPositionX, maxPositionX);
        postitionZ = UnityEngine.Random.Range(minPositionZ, maxPositionZ);
        postitionY = transform.position.y;

        return new Vector3(postitionX, postitionY, postitionZ);
    }
}