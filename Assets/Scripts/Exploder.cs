using System.Collections.Generic;
using UnityEngine;

public class Exploder
{
    private Vector3 _objectTransform;
    private float _explosionForce;
    private float _explosionRadius;

    public Exploder(Vector3 objectTransform, float explosionForce, float explosionRadius)
    {
        _objectTransform = objectTransform;
        _explosionForce = explosionForce;
        _explosionRadius = explosionRadius;
    }

    public void Explode()
    {
        List<Rigidbody> explodingObjects = GetExplodableObjects();
        Vector3 distance;
        float calculatedExplosionForce;
        float explosionForcePerUnitDistance;

        explosionForcePerUnitDistance = _explosionForce / _explosionRadius;

        foreach (var item in explodingObjects)
        {
            distance = item.transform.position - _objectTransform;

            if (distance.magnitude >= _explosionRadius)
            {
                continue;
            }

            calculatedExplosionForce = explosionForcePerUnitDistance * (_explosionRadius - distance.magnitude);
            item.AddExplosionForce(calculatedExplosionForce, _objectTransform, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        List<Rigidbody> explodingObjects = new();
        Collider[] hits = Physics.OverlapSphere(_objectTransform, _explosionRadius);

        foreach (Collider item in hits)
        {
            if (item.attachedRigidbody != null)
            {
                explodingObjects.Add(item.attachedRigidbody);
            }
        }

        return explodingObjects;
    }
}
