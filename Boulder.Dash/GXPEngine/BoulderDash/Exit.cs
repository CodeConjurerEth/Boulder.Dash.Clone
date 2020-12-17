using System;
using GXPEngine;

public class Exit : GameObject
{
    private int _exitiPos, _exitjPos;
    private Player _player;
    private Grid _grid;

    public Exit(Player player, int exitiPos, int exitjPos)
	{
        _player = player;
        _exitiPos = exitiPos;
        _exitjPos = exitjPos;
        _grid = _player.GetGrid();
	}

    public void Update()
    {
        exitCheck(_exitiPos, _exitjPos);
    }

    private void exitCheck(int exitiPos, int exitjPos)
    {
        if (_player.GetScore() >= _player.GetWinScore())
        {
            _grid.SetSprite("exit.png", exitiPos, exitjPos);
            
        }
    }

}
