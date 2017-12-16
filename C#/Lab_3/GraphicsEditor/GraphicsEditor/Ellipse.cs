using System;
using System.Drawing;
using DrawablesUI;

namespace GraphicsEditor
{
    public class Ellipse : IDrawable
    {
        Point Center { get; set; }
        float Size1 { get; set; }
        float Size2 { get; set; }
        float Rotate { get; set; }

        public Ellipse()
        {
            Center = new Point();
        }

        public static bool TryParse2(string[] args, out Ellipse ellipse)
        {
            
        }

        public static Ellipse Parse(string[] args) => null;

       /* public void TryParse(string[] args)
        {
            float coordinate;

            if (args.Length == 5)
            {
                if (float.TryParse(args[0], out coordinate))
                {
                    Center.X = coordinate;
                }
                else
                {
                    throw new Exception($"Координата X центра эллипса введена с ошибкой: {args[0]}");
                }

                if (float.TryParse(args[1], out coordinate))
                {
                    Center.Y = coordinate;
                }


                if (float.TryParse(args[2], out coordinate))
                {
                    Size1 = coordinate;
                }
                
                if (float.TryParse(args[3], out coordinate))
                {
                    Size2 = coordinate;
                }

                if (float.TryParse(args[4], out coordinate))
                {
                    Rotate = coordinate;
                }
            }
        }*/

        public void Draw(IDrawer drawer)
        {
            drawer.DrawEllipseArc(new PointF(Center.X, Center.Y), new SizeF(Size1, Size2), 0, 360, Rotate);
        }
    }
}
