using TMPro;
using UnityEngine;

public class BombSpawnedDisplayer : MonoBehaviour
{
    [SerializeField] private BombSpawnCounter _bombCounter;    
    [SerializeField] private TextMeshProUGUI _text;
    private string _defaultText;

    private void OnEnable()
    {
        _bombCounter.Counted += Display;
    }

    private void OnDisable()
    {
        _bombCounter.Counted -= Display;
    }

    private void Start()
    {
        _defaultText = _text.text;
    }

    private void Display()
    {
        _text.text = _defaultText + _bombCounter.Number;
    }
}
