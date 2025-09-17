using System;
using TMPro;

public class GenericStats<T> : IDisposable
    where T : Items
{
    private GenericSpawner<T> _spawner;
    private TextMeshProUGUI _textActive;
    private TextMeshProUGUI _textCreated;
    private TextMeshProUGUI _textSpawned;
    private string _defaultTextActive;
    private string _defaultTextTotalNumber;
    private string _defaultTextSpawned;

    public GenericStats(GenericSpawner<T> spawner, TextMeshProUGUI textActive, TextMeshProUGUI textCreated, TextMeshProUGUI textSpawned)
    {
        _spawner = spawner;
        _textActive = textActive;
        _textCreated = textCreated;
        _textSpawned = textSpawned;
    }    

    public void Init()
    {       
        _spawner.TotalNumberChanged += TotalNumber;
        _spawner.ActiveNumberChanged += ActiveNumber;
        _spawner.TotalGeted += Spawned;

        _defaultTextActive = _textActive.text;
        _defaultTextTotalNumber = _textCreated.text;
        _defaultTextSpawned = _textSpawned.text;
    }

    public void Dispose()
    {
        _spawner.TotalNumberChanged -= TotalNumber;
        _spawner.ActiveNumberChanged -= ActiveNumber;
        _spawner.TotalGeted -= Spawned;
    }

    public void ActiveNumber(int value)
    {
        _textActive.text = _defaultTextActive + value.ToString();
    }

    public void TotalNumber(int value)
    {
        _textCreated.text = _defaultTextTotalNumber + value.ToString();
    }

    public void Spawned(int value)
    {
        _textSpawned.text = _defaultTextSpawned + value.ToString();
    }
}
