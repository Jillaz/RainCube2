using TMPro;
using UnityEngine;

public class CubeStatsDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textActive;
    [SerializeField] private TextMeshProUGUI _textCreated;
    [SerializeField] private TextMeshProUGUI _textSpawned;
    [SerializeField] private RainCube _genSpawner;
    private GenericStats<Cube> _genStats;

    private void Start()
    {        
        _genStats = new GenericStats<Cube>(_genSpawner.GetCubeSpawner(), _textActive, _textCreated, _textSpawned);
        _genStats.Init();     
    }    
}
