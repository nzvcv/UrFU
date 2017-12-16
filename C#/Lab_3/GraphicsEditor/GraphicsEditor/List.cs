using System;
using System.Drawing;
using DrawablesUI;

namespace GraphicsEditor
{
    public class List : IDrawer
    {
        public void SelectPen(Color color, int width = 1)
        {
            Console.WriteLine("Карандаш/n Цвет: " + color);
            Console.WriteLine("Ширина: " + width);
        }

        public void DrawPoint(PointF point) => Console.WriteLine($"Точка ({point.X}, {point.Y})");
        public void DrawLine(PointF start, PointF end) => Console.WriteLine($"Линия (Точка ({start.X}, {start.Y})," +
            $" Точка ({end.X}, {end.Y})");

        public void DrawEllipseArc(PointF center, SizeF size, float startAngle = 0, float endAngle = 360, float rotate = 0)
        {
            if (size.Width == size.Height)
            {
                Console.WriteLine($"Круг (Точка ({center.X}, {center.Y}), Радиус = {size.Width / 2})");
            }
            else
            {
                Console.WriteLine($"Эллипс (Точка ({center.X}, {center.Y}), Большая ось = {size.Width}, Малая ось = {size.Height}, Поворот = {rotate})");
            }
        }
    }
}
