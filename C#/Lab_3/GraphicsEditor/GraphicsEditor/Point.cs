using System;
using System.Drawing;
using DrawablesUI;

namespace GraphicsEditor
{
    public class Point : IShape
    {
        public float X { get; set; }

        public float Y { get; set; }

        public static bool TryParse(string[] args, out Point point)
        {
            float coordinate;

            if (args.Length == 2)
            {
                if (float.TryParse(args[0], out coordinate))
                {
                    X = coordinate;
                }
                else
                {
                    throw new Exception($"Координата X введена с ошибкой: {args[0]}");
                }

                if (float.TryParse(args[1], out coordinate))
                {
                    Y = coordinate;
                }
                else
                {
                    throw new Exception($"Координата Y введена с ошибкой: {args[1]}");
                }
            }
            else
            {
                throw new Exception("Точку задают два числа float - её координаты");
            }
        }

        public void TryParse(string[] args)
        {
            float coordinate;

            if (args.Length == 2)
            {
                if (float.TryParse(args[0], out coordinate))
                {
                    X = coordinate;
                }
                else
                {
                    throw new Exception($"Координата X введена с ошибкой: {args[0]}");
                }

                if (float.TryParse(args[1], out coordinate))
                {
                    Y = coordinate;
                }
                else
                {
                    throw new Exception($"Координата Y введена с ошибкой: {args[1]}");
                }
            }
            else
            {
                throw new Exception("Точку задают два числа float - её координаты");
            }
        }

        public void Draw(IDrawer drawer)
        {
            drawer.DrawPoint(new PointF(X, Y));
        }
    }
}
