using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Items : MonoBehaviour
{
    [SerializeField] protected float _minLifeTime = 2f;
    [SerializeField] protected float _maxLifeTime = 5f;
    protected Rigidbody _rigidbody;
    protected float _lifeTime;    

    public virtual void Init()
    {
    }
}
