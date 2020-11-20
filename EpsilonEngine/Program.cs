using System;
using EpsilonEngine.Modules.Drivers.MonoGame;
using EpsilonEngine;
public static class Program
{
    [STAThread]
    public static void Main()
    {
        Machine machine = new Machine();
        machine.graphicsDriver = new MonoGameGraphicsDriver(machine);

        Game game = new Game(new EpsilonEngine.Machine());
        game.Initialize();
    }
}