using System;
using ConsoleUI;

namespace GraphicsEditor
{
    public class LineCommand : ICommand
    {
        Picture picture;

        public LineCommand(Picture picture)
        {
            this.picture = picture;
        }

        public string Name => "line";

        public string Help => "Рисует линию";

        public string[] Synonyms => new string[] { "LINE" }; 

        public string Description
            => "Рисование линии в окне. Параметры команды - координаты первой точки X и Y, координаты второй точки X и Y";

        public void Execute(params string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                args[i] = args[i].Replace(".", ",");
            }

            try
            {
                IShape shape = new Line();
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
