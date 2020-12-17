using GXPEngine;

public class Grid : GameObject
{
    public Sprite[,] spriteGrid;
    public int cols, rows;

    public Grid(int _rows, int _cols) : base()
    {
        cols = _cols;
        rows = _rows;
        spriteGrid = new Sprite[rows, cols];
        
    }

    private void spriteGridSetup(int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (i == 0 && j != 0)
                    spriteGrid[i, j] = new Rock(this, player, i, j);
                else if (i == 15)
                    .spriteGrid[i, j] = new Sprite("wall.png");
                else if (j > 14 && i == 4 || j == 15 && (i == 3 || i == 2))
                {
                    spriteGrid[i, j] = new Rock(this, player, i, j);
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

    public void SetSprite(string filename, int i, int j)
    {
        spriteGrid[i, j] = new Sprite(filename);
        setPos(i, j);
        AddChild(spriteGrid[i, j]);
    }

    public void SetAnimationSprite(string filename, int cols, int rows, int i, int j)
    {
        spriteGrid[i, j] = new AnimationSprite(filename, cols, rows);
        setPos(i, j);
        AddChild(spriteGrid[i, j]);
    }

    public string GetFilename(int i, int j)
    {
        return spriteGrid[i, j].texture.filename;
    }

    private void setPos(int i, int j)
    {
        spriteGrid[i, j].x = (j + 1) * 32;
        spriteGrid[i, j].y = (i + 1) * 32;
        spriteGrid[i, j].scale = 2;
    }

}
