using GXPEngine;

public class Grid : GameObject
{
    private Sprite[,] _spriteGrid;

    private int _cols, _rows;
    private int[,] _intGrid; 

    public Grid(int rows, int cols) : base()
    {
        _cols = cols;
        _rows = rows;        
        
       
        _spriteGrid = new Sprite[rows, cols];
        intGridSetup();
        SpriteGridSetup(rows, cols);

    }

    private void intGridSetup()
    {
        _intGrid = new int[16, 23]
        {
            {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
            {3, 0, 1, 2, 2, 1, 1, 2, 4, 1, 1, 1, 1, 2, 1, 1, 1, 1, 4, 1, 1, 4, 3},
            {3, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 3},
            {3, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 2, 2, 3},
            {3, 1, 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 3},
            {3, 3, 3, 3, 3, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3},
            {3, 1, 2, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2, 2, 3},
            {3, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 4, 3},
            {3, 1, 1, 2, 1, 1, 1, 1, 4, 1, 1, 1, 1, 2, 1, 1, 2, 1, 4, 1, 1, 1, 3},
            {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3},
            {3, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 1, 1, 1, 3},
            {3, 1, 1, 2, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 1, 2, 1, 2, 1, 1, 1, 2, 3},
            {3, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3},
            {3, 1, 1, 2, 1, 1, 1, 1, 4, 1, 1, 1, 1, 2, 1, 1, 4, 1, 2, 1, 1, 1, 3},
            {3, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 3},
            {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
           
        };
    }

    public void SpriteGridSetup(int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                switch (_intGrid[i, j])
                {
                    case 0:
                        _spriteGrid[i, j] = new Sprite("empty.png");
                        break;
                    case 1:
                        _spriteGrid[i, j] = new Sprite("dirt.png");
                        break;
                    case 2:
                        _spriteGrid[i, j] = new Sprite("rock.png");
                        break;
                    case 3:
                        _spriteGrid[i, j] = new Sprite("wall.png");
                        break;
                    case 4:
                        _spriteGrid[i, j] = new Sprite("gem.png");
                        break;

                }
                setPos(i, j);
                AddChild(_spriteGrid[i, j]);
            }
        }
    }

    private void setPos(int i, int j)
    {
        _spriteGrid[i, j].x = (j + 1) * 32;
        _spriteGrid[i, j].y = (i + 1) * 32;
        _spriteGrid[i, j].scale = 2;
    }

    public void SetSprite(string filename, int i, int j)
    {
        _spriteGrid[i, j] = new Sprite(filename);
        setPos(i, j);
        AddChild(_spriteGrid[i, j]);
    }
    public void SetAnimationSprite(string filename, int cols, int rows, int i, int j)
    {
        _spriteGrid[i, j] = new AnimationSprite(filename, cols, rows);
        setPos(i, j);
        AddChild(_spriteGrid[i, j]);
    }

    public string GetFilename(int i, int j)
    {
        return _spriteGrid[i, j].texture.filename;
    }

    public int GetCols()
    {
        return _cols;
    }

    public int GetRows()
    {
        return _rows;
    }

    

    /*
    private void dig()
    {
        if (GetFilename(_player.i, _player.j) == "dirt.png" || GetFilename(_player.i, _player.j) == "gem.png")
            SetSprite("empty.png", _player.i, _player.j);
    }

    private void handleInput()
    {
        if ((Input.GetKeyDown('d') || Input.GetKeyDown('D')) && _player.j + 1 < _cols && GetFilename(_player.i, _player.j + 1) != "rock.png" && GetFilename(_player.i, _player.j + 1) != "wall.png")
        {
            dig();

            _player.j++;
        }
        if ((Input.GetKeyDown('a') || Input.GetKeyDown('A')) && _player.j - 1 >= 0 && GetFilename(_player.i, _player.j - 1) != "rock.png" && GetFilename(_player.i, _player.j - 1) != "wall.png")
        {
            dig();

            _player.j--;
        }
        if ((Input.GetKeyDown('w') || Input.GetKeyDown('W')) && _player.i - 1 >= 0 && GetFilename(_player.i - 1, _player.j) != "rock.png" && GetFilename(_player.i - 1, _player.j) != "wall.png")
        {
            dig();

            _player.i--;
        }
        if ((Input.GetKeyDown('s') || Input.GetKeyDown('S')) && _player.i + 1 < _rows && GetFilename(_player.i + 1, _player.j) != "rock.png" && GetFilename(_player.i + 1, _player.j) != "wall.png")
        {
            dig();

            _player.i++;
        }
        playerSetXY();

    }



    private void playerSetXY()
    {
        _player.x = (_player.j + 1) * 32;
        _player.y = 16 + (_player.i + 1) * 32;
    }
    */

}

