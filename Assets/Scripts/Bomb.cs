using System;
using System.Collections;
using UnityEngine;

public class Bomb : Items
{
    [SerializeField] private float _explosionRadius = 10;
    [SerializeField] private float _explosionForce = 1000;
    private Exploder _exploder;
    private Renderer _renderer;
    private AlphaChanger _alphaChanger;
    private Color _color;

    public event Action<Bomb> Released;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _alphaChanger = GetComponent<AlphaChanger>();
        _color = _renderer.material.color;
        _exploder = new Exploder(transform.position, _explosionForce, _explosionRadius);
    }

    public override void Init()
    {
        _lifeTime = UnityEngine.Random.Range(_minLifeTime, _maxLifeTime);
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        StartCoroutine(ExecuteAfterTime());
        _alphaChanger.SetLifeTime(_lifeTime, _color);
    }

    private IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(_lifeTime);

        _exploder.Explode();
        Released?.Invoke(this);        
    }
}
