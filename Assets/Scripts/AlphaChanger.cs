using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class AlphaChanger : MonoBehaviour
{
    private Color _color;
    private Renderer _renderer;
    private float _alphaDelta;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        _color.a -= Time.deltaTime * _alphaDelta;
        _renderer.material.color = _color;
    }

    public void LifeTime(float lifeTime, Color color)
    {
        _color = color;
        _alphaDelta = _color.a / lifeTime;
    }
}
