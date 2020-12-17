using GXPEngine;
using System;

public class Rock : Sprite
{
 
    public Rock() : base("rock.png")
    {
        
    }

    public void Update()
    {
       
    }

  

}
/*
 *  if (_i + 1 < _grid.GetRows())
        {
            if (_grid.GetFilename(_i + 1, _j) == "empty.png" && (_player.i != _i || _player.j != _j))
            {
                _grid.SetSprite("empty.png", _i, _j);
                _grid.SetSprite("rock.png", _i + 1, _j);

                _i++;
        
                if (_i + 1 < _grid.GetRows())
                {
                    if (_grid.GetFilename(_i + 1, _j) == "rock.png" || _grid.GetFilename(_i + 1, _j) == "gem.png")
                    {
                        if (_j - 1 > 0 && _grid.GetFilename(_i, _j--) == "empty.png" && _grid.GetFilename(_i + 1, _j - 1) == "empty.png")
                        {
                            _grid.SetSprite("empty.png", _i, _j);
                            _grid.SetSprite("rock.png", _i + 1, _j - 1);

                            _i++;
                            _j--;
                        }
                        else if(_j + 1> _grid.GetCols() && _grid.GetFilename(_i, _j +1) == "empty.png" && _grid.GetFilename(_i+1, _j+1) == "empty.png")
                        {
                            _grid.SetSprite("empty.png", _i, _j);
                            _grid.SetSprite("rock.png", _i + 1, _j + 1);
                            _i++;
                            _j++;
                        }
                    }
                    //Death
                    else if (_player.i == _i + 1 && _player.j == _j)
                    {
                        _grid.SpriteGridSetupP(_grid.GetRows(), _grid.GetCols());
                        _player.PlayerSetup();
                    }
                }

            }

            
        }
 * 
 *  if (_i + 1 < _grid.GetRows() && _grid.GetFilename(_i + 1, _j) == "empty.png")
        {
            if (_player.i != _i || _player.j != _j )
            {
                _grid.SetSprite("empty.png", _i, _j);
                _grid.SetSprite("rock.png", _i + 1, _j);

                _i++;
                //new Timer(5, incrementi);

                if (_i + 1 < _grid.GetRows())
                {

                    //Death
                    if (_player.i == _i + 1 && _player.j == _j)
                    {
                        _grid.SpriteGridSetup(_grid.GetRows(), _grid.GetCols());
                        _player.PlayerSetup();
                    }


                    else if (_grid.GetFilename(_i + 1, _j) == "rock.png" || (_grid.GetFilename(_i + 1, _j) == "gem.png"))
                    {
                        if (_j > 0 && _grid.GetFilename(_i, _j--) == "empty.png")
                        {
                            _grid.SetSprite("empty.png", _i, _j);
                            _grid.SetSprite("rock.png", _i, _j--);

                            _j--;
                        }
                        else if (_j + 1 < _grid.GetCols() && _grid.GetFilename(_i, _j++) == "empty.png")
                        {
                            _grid.SetSprite("empty.png", _i, _j);
                            _grid.SetSprite("rock.png", _i, _j++);

                            _j++;
                        }
                    }
                }
            }
        }
 * 
     private void gridUpdate()
    {

        for (int _i = 0; _i < grid.rows - 1; _i++)
            for (int _j = 0; _j < grid.cols; _j++)
            {
                if (grid.GetFilename(_i, _j) == "rock.png")
                {
                    //rockDrop
                    if (grid.GetFilename(_i + 1, _j) == "empty.png" && (_i + 1 != i || _j != j))
                    {

                        grid.SetSprite("empty.png", _i, _j);

                        grid.SetSprite("rock.png", _i + 1, _j);
                    }

                    //rock on top of rock/gem 
                    if (grid.GetFilename(_i + 1, _j) == "rock.png" || grid.GetFilename(_i + 1, _j) == "gem.png")
                    {
                        //checkBottomLeft
                        if (grid.GetFilename(_i, _j - 1) == "empty.png" && grid.GetFilename(_i + 1, _j - 1) == "empty.png" && (_i != i || _j - 1 != j) && (_i + 1 != i || _j - 1 != j))
                        {
                            grid.SetSprite("empty.png", _i, _j);

                            grid.SetSprite("rock.png", _i + 1, _j - 1);
                        }
                        //checkBottomRight
                        else if (_j < grid.cols - 1 && grid.GetFilename(_i, _j + 1) == "empty.png" && grid.GetFilename(_i + 1, _j + 1) == "empty.png" && (_i != i || _j + 1 != j) && (_i + 1 != i || _j + 1 != j))
                        {
                            grid.SetSprite("empty.png", _i, _j);

                            grid.SetSprite("rock.png", _i + 1, _j + 1);
                        }
                        
                    }
                }


                //Gem
                if (grid.GetFilename(_i, _j) == "gem.png")
                {
                    //gemDrop
                    if (grid.GetFilename(_i + 1, _j) == "empty.png" && (_i + 1 != i || _j != j))
                    {
                        grid.SetSprite("empty.png", _i, _j);

                        grid.SetSprite("gem.png", _i + 1, _j);
                    }

                    //gem on top of rock/gem 
                    else if (grid.GetFilename(_i + 1, _j) == "rock.png" || grid.GetFilename(_i + 1, _j) == "gem.png")
                    {
                        //checkBottomLeft
                        if (grid.GetFilename(_i, _j - 1) == "empty.png" && grid.GetFilename(_i + 1, _j - 1) == "empty.png" && (_i != i || _j - 1 != j) && (_i + 1 != i || _j - 1 != j))
                        {
                            grid.SetSprite("empty.png", _i, _j);

                            grid.SetSprite("gem.png", _i + 1, _j - 1);
                        }

                        //checkBottomRight
                        else if (_j < grid.cols - 1 && grid.GetFilename(_i, _j + 1) == "empty.png" && grid.GetFilename(_i + 1, _j + 1) == "empty.png" && (_i != i || _j + 1 != j) && (_i + 1 != i || _j + 1 != j))
                        {
                            grid.SetSprite("empty.png", _i, _j);

                            grid.SetSprite("gem.png", _i + 1, _j + 1);
                        }
                    }
   
                   
                }
            }
    }
 
    private void gridSetup(int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (j > 14 && i == 4 || j == 15 && (i == 3 || i == 2))
                {
                    spriteGrid[i, j] = new Sprite("rock.png");
                }
                else
                {
                    spriteGrid[i, j] = new Sprite("dirt.png");
                }

                setPos(i, j);
                AddChild(spriteGrid[i, j]);

            }
        }
    }
    
private void gridintUpdate()
{

    for (int _i = 0; _i < grid.rows - 1; _i++)
        for (int _j = 0; _j < grid.cols; _j++)
        {
            if (grid.GetIntSprite(_i, _j) == ROCK)
            {
                //rockDrop
                if (grid.GetIntSprite(_i + 1, _j) == EMPTY && (_i + 1 != i || _j != j))
                {
                    grid.SetIntSprite(EMPTY, _i, _j);

                    grid.SetIntSprite(ROCK, _i + 1, _j);
                }

                //rock top of rock right
                else if (grid.GetIntSprite(_i + 1, _j) == ROCK && (grid.GetIntSprite(_i, _j + 1) == EMPTY && grid.GetIntSprite(_i + 1, _j + 1) == EMPTY && (_i != i || _j + 1 != j) && (_i + 1 != i || _j + 1 != j)))
                {
                    grid.SetIntSprite(EMPTY, _i, _j);

                    grid.SetIntSprite(ROCK, _i + 1, _j + 1);
                }

                //rock top of rock left
                else if (grid.GetIntSprite(_i + 1, _j) == ROCK && grid.GetIntSprite(_i, _j - 1) == EMPTY && grid.GetIntSprite(_i + 1, _j - 1) == EMPTY && (_i != i || _j - 1 != j) && (_i + 1 != i || _j - 1 != j))
                {
                    grid.SetIntSprite(EMPTY, _i, _j);

                    grid.SetIntSprite(ROCK, _i + 1, _j - 1);
                }
            }
        }
}

public void SetIntSprite(int tile, int i, int j)
{
    intGrid[i, j] = tile;
    setPos(i, j);
    AddChild(spriteGrid[i, j]);
}

public int GetIntSprite(int i, int j)
{
    return intGrid[i, j];
}

private void intSpriteDraw(int rows, int cols)
{
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            switch (intGrid[i, j])
            {
                case (ROCK):
                    {
                        spriteGrid[i, j] = new Sprite("rock.png");
                        break;
                    }
                case (DIRT):
                    {
                        spriteGrid[i, j] = new Sprite("dirt.png");
                        break;
                    }
                case (EMPTY):
                    {
                        spriteGrid[i, j] = new Sprite("empty.png");
                        break;
                    }
            }
            setPos(i, j);
            AddChild(spriteGrid[i, j]);
        }
    }
}


private void intGridSetup(int rows, int cols)
{
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            if (j > 14 && i == 4 || j == 15 && (i == 3 || i == 2))
            {
                intGrid[i, j] = ROCK;

            }
            else
            {
                intGrid[i, j] = DIRT;
            }
        }
    }
}
*/
