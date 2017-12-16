using ConsoleUI;

namespace GraphicsEditor
{
    public class ListCommand : ICommand
    {
        Picture picture;

        public ListCommand(Picture picture)
        {
            this.picture = picture;
        }

        public string Name => "list"; 

        public string Help => " Список фигур на картинке";

        public string[] Synonyms
            => new string[] { "LIST", "show", "print" }; 

        public string Description => "Выводит список фигур на картинке";

        public void Execute(params string[] parameters)
        {
            picture.Print();
        }
    }
}
