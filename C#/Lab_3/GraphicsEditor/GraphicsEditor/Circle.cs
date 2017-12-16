using System;
using System.Drawing;
using DrawablesUI;

namespace GraphicsEditor
{
    public class Circle : IShape
    {
        float Radius { get; set; }
        Point Center { get; set; }

        public Circle()
        {
            Center = new Point();
        }

        public void TryParse(string[] args)
        {
            float coordinate;

            if (args.Length == 3)
            {
                if (float.TryParse(args[0], out coordinate))
                {
                    Center.X = coordinate;
                }
                else
                {
                    throw new Exception($"Координата X центра круга введена с ошибкой: {args[0]}");
                }

                if (float.TryParse(args[1], out coordinate))
                {
                    Center.Y = coordinate;
                }
                else
                {
                    throw new Exception($"Координата Y центра круга введена с ошибкой: {args[1]}");
                }

                if (float.TryParse(args[2], out coordinate))
                {
                    if (coordinate > 0)
                    {
                        Radius = coordinate;
                    }
                    else
                    {
                        throw new Exception($"Радиус должен быть больше 0: {args[2]}");
                    }
                }
                else
                {
                    throw new Exception($"Радиус введён с ошибкой: {args[2]}");
                }
            }
            else
            {
                throw new Exception($"Круг задают три числа float - координаты его центра и радиус");
            }
        }

        public void Draw(IDrawer drawer)
        {
            drawer.DrawEllipseArc(new PointF(Center.X, Center.Y), new SizeF(Radius * 2, Radius * 2), 0, 360, 0);
        }
    }
}
