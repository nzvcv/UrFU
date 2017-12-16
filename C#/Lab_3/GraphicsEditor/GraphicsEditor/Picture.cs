using System;
using System.Collections.Generic;
using DrawablesUI;

namespace GraphicsEditor
{
    public class Picture : IDrawable
    {
        private readonly List<IDrawable> shapes = new List<IDrawable>();
        private readonly object lockObject = new object();
        public IEnumerable<IDrawable> Shapes { get { return shapes; } }

        public event Action Changed;

        public void Remove(IDrawable shape)
        {
            lock (lockObject)
            {
                shapes.Remove(shape);
            }
        }

        public void RemoveAt(int index)
        {
            lock (lockObject)
            {
                shapes.RemoveAt(index);
                Changed?.Invoke();
            }
        }

        public void Add(IDrawable shape)
        {
            lock (lockObject)
            {
                shapes.Add(shape);
                Changed?.Invoke();
            }
        }

        public void Add(int index, IDrawable shape)
        {
            lock (lockObject)
            {
                shapes.Insert(index, shape);
                Changed?.Invoke();
            }
        }

        public void Print()
        {
            if (shapes.Count == 0)
            {
                Console.WriteLine("Нет фигур");
                return;
            }

            lock (lockObject)
            {
                int index = 0;
                var list = new List();

                foreach (var shape in shapes)
                {
                    Console.Write($"[{index}] ");
                    shape.Draw(list);
                    index++;
                }
            }
        }

        public void Draw(IDrawer drawer)
        {
            lock (lockObject)
            {
                foreach (var shape in shapes)
                {
                    shape.Draw(drawer);
                }
            }
        }
    }
}