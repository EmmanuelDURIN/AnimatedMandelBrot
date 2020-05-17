using System.Windows.Media;

namespace FractalMaker
{
    public interface IDrawable
    {
        void DrawPixel(int column, int row, Color color);
    }
}