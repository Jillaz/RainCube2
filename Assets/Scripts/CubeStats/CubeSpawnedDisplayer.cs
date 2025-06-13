using TMPro;
using UnityEngine;

public class CubeSpawnedDisplayer : MonoBehaviour
{
    [SerializeField] private CubeSpawnCounter _cubeCounter;
    [SerializeField] private TextMeshProUGUI _text;
    private string _defaultText;

    private void OnEnable()
    {
        _cubeCounter.Counted += Display;
    }

    private void OnDisable()
    {
        _cubeCounter.Counted -= Display;
    }

    private void Start()
    {
        _defaultText = _text.text;
    }

    private void Display()
    {
        _text.text = _defaultText + _cubeCounter.Number;
    }
}
