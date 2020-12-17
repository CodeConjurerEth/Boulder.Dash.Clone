using GXPEngine;

public class Player : Animation
{
    private int _i, _j;
    private Grid _grid;
    private int _gemScore, _gemWin = 10;

    private Sound _pickupSound;
    private Sound _deathSound;
    private Sound _digSound;
    private Sound _winSound;

    public Player(Grid grid) : base("player.png", 7, 3)
    {
        _grid = grid;
        _pickupSound = new Sound("pickupgem.wav");
        _deathSound = new Sound("ded.wav");
        _digSound = new Sound("dig.wav");
        _winSound = new Sound("win.wav");
        playerSetup();
    }

    public void Update()
    {
        handleInput();
        gridUpdate();
        animationHandler();
    }

    private void playerSetup()
    {
        _gemScore = 0;
        _i = 1;
        _j = 1;

    }
    private void gridUpdate()
    {

        for (int i = 0; i < _grid.GetRows() - 1; i++)
            for (int j = 0; j < _grid.GetCols(); j++)
            {
                rockUpdate(i, j);
                gemUpdate(i, j);

            }
    }



    private void dig(int i, int j)
    {
        if (_grid.GetFilename(i, j) == "dirt.png" || _grid.GetFilename(i, j) == "rock.png")
        {
            _grid.SetSprite("empty.png", i, j);
            _digSound.Play();
        }
        else if (_grid.GetFilename(i, j) == "gem.png")
            _grid.SetSprite("empty.png", i, j);
    }

    private void gemCheck(int i, int j)
    {
        if (_grid.GetFilename(i, j) == "gem.png")
        {
            _gemScore++;
            _pickupSound.Play();
        }
    }

    private void exitCheck(int i, int j)
    {
        //Win
        if (_grid.GetFilename(i, j) == "exit.png")
        {
            _winSound.Play();
            _grid.SpriteGridSetup(_grid.GetRows(), _grid.GetCols());
            playerSetup();
        }

    }

    private void handleInput()
    {

        if ((Input.GetKeyDown('d') || Input.GetKeyDown('D')) && _j + 1 < _grid.GetCols() && _grid.GetFilename(_i, _j + 1) != "wall.png")
        {
            //push a rock if there is an empty space behind it
            if (_j + 2 < _grid.GetCols() && _grid.GetFilename(_i, _j + 1) == "rock.png" && _grid.GetFilename(_i, _j + 2) == "empty.png")
            {
                dig(_i, _j + 1);
                _grid.SetSprite("rock.png", _i, _j + 2);
                //SetFrame(15);

                _j++;
            }

            if (_grid.GetFilename(_i, _j + 1) != "rock.png")
            {
                gemCheck(_i, _j + 1);
                exitCheck(_i, _j + 1);
                dig(_i, _j + 1);
                //SetFrame(15);

                _j++;
            }
        }

        if ((Input.GetKeyDown('a') || Input.GetKeyDown('A')) && _j - 1 >= 0 && _grid.GetFilename(_i, _j - 1) != "wall.png")
        {
            //push a rock if there is an empty space behind it
            if (_j - 2 >= 0 && _grid.GetFilename(_i, _j - 1) == "rock.png" && _grid.GetFilename(_i, _j - 2) == "empty.png")
            {
                dig(_i, _j - 1);
                _grid.SetSprite("rock.png", _i, _j - 2);
                //SetFrame(8);

                _j--;
            }

            if (_grid.GetFilename(_i, _j - 1) != "rock.png")
            {
                gemCheck(_i, _j - 1);
                exitCheck(_i, _j - 1);
                dig(_i, _j - 1);
                // SetFrame(8);

                _j--;
            }
        }

        if ((Input.GetKeyDown('w') || Input.GetKeyDown('W')) && _i - 1 >= 0 && _grid.GetFilename(_i - 1, _j) != "rock.png" && _grid.GetFilename(_i - 1, _j) != "wall.png")
        {
            gemCheck(_i - 1, _j);
            exitCheck(_i - 1, _j);
            dig(_i - 1, _j);
            //SetFrame(6);
            _i--;
        }

        if ((Input.GetKeyDown('s') || Input.GetKeyDown('S')) && _i + 1 < _grid.GetRows() && _grid.GetFilename(_i + 1, _j) != "rock.png" && _grid.GetFilename(_i + 1, _j) != "wall.png")
        {
            gemCheck(_i + 1, _j);
            exitCheck(_i + 1, _j);
            dig(_i + 1, _j);
            //SetFrame(3);
            _i++;
        }
        setXY();
    }

    private void setXY()
    {
        this.x = (this._j + 1) * 32;
        this.y = 16 + (this._i + 1) * 32;
    }

    private void rockUpdate(int _i, int _j)
    {
        if (_grid.GetFilename(_i, _j) == "rock.png")
        {
            //rockDrop
            if (_grid.GetFilename(_i, _j) == "rock.png" && _grid.GetFilename(_i + 1, _j) == "empty.png" && (_i + 1 != this._i || _j != this._j))
            {
                _grid.SetSprite("empty.png", _i, _j);

                _grid.SetSprite("rock.png", _i + 1, _j);


                if (_i + 2 == this._i && _j == this._j)
                {
                    playerLose();
                }
            }

            //rock on top of rock/gem bottom right
            else if (_grid.GetFilename(_i, _j) == "rock.png" && (_grid.GetFilename(_i + 1, _j) == "rock.png" || _grid.GetFilename(_i + 1, _j) == "gem.png") && (_grid.GetFilename(_i, _j + 1) == "empty.png" && _grid.GetFilename(_i + 1, _j + 1) == "empty.png" && (_i != this._i || _j + 1 != this._j) && (_i + 1 != this._i || _j + 1 != this._j)))
            {
                _grid.SetSprite("empty.png", _i, _j);

                _grid.SetSprite("rock.png", _i + 1, _j + 1);

                if (_i + 2 == this._i && _j + 1 == this._j)
                {
                    playerLose();
                }
            }

            //rock on top of rock bottom left
            else if (_grid.GetFilename(_i, _j) == "rock.png" && (_grid.GetFilename(_i + 1, _j) == "rock.png" || _grid.GetFilename(_i + 1, _j) == "gem.png") && _grid.GetFilename(_i, _j - 1) == "empty.png" && _grid.GetFilename(_i + 1, _j - 1) == "empty.png" && (_i != this._i || _j - 1 != this._j) && (_i + 1 != this._i || _j - 1 != this._j))
            {
                _grid.SetSprite("empty.png", _i, _j);

                _grid.SetSprite("rock.png", _i + 1, _j - 1);

                if (_i + 2 == this._i && _j - 1 == this._j)
                {
                    playerLose();
                }
            }
        }
    }

    private void gemUpdate(int i, int j)
    {
        if (_grid.GetFilename(i, j) == "gem.png")
        {
            //gemDrop
            if (_grid.GetFilename(i, j) == "gem.png" && _grid.GetFilename(i + 1, j) == "empty.png" && (i + 1 != this._i || j != this._j))
            {
                _grid.SetSprite("empty.png", i, j);

                _grid.SetSprite("gem.png", i + 1, j);


                if (i + 2 == this._i && j == this._j)
                {
                    playerLose();
                }
            }

            //gem on top of rock/gem check bottom right
            else if (_grid.GetFilename(i, j) == "gem.png" && (_grid.GetFilename(i + 1, j) == "rock.png" || _grid.GetFilename(i + 1, j) == "gem.png") && (_grid.GetFilename(i, j + 1) == "empty.png" && _grid.GetFilename(i + 1, j + 1) == "empty.png" && (i != this._i || j + 1 != this._j) && (i + 1 != this._i || j + 1 != this._j)))
            {
                _grid.SetSprite("empty.png", i, j);

                _grid.SetSprite("rock.png", i + 1, j + 1);


                if (i + 2 == this._i && j + 1 == this._j)
                {
                    playerLose();
                }
            }

            //gem on top of rock/gem check bottom left
            else if (_grid.GetFilename(i, j) == "gem.png" && (_grid.GetFilename(i + 1, j) == "rock.png" || _grid.GetFilename(i + 1, j) == "gem.png") && _grid.GetFilename(i, j - 1) == "empty.png" && _grid.GetFilename(i + 1, j - 1) == "empty.png" && (i != this._i || j - 1 != this._j) && (i + 1 != this._i || j - 1 != this._j))
            {
                _grid.SetSprite("empty.png", i, j);

                _grid.SetSprite("rock.png", i + 1, j - 1);


                if (i + 2 == this._i && j - 1 == this._j)
                {
                    playerLose();
                }
            }
        }
    }

    private void animationHandler()
    {
        if (Input.GetKey(Key.A) || Input.GetKey(Key.W))
            Animate(7, 7);
        else if (Input.GetKey(Key.D) || Input.GetKey(Key.S))
            Animate(14, 7);
        else
            Animate(0, 7);
    }

    private void playerLose()
    {
        _deathSound.Play();
        _grid.SpriteGridSetup(_grid.GetRows(), _grid.GetCols());
        playerSetup();
    }

    public int GetScore()
    {
        return _gemScore;
    }

    public int GetWinScore()
    {
        return _gemWin;
    }

    public Grid GetGrid()
    {
        return _grid;
    }
}