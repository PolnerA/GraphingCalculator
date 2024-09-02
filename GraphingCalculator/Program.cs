using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.ComponentModel.Design;
using System.Collections;

namespace GraphingCalculator
{
    internal class Program
    {
        private static RenderWindow _window;
            
        static void Main(string[] args)
        {
            Function Function=new Mult();
            Hashtable table = new Hashtable();
            table.Add(1, 2);
            table.Add(2, 3);
            Function.left = new Number(3);
            Function.right = new Number(3);
            var shape = new RectangleShape(new Vector2f(1, 1)) { FillColor=Color.White };
            _window =  new RenderWindow(new VideoMode(1000, 1000), "Graphing Calculator");
            _window.Closed += ClosedEventHandler;
            int x = 500;
            int y = 500;
            float ViewSize = 1f;
            Console.WriteLine(Function.PerformOperation(1));
            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear(Color.Black);
                _window.Draw(shape);
                if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                {
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
                    ViewSize*=1.1f;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.LControl))
                {
                    ViewSize*=0.9f;
                }
                shape=new RectangleShape(new Vector2f(ViewSize, ViewSize)) { FillColor=Color.White };
                shape.Position=new Vector2f(x, y);
                _window.Display();
            }
        }
        static void ClosedEventHandler(object sender, EventArgs e)
        {
            _window.Close();
        }
        
    }
}