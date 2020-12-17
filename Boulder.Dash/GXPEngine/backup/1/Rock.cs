using GXPEngine;

public class Rock : AnimationSprite
{
    public Rock() : base("blocks.png",7,1)
    {
        SetFrame(6);
    }

}
/*
 
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