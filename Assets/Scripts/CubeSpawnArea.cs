using UnityEngine;

public class CubeSpawnArea : MonoBehaviour
{
    public Vector3 GetSpawnPosition()
    {
        float defaultLenghtFromCenter = 5f;
        float scaleFactorX;
        float scaleFactorZ;
        float minPositionX;
        float maxPositionX;
        float postitionX;
        float minPositionZ;
        float maxPositionZ;
        float postitionZ;
        float postitionY;

        scaleFactorX = transform.localScale.x;
        scaleFactorZ = transform.localScale.z;

        minPositionX = transform.position.x - defaultLenghtFromCenter * scaleFactorX;
        maxPositionX = transform.position.x + defaultLenghtFromCenter * scaleFactorX;

        minPositionZ = transform.position.z - defaultLenghtFromCenter * scaleFactorZ;
        maxPositionZ = transform.position.z + defaultLenghtFromCenter * scaleFactorZ;

        postitionX = UnityEngine.Random.Range(minPositionX, maxPositionX);
        postitionZ = UnityEngine.Random.Range(minPositionZ, maxPositionZ);
        postitionY = transform.position.y;

        return new Vector3(postitionX, postitionY, postitionZ);
    }
}