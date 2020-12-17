using GXPEngine;

public class FollowEmpty : Sprite
{
    private int _i, _j;
    private Grid _grid;

    public FollowEmpty(int i, int j, Grid grid) : base("FollowEmpty.png")
    {
        _i = i;
        _j = j;
        _grid = grid;
    }

    public void Update()
    {
        if (_grid.GetFilename(_i + 1, _j) == " empty.png ")
        {
            _grid.SetSprite("empty.png", _i, _j);
            _grid.SetSprite("FollowEmpty.png", _i + 1, _j);
            _i++;
        }
        else if (_grid.GetFilename(_i - 1, _j) == " empty.png ")
        {
            _grid.SetSprite("empty.png", _i, _j);
            _grid.SetSprite("FollowEmpty.png", _i - 1, _j);
            _i--;
        }
        else if (_grid.GetFilename(_i, _j + 1) == " empty.png ")
        {
            _grid.SetSprite("empty.png", _i, _j);
            _grid.SetSprite("FollowEmpty.png", _i, _j + 1);
            _j++;
        }
        else if (_grid.GetFilename(_i, _j - 1) == " empty.png ")
        {
            _grid.SetSprite("empty.png", _i, _j);
            _grid.SetSprite("FollowEmpty.png", _i, _j - 1);
            _j--;
        }
        
    }
}
