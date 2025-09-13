public class CubeStatsDisplayer : StatsDisplayer
{   
    private CubeSpawner _cubeSpawner; 

    private void Start()
    {
        _cubeSpawner = _genSpawner.GetCubeSpawner();

        _cubeSpawner.TotalNumberChanged += TotalNumber;
        _cubeSpawner.ActiveNumberChanged += ActiveNumber;
        _cubeSpawner.TotalGeted += Spawned;
    }

    private void OnDisable()
    {
        _cubeSpawner.TotalNumberChanged -= TotalNumber;
        _cubeSpawner.ActiveNumberChanged -= ActiveNumber;
        _cubeSpawner.TotalGeted -= Spawned;
    }
}