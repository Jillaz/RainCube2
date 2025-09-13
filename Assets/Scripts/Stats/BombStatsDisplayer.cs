public class BombStatsDisplayer : StatsDisplayer
{
    private BombSpawner _bombSpawner;

    private void Start()
    {
        _bombSpawner = _genSpawner.GetBombSpawner();

        _bombSpawner.TotalNumberChanged += TotalNumber;
        _bombSpawner.ActiveNumberChanged += ActiveNumber;
        _bombSpawner.TotalGeted += Spawned;
    }

    private void OnDisable()
    {
        _bombSpawner.TotalNumberChanged -= TotalNumber;
        _bombSpawner.ActiveNumberChanged -= ActiveNumber;
        _bombSpawner.TotalGeted -= Spawned;
    }
}