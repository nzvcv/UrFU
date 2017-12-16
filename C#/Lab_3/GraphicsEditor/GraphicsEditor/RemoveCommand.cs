using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleUI;

namespace GraphicsEditor
{
    public class RemoveCommand : ICommand
    {
        Application app;
        Picture picture;

        public RemoveCommand(Application app, Picture picture)
        {
            this.app = app;
            this.picture = picture;
        }

        public string Name => "remove";

        public string Help => "Удаление фигуры с окна";

        public string[] Synonyms => new string[] { "delete", "REMOVE" };

        public string Description => "Удаление фигуры с окна." +
            "Параметры команды - индексы элемента, которые нужно удалить с картинки";

        public void Execute(params string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(Description);
            }

            int number;
            var parameters = new List<int>();

            for (int i = 0; i < args.Length; i++)
            {
                if (int.TryParse(args[i], out number) && (number >= 0))
                {
                    parameters.Add(number);
                }
                else if (number < 0)
                { 
                    Console.WriteLine($"Аргументы не могут быть отрицательными, {args[i]}");
                }
                else
                {
                    Console.WriteLine($"Ошибка преобразования в число, {args[i]}");
                }
            }

            parameters.Sort();
            parameters.Reverse();
            IEnumerable<int> param = parameters.Distinct();

            try
            {
                foreach (var a in param)
                {
                    picture.RemoveAt(a);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Вы пытаетесь удалить несуществующую фигуру + {e.Message}");
            }
        }
    }
}
