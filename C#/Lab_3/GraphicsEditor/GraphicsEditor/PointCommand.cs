using System;
using ConsoleUI;

namespace GraphicsEditor
{
    public class PointCommand : ICommand
    {
        Picture picture;

        public PointCommand(Picture picture)
        {
            this.picture = picture;
        }
        public string Name => "point";

        public string Help => "Рисует точку на экране";

        public string[] Synonyms => new string[] { "dot", ".", "POINT" };
        
        public string Description
                => "Рисование точки в окне. Параметр команды - координаты точки X и Y";

        public void Execute(params string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                args[i] = args[i].Replace(".", ",");
            }

            try
            {
                IShape shape = new Point();
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
