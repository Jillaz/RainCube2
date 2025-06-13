using TMPro;
using UnityEngine;

public class CubeCreatedDisplayer : MonoBehaviour
{
    [SerializeField] private CubeSpawner _CubeSpawner;
    [SerializeField] private TextMeshProUGUI _text;
    private string _defaultText;

    private void OnEnable()
    {
        _CubeSpawner.Spawned += Display;
    }

    private void OnDisable()
    {
        _CubeSpawner.Spawned -= Display;
    }

    private void Start()
    {
        _defaultText = _text.text;
    }

    private void Display()
    {
        _text.text = _defaultText + _CubeSpawner.CountAll.ToString();
    }
}
