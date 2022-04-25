using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Многоугольники
{
    [Serializable]
    public class Circle : Shape
    {
        public Circle(int x, int y, int index) : base(x,y, index)
        {
        }
        public Circle():base()
        {
        }
        public override void Move(int x, int y, Rectangle form)
        {
            mouseX = x;
            mouseY = y;
            if (mouseX > r && mouseX < form.Width - r)
            {
                this.x = mouseX;
            }
            if (mouseY - form.Y > r && mouseY - form.Y < form.Height - r)
            {
                this.y = mouseY;
            }
            IsInside(x,y);
        }
        override public void Draw(Graphics graphics)
        {
            graphics.FillEllipse(new SolidBrush(fillClr), new Rectangle(new Point(x - r, y - r), new Size(2*r, 2*r)));
            graphics.DrawEllipse(new Pen(lineClr, r / 10), new Rectangle(new Point(x - r, y - r), new Size(2 * r, 2 * r)));
        }
        override public bool IsInside(int x, int y)
        {
            if ((this.x - x) * (this.x - x) + (this.y - y) * (this.y - y) <= r * r)
            {
                mouseX = this.x;
                mouseY = this.y;
                return true;
            }
            return false;
        }
    }
}
