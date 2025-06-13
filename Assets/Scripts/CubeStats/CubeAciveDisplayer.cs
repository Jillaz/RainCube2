using TMPro;
using UnityEngine;

public class CubeAciveDisplayer : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private TextMeshProUGUI _text;
    private string _defaultText;

    private void OnEnable()
    {
        _cubeSpawner.Spawned += Display;
    }

    private void OnDisable()
    {
        _cubeSpawner.Spawned -= Display;
    }

    private void Start()
    {
        _defaultText = _text.text;
    }

    private void Display()
    {
        _text.text = _defaultText + _cubeSpawner.CountActive.ToString();
    }
}
