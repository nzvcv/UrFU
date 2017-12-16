using System;
using ConsoleUI;

namespace GraphicsEditor
{
    public class EllipseCommand : ICommand
    {

        Picture picture;

        public EllipseCommand(Picture picture)
        {
            this.picture = picture;
        }

        public string Name => "ellipse";

        public string Help => "Рисует эллипс";

        public string[] Synonyms => new string[] { "ELLIPSE" };

        public string Description
            => "Рисование эллипса в окне. Параметры команды - координаты точки X и Y, радиус окружности";

        public void Execute(params string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                args[i] = args[i].Replace(".", ",");
            }

            try
            {
                var shape = new Ellipse();
                Ellipse.Parse(args);
                picture.Add(shape);
            }
            catch (Exception x)
            {
                Console.WriteLine("Ошибка. " + x.Message);
            }
        }
    }
}
