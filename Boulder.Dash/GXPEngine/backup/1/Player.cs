using GXPEngine; // !!!
using System;
public class Player : AnimationSprite
{
    public int i, j;
    private Grid grid;
    Action<string, int, int> SpriteChange;
   // private const int EMPTY = 0, DIRT = 1, ROCK = 2;
    //private int step, animDrawsBetweenFrames;

    public Player(Grid _grid) : base("player.png", 7, 3)
    {
        grid = _grid;
        SpriteChange = delegate (string str, int i, int j)
        {
            grid.SetSprite(str, i, j);
        };
        //step = 0;
        //animDrawsBetweenFrames = 5;
        //add animation when time comes
    }

    void Update()
    {
        handleInput();
        gridUpdate();
    }


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

                    //rock top of rock right
                    else if (grid.GetFilename(_i + 1, _j) == "rock.png" && (grid.GetFilename(_i, _j + 1) == "empty.png" && grid.GetFilename(_i + 1, _j + 1) == "empty.png" && (_i != i || _j + 1 != j) && (_i + 1 != i || _j + 1 != j)))
                    {
                        grid.SetSprite("empty.png", _i, _j);

                        grid.SetSprite("rock.png", _i + 1, _j + 1);
                    }

                    //rock top of rock left
                    else if (grid.GetFilename(_i + 1, _j) == "rock.png" && grid.GetFilename(_i, _j - 1) == "empty.png" && grid.GetFilename(_i + 1, _j - 1) == "empty.png" && (_i != i || _j - 1 != j) && (_i + 1 != i || _j - 1 != j))
                     {
                     grid.SetSprite("empty.png", _i, _j);
                      
                     grid.SetSprite("rock.png", _i + 1, _j-1);
                    }
                }
            }
    }

    private void dig()
    {
        new Timer(2, SpriteChange("empty.png", i, j));
    }

    void setXY()
    {
        this.x = (this.j + 1) * 32;
        this.y = (this.i + 1) * 32;
    }

    private void handleInput()
    {
        if ((Input.GetKeyDown('d') || Input.GetKeyDown('D')) && j + 1 < grid.cols && grid.GetFilename(i, j + 1) != "rock.png")
        {
            dig();

            j++;
        }
        if ((Input.GetKeyDown('a') || Input.GetKeyDown('A')) && j - 1 >= 0 && grid.GetFilename(i, j - 1) != "rock.png")
        {
            dig();

            j--;
        }
        if ((Input.GetKeyDown('w') || Input.GetKeyDown('W')) && i - 1 >= 0 && grid.GetFilename(i - 1, j) != "rock.png")
        {
            dig();

            i--;
        }
        if ((Input.GetKeyDown('s') || Input.GetKeyDown('S')) && i + 1 < grid.rows && grid.GetFilename(i + 1, j) != "rock.png") ///the 2 square drop, FIXIT, drop happens first then u move on top of it then dig it off rip square, mi onli friend, jk iz good
        {
            dig();

            i++;
        }
        setXY();
    }

}
