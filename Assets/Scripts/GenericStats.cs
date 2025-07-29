using TMPro;
using UnityEngine;

public class GenericStats<TSpawner, TSpawnCounter>
    where TSpawner : Component
    where TSpawnCounter : Component

{
    private TextMeshProUGUI _textActive;
    private TextMeshProUGUI _textCreated;
    private TextMeshProUGUI _textSpawned;
    private string _defaultTextActive;
    private string _defaultTextCreated;
    private string _defaultTextSpawned;
    private TSpawner _spawner;
    private TSpawnCounter _counter;

    public GenericStats(TextMeshProUGUI textActive, TextMeshProUGUI textCreated, TextMeshProUGUI textSpawned, TSpawner spawner, TSpawnCounter counter)
    {
        _textActive = textActive;
        _textCreated = textCreated;
        _textSpawned = textSpawned;
        _spawner = spawner;
        _counter = counter;
        GetDefaultsText();
        EventSubscribe();
    }

    private void GetDefaultsText()
    {
        _defaultTextActive = _textActive.text;
        _defaultTextCreated = _textCreated.text;
        _defaultTextSpawned = _textSpawned.text;        
    }

    private void EventSubscribe()
    {
        if (_spawner is CubeSpawner cubeSpawner)
        {
            cubeSpawner.Spawned += DisplaySpawned;
            cubeSpawner.Geted += DisplayGeted;
            cubeSpawner.Created += DisplayCreated;
        }
        else if (_spawner is BombSpawner bombSpawner)
        {
            bombSpawner.Spawned += DisplaySpawned;
            bombSpawner.Geted += DisplayGeted;
            bombSpawner.Created += DisplayCreated;
        }
    }

    private void DisplaySpawned()
    {
        if (_counter is CubeSpawnCounter cubeCounter)
        {
            _textSpawned.text = _defaultTextSpawned + cubeCounter.Number.ToString();
        }
        else if (_counter is BombSpawnCounter bombCounter)
        {
            _textSpawned.text = _defaultTextSpawned + bombCounter.Number.ToString();
        }
    }

    private void DisplayGeted(int value)
    {
        _textActive.text = _defaultTextActive + value.ToString();
    }

    private void DisplayCreated(int value)
    {
        _textCreated.text = _defaultTextCreated + value.ToString();
    }
}
