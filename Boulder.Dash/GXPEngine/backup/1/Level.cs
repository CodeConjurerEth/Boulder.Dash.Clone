using GXPEngine;

public class Level : GameObject
{
    //Remove dirt, falling stones and gems. Picking up gems, being killed by stones. Enemies that wander within open space. End when enough gems collected.

    private Grid grid;
    private Player player;

    public Level()
	{
        grid = new Grid(25, 20);
        player = new Player(grid);

        playerSetup();

        AddChild(grid);
        AddChild(player);

    }

    void playerSetup()
    {
        player.i = 0;
        player.j = 0;
        player.x = (player.j + 1) * 16;
        player.y = (player.i + 1) * 16;
        player.scale = 2;
    }

}
