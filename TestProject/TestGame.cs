using EpsilonEngine;
public sealed class TestGame : Game
{
    public TestGame() : base(0, 0)
    {
        IsFullScreen = true;
        KillProcessOnExit = true;
        TargetFPS = 60.0;
    }
}