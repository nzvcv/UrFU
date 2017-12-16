using System;
using System.Drawing;
using DrawablesUI;

namespace GraphicsEditor
{
    public class Line : IShape
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public Line()
        {
            Start = new Point();
            End = new Point();
        }

        public void TryParse(string[] args)
        {
            float coordinate;

            if (args.Length == 4)
            {
                if (float.TryParse(args[0], out coordinate))
                {
                   Start.X = coordinate;
                }
                else
                {
                    throw new Exception($"Координата X у первой точки введена с ошибкой: {args[0]}");
                }

                if (float.TryParse(args[1], out coordinate))
                {
                    Start.Y = coordinate;
                }
                else
                {
                    throw new Exception($"Координата Y у первой точки введена с ошибкой: {args[1]}");
                }

                if (float.TryParse(args[2], out coordinate))
                {
                    End.X = coordinate;
                }
                else
                {
                    throw new Exception($"Координата X у второй точки введена с ошибкой: {args[2]}");
                }

                if (float.TryParse(args[3], out coordinate))
                {
                    End.Y = coordinate;
                }
                else
                {
                    throw new Exception($"Координата Y у второй точки введена с ошибкой: {args[3]}");
                }
            }
            else
            {
                throw new Exception("Отрезок задают четыре числа float - его координаты точек начала и конца отрезка");
            }
        }

        public void Draw(IDrawer drawer)
        {
            drawer.DrawLine(new PointF(Start.X, Start.Y), new PointF(End.X, End.Y));
        }

    }
}
