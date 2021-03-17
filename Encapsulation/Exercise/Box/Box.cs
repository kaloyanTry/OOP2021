using System;
using System.Text;

namespace _1.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                length = value;
            }
        }

        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                width = value;
            }
        }

        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            return 2.0 * Length * Width + 2.0 * Length * Height + 2.0 * Width * Height;
        }

        public double CalculateLateralSurfaceArea()
        {
            return 2.0 * Length * Height + 2.0 * Width * Height;
        }
        public double CalculateValume()
        {
            return Length * Width * Height;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {CalculateSurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {CalculateLateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {CalculateValume():F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
