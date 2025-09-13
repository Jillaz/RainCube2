using System;
using System.Collections;
using UnityEngine;

public class Cube : Items
{    
    private bool _isHitPlatform = false;

    public event Action<Cube> Released;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public override void Init()
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
        Released?.Invoke(this);
    }    
}