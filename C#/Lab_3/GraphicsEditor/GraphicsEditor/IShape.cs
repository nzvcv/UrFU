using DrawablesUI;

namespace GraphicsEditor
{
    public interface IShape : IDrawable
    {
        void TryParse(string[] args);
    }
}
