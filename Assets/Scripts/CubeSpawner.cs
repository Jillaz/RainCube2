using System.Collections;
using UnityEngine;

public class CubeSpawner : Spawner
{
    [SerializeField] private BombSpawner _bombSpawner;
    [SerializeField] private int _cubeCount = 0;
    [SerializeField] private float _spawnDelay = .5f;
    [SerializeField] private Cube _prefabCube;   

    private void Awake()
    {
        _spawner = new GenericSpawner<Items>(_prefabCube, _poolCapacity, _poolMaxSize);
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
            while (enabled)
            {
                Get();
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
        Cube cube = (Cube)_spawner.Get();
        cube.transform.position = GetSpawnPosition();
        cube.Released += Release;
        _bombSpawner.AddCube(cube);
    }

    private void Release(Cube cube)
    {
        cube.Init();
        _spawner.Release(cube);
        cube.Released -= Release;
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