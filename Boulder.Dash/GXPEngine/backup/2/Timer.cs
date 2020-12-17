using GXPEngine;
using System;

public class Timer : GameObject
{

    private int _time;
    private string _filename;
    private int _i, _j;
    private Grid _grid;

    public Timer(int time, string filename, Grid grid, int i, int j) // multiple constructors? call variables normally maybe 
    {
        _grid = grid;
        _time = time;   
        _filename = filename;
        _i = i;
        _j = j;
    }

    public void Update()
    {
        _time -= Time.deltaTime;
        if (_time <= 0)
        {
            _grid.SetSprite(_filename, _i, _j);
            Destroy();
        }

    }

}
