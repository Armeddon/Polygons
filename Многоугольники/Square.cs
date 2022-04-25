using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Многоугольники
{
    [Serializable]
    public class Square : Shape
    {
        public Square(int x, int y, int index) : base(x,y, index)
        {
        }
        public Square() : base()
        {
        }
        public override void Move(int x, int y, Rectangle form)
        {
            mouseX = x;
            mouseY = y;
            if (mouseX >= r * Math.Sqrt(2) / 2 && mouseX <= form.Width - r * Math.Sqrt(2) / 2)
            {
                this.x = mouseX;
            }
            if (mouseY - form.Y >= r * Math.Sqrt(2) / 2 && mouseY - form.Y <= form.Height - r * Math.Sqrt(2) / 2)
            {
                this.y = mouseY;
            }
            IsInside(x, y);
        }
        override public void Draw(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(fillClr), 
                new Rectangle(new Point((int)(x-(Math.Sqrt(2)/2*r)), (int)(y-(Math.Sqrt(2)/2*r))),
                new Size((int)(r*Math.Sqrt(2)), (int)(r*Math.Sqrt(2)))));
            graphics.DrawRectangle(new Pen(lineClr, r/10),
                new Rectangle(new Point((int)(x - (Math.Sqrt(2) / 2 * r)), (int)(y - (Math.Sqrt(2) / 2 * r))),
                new Size((int)(r * Math.Sqrt(2)), (int)(r * Math.Sqrt(2)))));
        }
        override public bool IsInside(int x, int y)
        {
            if (Math.Abs(x - this.x) < (int)(Math.Sqrt(2) / 2 * r) && Math.Abs(y - this.y) < (int)(Math.Sqrt(2) / 2 * r))
            {
                mouseX = this.x;
                mouseY = this.y;
                return true;
            }
            return false;
        }
    }
}
