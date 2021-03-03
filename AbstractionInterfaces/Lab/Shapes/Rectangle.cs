using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public int Height 
        {
            get { return this.height; }
            set { this.height = value; }
        }
        public int Width 
        { get { return this.width; }
            set { this.width = value; }
        }
        public void Draw()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Console.Write('*');
                }

                Console.WriteLine();
            }
        }
    }
}
