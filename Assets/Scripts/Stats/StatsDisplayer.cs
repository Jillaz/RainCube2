using TMPro;
using UnityEngine;

public abstract class StatsDisplayer : MonoBehaviour
{    
    [SerializeField] protected RainCube _genSpawner;
    [SerializeField] private TextMeshProUGUI _textActive;
    [SerializeField] private TextMeshProUGUI _textCreated;
    [SerializeField] private TextMeshProUGUI _textSpawned;
    private string _defaultTextActive;
    private string _defaultTextTotalNumber;
    private string _defaultTextSpawned;

    protected void Awake()
    {
        _defaultTextActive = _textActive.text;
        _defaultTextTotalNumber = _textCreated.text;
        _defaultTextSpawned = _textSpawned.text;
    }

    protected void ActiveNumber(int value)
    {
        _textActive.text = _defaultTextActive + value.ToString();
    }

    protected void TotalNumber(int value)
    {
        _textCreated.text = _defaultTextTotalNumber + value.ToString();
    }

    protected void Spawned(int value)
    {
        _textSpawned.text = _defaultTextSpawned + value.ToString();
    }
}
