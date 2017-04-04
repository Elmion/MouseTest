using System.Drawing;
namespace TestTowerConcept
{
    internal interface IDraw
    {
        void Draw(Graphics g,int x,int y);
        int PositionX { get; set; }
        Rectangle Bounds { get; set; }
    }
}