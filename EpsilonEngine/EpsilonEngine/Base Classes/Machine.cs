using System.Collections.Generic;
namespace EpsilonEngine
{
    public class Machine
    {
        private InputDriver _inputDriver = null;
        private GraphicsDriver _graphicsDriver = null;
        public InputDriver inputDriver = null;
        public GraphicsDriver graphicsDriver = null;

        public List<Game> games = new List<Game>();
    }
}
