using GXPEngine;

public class Level : GameObject
{
    //Remove dirt, falling stones and gems. Picking up gems, being killed by stones. Enemies that wander within open space. End when enough gems collected.

    private Grid grid;
    private Player player;
    private int rows = 20, cols = 25;

    public Level()
	{
        grid = new Grid(rows,cols);
        player = new Player(grid);      
     

        playerSetup();
        gridSetup();

        AddChild(grid);
        AddChild(player);

    }

    void playerSetup()
    {
        player.scale = 2;
    }

    void gridSetup()
    {
        grid.y = 100;
    }

}
