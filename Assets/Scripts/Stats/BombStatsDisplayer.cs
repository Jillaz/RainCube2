using TMPro;
using UnityEngine;

public class BombStatsDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textActive;
    [SerializeField] private TextMeshProUGUI _textCreated;
    [SerializeField] private TextMeshProUGUI _textSpawned;
    [SerializeField] private RainCube _genSpawner;
    private GenericStats<Bomb> _genStats;

    private void Start()
    {
        _genStats = new GenericStats<Bomb>(_genSpawner.GetBombSpawner(), _textActive, _textCreated, _textSpawned);
        _genStats.Init();
    }
}
