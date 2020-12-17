using GXPEngine;
using System;

public class Timer : GameObject
{

    private int _time;
    private Action<string, int, int> _onTimeout;
    private string _filename;
    private int _i, _j;

    public Timer(int time, Action<string, int, int> ontimeout) // multiple constructors? call variables normally maybe 
    {
        _time = time;
        _onTimeout = ontimeout;
       // _filename = filename;
      //  _i = i;
       // _j = j;
    }

    public void Update()
    {
        _time -= Time.deltaTime;
        Console.WriteLine(_time);
        if (_time <= 0)
        {
            _onTimeout();
            Destroy();
        }

    }

}
