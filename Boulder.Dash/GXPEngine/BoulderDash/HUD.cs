using System;
using System.Drawing;
using GXPEngine;

public class HUD : Canvas 
{
    private Player _player;
    public int x1, x2;
    private Sprite ws1, ws2, cs1, cs2, dots;
    public HUD(Player player) : base(800, 32)
	{
        _player = player;

        x1 = _player.GetWinScore();
        ws2 = new Sprite((x1 % 10).ToString() + ".png");
        if(x1 != 0)
            x1 /= 10;
        ws1 = new Sprite((x1 % 10).ToString() + ".png");

        dots = new Sprite("dots.png");

        x2 = _player.GetScore();
        cs2 = new Sprite((x2 % 10).ToString() + ".png");
        if (x2 != 0)
            x2 /= 10;
        cs1 = new Sprite((x2 % 10).ToString() + ".png");

        AddChild(dots);
        AddChild(ws1);
        AddChild(ws2);
        AddChild(cs1);
        AddChild(cs2);

        cs1.y = 10;
        cs1.x = 260;
        cs1.scale = 3.5f;

        cs2.y = 10;
        cs2.x = 320;
        cs2.scale = 3.5f;

        dots.y = 10;
        dots.x = 370;
        dots.scale = 3.5f;

        ws1.y = 10;
        ws1.x = 420;
        ws1.scale = 3.5f;

        ws2.y = 10;
        ws2.x = 480;
        ws2.scale = 3.5f;

    }

    public void Update()
    {
        if (x2 != _player.GetScore())
        {
            x2 = _player.GetScore();
            cs1.Destroy();
            cs2.Destroy();
            cs2 = new Sprite((x2 % 10).ToString() + ".png");
            if (x2 != 0)
                x2 /= 10;
            cs1 = new Sprite((x2 % 10).ToString() + ".png");

            AddChild(cs1);
            AddChild(cs2);

            cs1.y = 10;
            cs1.x = 260;
            cs1.scale = 3.5f;

            cs2.y = 10;
            cs2.x = 320;
            cs2.scale = 3.5f;
        }
    }
}
