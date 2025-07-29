using TMPro;
using UnityEngine;

public class CubeStatsDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textActive;
    [SerializeField] private TextMeshProUGUI _textCreated;
    [SerializeField] private TextMeshProUGUI _textSpawned;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private CubeSpawnCounter _spawnCounter;
    private GenericStats<CubeSpawner, CubeSpawnCounter> _displayStats;

    private void Start()
    {
        _displayStats = new GenericStats<CubeSpawner, CubeSpawnCounter>(_textActive, _textCreated, _textSpawned, _cubeSpawner, _spawnCounter);
    }
}
