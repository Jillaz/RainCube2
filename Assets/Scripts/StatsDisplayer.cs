using TMPro;
using UnityEngine;

public class StatsDisplayer : MonoBehaviour
{    
    [SerializeField] private TextMeshProUGUI _textActive;
    [SerializeField] private TextMeshProUGUI _textCreated;
    [SerializeField] private TextMeshProUGUI _textSpawned;
    private string _defaultTextActive;
    private string _defaultTextCreated;
    private string _defaultTextSpawned;

    public void Active(string active)
    {
        _textActive.text = _defaultTextActive + active;
    }

    public void Created(string created)
    {
        _textCreated.text = _defaultTextCreated + created;
    }

    public void Spawned(string spawned)
    {
        _textSpawned.text = _defaultTextSpawned + spawned;
    }

    private void Awake()
    {
        _defaultTextActive = _textActive.text;
        _defaultTextCreated = _textCreated.text;
        _defaultTextSpawned = _textSpawned.text;
    }
}
