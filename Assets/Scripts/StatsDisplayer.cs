using TMPro;
using UnityEngine;

public class StatsDisplayer : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _textActive;
    [SerializeField] private TextMeshProUGUI _textCreated;
    [SerializeField] private TextMeshProUGUI _textSpawned;
    private string _defaultTextActive;
    private string _defaultTextCreated;
    private string _defaultTextSpawned;

    private void Start()
    {
        _spawner.Spawned += Spawned;
        _spawner.Geted += Geted;
        _spawner.Created += Created;
    }

    private void OnDisable()
    {
        _spawner.Spawned -= Spawned;
        _spawner.Geted -= Geted;
        _spawner.Created -= Created;
    }

    public void Geted(int value)
    {
        _textActive.text = _defaultTextActive + value.ToString();
    }

    public void Created(int value)
    {
        _textCreated.text = _defaultTextCreated + value.ToString();
    }

    public void Spawned()
    {
        _textSpawned.text = _defaultTextSpawned + _counter.Number.ToString();
    }

    private void Awake()
    {
        _defaultTextActive = _textActive.text;
        _defaultTextCreated = _textCreated.text;
        _defaultTextSpawned = _textSpawned.text;
    }
}
