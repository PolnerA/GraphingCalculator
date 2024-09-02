using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace GraphingCalculator
{
    internal class Program
    {
        private static RenderWindow _window;
        static void Main(string[] args)
        {
            var shape = new RectangleShape(new Vector2f(100, 100)) { FillColor=Color.White };
            _window =  new RenderWindow(new VideoMode(1000, 1000), "Graphing Calculator");
            _window.Closed += ClosedEventHandler;
            int x = 500;
            int y = 500;
            double ViewSize = 1;
            while (_window.IsOpen) 
            {
                _window.DispatchEvents();
                _window.Clear(Color.Black);
                _window.Draw(shape);
                if (Keyboard.IsKeyPressed(Keyboard.Key.D)){
                    x--;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                {
                    y++;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                {
                    x++;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                {
                    y--;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.LShift)) 
                {
                    ViewSize*=1.1;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.LControl))
                {
                    ViewSize*=0.9;
                }
                shape.Position=new Vector2f(x, y);
                _window.Display();
            }
        }
        private static void ClosedEventHandler(object sender, EventArgs e)
        {
            _window.Close();
        }
    }
}