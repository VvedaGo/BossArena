using System;
using Infrastructure.Services;

public class Coin:ISavedProgress
{
    public Action Changed;
    private WorldData _worldData;
    public int Amount { get; private set;}

    public void Construct(WorldData worldData)
    {
        _worldData = worldData;
    }

    public void Load()
    {
        
    }

    public void Update()
    {
        
    }
}