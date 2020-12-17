using GXPEngine;

public class Level : GameObject
{

    private Grid _grid;
    private Player _player;
    private HUD _HUD;
    private Exit _exit;

    private int _rows = 16, _cols = 23;

    public Level()
	{
        _grid = new Grid(_rows, _cols);
        _player = new Player(_grid);
        _exit = new Exit(_player, 12, 2);
        _HUD = new HUD(_player);

        playerSetup();
        gridSetup();

        AddChild(_grid);
        AddChild(_exit);
        AddChild(_player);
        AddChild(_HUD);

    }

    void playerSetup()
    {
        _player.scale = 2;
    }

    void gridSetup()
    {
        _grid.y = 16;
    }

}
