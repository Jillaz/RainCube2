using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Items : MonoBehaviour
{
    [SerializeField] protected float _minLifeTime;
    [SerializeField] protected float _maxLifeTime;
    protected Rigidbody _rigidbody;
    protected float _lifeTime;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void Init()
    {
    }

    protected virtual void ExecuteAction()
    {
    }

    protected IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        ExecuteAction();
    }
}