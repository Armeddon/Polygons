using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Многоугольники
{
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
            if (x - mouseX >= r * Math.Sqrt(2) / 2 && x - mouseX <= form.Width - r * Math.Sqrt(2) / 2)
            {
                this.x = x - mouseX;
            }
            if (y - form.Y - mouseY >= r * Math.Sqrt(2) / 2 && y - form.Y -mouseY <= form.Height - r * Math.Sqrt(2) / 2)
            {
                this.y = y - mouseY;
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
                mouseX = x - this.x;
                mouseY = y - this.y;
                return true;
            }
            else return false;
        }
    }
}
