using TMPro;
using UnityEngine;

public class BombActiveDisplayer : MonoBehaviour
{
    [SerializeField] private BombSpawner _bombSpawner;
    [SerializeField] private TextMeshProUGUI _text;
    private string _defaultText;

    private void OnEnable()
    {
        _bombSpawner.Spawned += Display;
    }

    private void OnDisable()
    {
        _bombSpawner.Spawned -= Display;
    }

    private void Start()
    {
        _defaultText = _text.text;
    }

    private void Display()
    {
        _text.text = _defaultText + _bombSpawner.CountActive.ToString();
    }
}
