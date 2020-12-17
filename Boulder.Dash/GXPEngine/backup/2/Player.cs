using GXPEngine; // !!!
using System;
public class Player : AnimationSprite
{
    private int _i, _j;
    private int timerdelay = 1000;
    public Grid grid;

    // private int step, animDrawsBetweenFrames;



    public Player(Grid grid) : base("player.png", 7, 3)
    {
        _i = 0;
        _j = 0;
        
       // step = 0;
       // animDrawsBetweenFrames = 5;
        //add animation when time comes 
    }

    void Update()
    {
        handleInput();
       // gridUpdate();
    }

    /*
    private void gridUpdate()
    {

        for (int i = 0; i < grid.rows - 1; i++)
            for (int j = 0; j < grid.cols; j++)
            {
                    //rockDrop
                    if (grid.GetFilename(i, j) == "rock.png" && grid.GetFilename(i + 1, j) == "empty.png" && (i + 1 != this._i || j != this._j))
                    {
                    Timer timer00 = new Timer(timerdelay, "empty.png", this.grid, i, j);
                    AddChild(timer00);
                    //grid.SetSprite("empty.png", _i, _j);

                    Timer timer01 = new Timer(timerdelay, "rock.png", this.grid, i + 1, j);
                    AddChild(timer01);
                    grid.SetSprite("rock.png", i + 1, j);
                    }

                    //rock on top of rock/gem 
                    if (grid.GetFilename(i, j) == "rock.png" && grid.GetFilename(i + 1, j) == "rock.png" || grid.GetFilename(i + 1, j) == "gem.png")
                    {
                        
                        //checkBottomLeft
                        if (grid.GetFilename(i, j) == "rock.png" && grid.GetFilename(i, j - 1) == "empty.png" && (grid.GetFilename(i + 1, j - 1) == "empty.png" || grid.GetFilename(i + 1, j - 1) == "rock.png" || grid.GetFilename(i + 1, j-1) =="gem.png") && (i != this._i || j - 1 != this._j) && (i + 1 != this._i || j - 1 != this._j))
                        {
                        grid.SetSprite("empty.png", i, j);

                        grid.SetSprite("rock.png", i , j - 1);
                        }
                        //checkBottomRight
                        else if (grid.GetFilename(i, j) == "rock.png" && j < grid.cols - 1 && grid.GetFilename(i, j + 1) == "empty.png" && (grid.GetFilename(i + 1, j + 1) == "empty.png" || grid.GetFilename(i + 1, j + 1) =="rock.png" || grid.GetFilename(i + 1, j + 1) == "gem.png") && (i != this._i || j + 1 != this._j) && (i + 1 != this._i || j + 1 != this._j))
                         {
                        grid.SetSprite("empty.png", i, j);

                        grid.SetSprite("rock.png", i , j + 1);
                         }
                        
                    }


                    //Gem

                    //gemDrop
                    if (grid.GetFilename(i, j) == "gem.png" && grid.GetFilename(i + 1, j) == "empty.png" && (i + 1 != this._i || j != this._j))
                    {
                    grid.SetSprite("empty.png", i, j);

                    grid.SetSprite("gem.png", i + 1, j);
                    }

                    //gem on top of rock/gem 
                    else if (grid.GetFilename(i, j) == "gem.png" && grid.GetFilename(i + 1, j) == "rock.png" || grid.GetFilename(i + 1, j) == "gem.png")
                    {
                        //checkBottomLeft
                        if (grid.GetFilename(i, j) == "gem.png" && grid.GetFilename(i, j - 1) == "empty.png" && grid.GetFilename(i + 1, j - 1) == "empty.png" && (i != this._i || j - 1 != this._j) && (i + 1 != this._i || j - 1 != this._j))
                        {
                        grid.SetSprite("empty.png", i, j);

                        grid.SetSprite("gem.png", i + 1, j - 1);
                        }

                        //checkBottomRight
                        else if (grid.GetFilename(i, j) == "gem.png" && j < grid.cols - 1 && grid.GetFilename(i, j + 1) == "empty.png" && grid.GetFilename(i + 1, j + 1) == "empty.png" && (i != this._i || j + 1 != this._j) && (i + 1 != this._i || j + 1 != this._j))
                        {
                        grid.SetSprite("empty.png", i, j);

                        grid.SetSprite("gem.png", i + 1, j + 1);
                        }
                    }       
            }
    }*/
    private void dig()
    {
        if (grid.GetFilename(_i, _j) == "dirt.png" || grid.GetFilename(_i, _j) == "gem.png")
            grid.SetSprite("empty.png", _i, _j);
    }


    void setXY()
    {
        this.x = (this._j + 1) * 32;
        this.y = 100 + (this._i + 1) * 32;
    }

    public int GetiPos()
    {
        return _i;
    }

    public int GetjPos()
    {
        return _j;
    }

    private void handleInput()
    {
        if ((Input.GetKeyDown('d') || Input.GetKeyDown('D')) && _j + 1 < grid.cols && grid.GetFilename(_i, _j + 1) != "rock.png" && grid.GetFilename(_i, _j + 1) != "wall.png")
        {
            dig();
            
            _j++;
        }
        if ((Input.GetKeyDown('a') || Input.GetKeyDown('A')) && _j - 1 >= 0 && grid.GetFilename(_i, _j - 1) != "rock.png" && grid.GetFilename(_i, _j - 1) != "wall.png")
        {
            dig();

            _j--;
        }
        if ((Input.GetKeyDown('w') || Input.GetKeyDown('W')) && _i - 1 >= 0 && grid.GetFilename(_i - 1, _j) != "rock.png" && grid.GetFilename(_i-1, _j) != "wall.png")
        {
            dig();

            _i--;
        }
        if ((Input.GetKeyDown('s') || Input.GetKeyDown('S')) && _i + 1 < grid.rows && grid.GetFilename(_i + 1, _j) != "rock.png" && grid.GetFilename(_i + 1, _j) != "wall.png") ///the 2 square drop, FIXIT, drop happens first then u move on top of it then dig it off rip square, mi onli friend, jk iz good
        {
            dig();

            _i++;
        }
        /*
        if (grid.GetFilename(i - 1, j) == "rock.png")
        {
            playerSetup();
            grid.GridSetup(25, 20);
        }
        */
        setXY();

    }
}
