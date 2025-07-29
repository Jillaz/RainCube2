using TMPro;
using UnityEngine;

public class BombStatsDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textActive;
    [SerializeField] private TextMeshProUGUI _textCreated;
    [SerializeField] private TextMeshProUGUI _textSpawned;
    [SerializeField] private BombSpawner _bombSpawner;
    [SerializeField] private BombSpawnCounter _spawnCounter;
    private GenericStats<BombSpawner, BombSpawnCounter> _displayStats;

    private void Start()
    {
        _displayStats = new GenericStats<BombSpawner, BombSpawnCounter>(_textActive, _textCreated, _textSpawned, _bombSpawner, _spawnCounter);
    }
}
