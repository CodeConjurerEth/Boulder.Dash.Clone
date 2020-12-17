using System;									// System contains a lot of default C# libraries 
using System.Drawing;                           // System.Drawing contains a library used for canvas drawing below
using GXPEngine;								// GXPEngine contains the engine

public class BoulderDash : Game
{

    public BoulderDash() : base(1920, 1080, false)      // Create a window that's 800x600 and NOT fullscreen
    {
        Level level = new Level();
        AddChild(level);
    }

    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new BoulderDash().Start();                  // Create a "MyGame" and start it
    }
}