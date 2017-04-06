using System.Drawing;
namespace CommonElement
{
    internal interface IDraw
    {
        void Draw(Graphics g,SceneItemInfo s);
    }
}