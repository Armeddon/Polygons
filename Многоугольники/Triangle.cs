using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Многоугольники
{
    [Serializable]
    public class Triangle : Shape
    {
        public Triangle(int x, int y, int index) : base(x,y, index)
        {
        }
        public Triangle() : base()
        {
        }
        public override void Move(int x, int y, Rectangle form)
        {
            if (x - mouseX >= 1.5*r/Math.Sqrt(3) && x - mouseX <= form.Width - 1.5*r/Math.Sqrt(3))
            {
                this.x = x- mouseX;
            }
            if (y - form.Y - mouseY >= r && y - form.Y - mouseY <= form.Height - r/2)
            {
                this.y = y - mouseY;
            }
            IsInside(x, y);
        }
        override public void Draw(Graphics graphics)
        {
            graphics.FillPolygon(new SolidBrush(fillClr), new Point[]
            {
                new Point(x-(int)(r/2*Math.Sqrt(3)), y + r/2),
                new Point(x + (int)(r / 2 * Math.Sqrt(3)), y + r / 2),
                new Point(x , y - r)
            });
            graphics.DrawPolygon(new Pen(lineClr, r/10), new Point[]
            {
                new Point(x-(int)(r/2*Math.Sqrt(3)), y + r/2),
                new Point(x + (int)(r / 2 * Math.Sqrt(3)), y + r / 2),
                new Point(x , y - r)
            });
        }
        override public bool IsInside(int x, int y)
        {
            if (y > this.y + Math.Abs(this.x - x) * Math.Sqrt(3) - r && y < this.y + r / 2)
            {
                mouseX = x - this.x;
                mouseY = y - this.y;
                return true;
            }
            else return false;
        }
    }
}
