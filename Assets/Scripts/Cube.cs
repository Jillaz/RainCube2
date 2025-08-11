using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _minLifeTime = 2f;
    [SerializeField] private float _maxLifeTime = 5f;
    private Rigidbody _rigidbody;
    private float _lifeTime;
    private bool _isHitPlatform = false;

    public event Action<Cube> Release;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetDefaults()
    {
        _isHitPlatform = false;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Platform platform))
        {
            if (_isHitPlatform == false)
            {                
                _isHitPlatform = true;
                _lifeTime = UnityEngine.Random.Range(_minLifeTime, _maxLifeTime);
                StartCoroutine(ExecuteAfterTime());
            }
        }
    }

    private IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        Release?.Invoke(this);
    }    
}