using System;
using ConsoleUI;

namespace GraphicsEditor
{
    public class CircleCommand : ICommand
    {
        Picture picture;

        public CircleCommand(Picture picture)
        {
            this.picture = picture;
        }

        public string Name => "circle";

        public string Help => "Рисует окружность";

        public string[] Synonyms => new string[] { "ring", "CIRCLE" };

        public string Description
            => "Рисование окружности в окне. Параметры команды - координаты точки X и Y, радиус окружности";

        public void Execute(params string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                args[i] = args[i].Replace(".", ",");
            }

            try
            {
                IShape shape = new Circle();
                shape.TryParse(args);
                picture.Add(shape);

            }
            catch (Exception x)
            {
                Console.WriteLine("Ошибка. " + x.Message);
            }
        }
    }
}