using GXPEngine;

public class Animation : AnimationSprite
{
    private int _numbOfFram;
    private int _startFra;
    private float _animationTimer;
    
    public Animation(string animationFile, int column, int row) : base(animationFile, column, row, keepInCache: true)
    {
        _animationTimer = 0f;
    }

    protected void Animate(int startFrame, int numberOfFrames)
    {
        _numbOfFram = numberOfFrames;
        _startFra = startFrame;

        float frameInterval = 100f;

        _animationTimer += Time.deltaTime;
        int currentFrame = (int)(_animationTimer / frameInterval) % _numbOfFram + _startFra;
        SetFrame(currentFrame);
    }
}

