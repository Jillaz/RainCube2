using UnityEngine;

public class Counter : MonoBehaviour
{    
    [SerializeField] private Spawner _spawner;

    public int Number { get; private set; } = 0;

    private void OnEnable()
    {
        _spawner.Spawned += Spawned;
    }

    private void OnDisable()
    {
        _spawner.Spawned -= Spawned;
    }

    private void Spawned()
    {
        Number++;
    }
}
