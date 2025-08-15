using System;

public class GenericCounter<T> where T : Spawner
{
    public int Number { get; private set; } = 0;

    public event Action ValueChanged;

    public GenericCounter(T spawner)
    {
        spawner.Spawned += Spawned;
    }

    private void Spawned()
    {
        Number++;
        ValueChanged?.Invoke();
    }
}
