using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 10;
    [SerializeField] private float _explosionForce = 1000;
    [SerializeField] private float _minLifeTime = 2f;
    [SerializeField] private float _maxLifeTime = 5f;        
    private Rigidbody _rigidbody;
    private Renderer _renderer;
    private AlphaChanger _alphaChanger;
    private Color _color;
    private float _lifeTime;

    public event Action<Bomb> Release;

    public void Init()
    {
        _lifeTime = UnityEngine.Random.Range(_minLifeTime, _maxLifeTime);
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        StartCoroutine(ExecuteAfterTime());
        _alphaChanger.SetLifeTime(_lifeTime, _color);
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _alphaChanger = GetComponent<AlphaChanger>();
        _color = _renderer.material.color;
    }  

    private void Explode()
    {
        List<Rigidbody> explodingObjects = GetExplodableObjects();
        Vector3 distance;
        float calculatedExplosionForce;
        float explosionForcePerUnitDistance;

        explosionForcePerUnitDistance = _explosionForce / _explosionRadius;

        foreach (var item in explodingObjects)
        {
            distance = item.transform.position - transform.position;

            if (distance.magnitude >= _explosionRadius)
            {
                continue;
            }

            calculatedExplosionForce = explosionForcePerUnitDistance * (_explosionRadius - distance.magnitude);
            item.AddExplosionForce(calculatedExplosionForce, transform.position, _explosionRadius);            
        }
    }

    private IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(_lifeTime);

        Explode();
        Release?.Invoke(this);        
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        List<Rigidbody> cubes = new();
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider item in hits)
        {
            if (item.attachedRigidbody != null)
            {
                cubes.Add(item.attachedRigidbody);
            }
        }

        return cubes;
    }
}
