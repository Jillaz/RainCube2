using System;
using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 10;
    [SerializeField] private float _explosionForce = 1000;
    [SerializeField] private float _minLifeTime = 2f;
    [SerializeField] private float _maxLifeTime = 5f;    
    private Exploder _exploder;
    private Rigidbody _rigidbody;
    private Renderer _renderer;
    private AlphaChanger _alphaChanger;
    private Color _color;
    private float _lifeTime;

    public event Action<Bomb> Release;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _alphaChanger = GetComponent<AlphaChanger>();
        _color = _renderer.material.color;
        _exploder = new Exploder(transform.position, _explosionForce, _explosionRadius);
    }

    public void Init()
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
        Release?.Invoke(this);        
    }
}
