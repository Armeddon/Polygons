using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Многоугольники
{
    abstract public class Shape
    {
        static protected int r;
        static protected Color lineClr, fillClr;
        protected int x, y;
        protected int mouseX, mouseY; //Положение мыши относительно центра фигуры в момент нажатия
        protected int hullX, hullY;
        public bool ismoving;
        public bool isInHull;
        public int createOrderIndex;
        protected Shape()
        {
            x = 100;
            y = 100;
            ismoving = false;
            isInHull = true;
            r = 40;
        }
        protected Shape(int x, int y, int index)
        {
            this.x = x;
            this.y = y;
            ismoving = false;
            isInHull = true;
            r = 40;
            createOrderIndex = index;
        }

        static public Color LineClr
        {
            get
            {
                return lineClr;
            }
            set
            {
                lineClr = value;
            }
        }

        static public Color FillClr
        {
            get
            {
                return fillClr;
            }
            set
            {
                fillClr = value;
            }
        }
        static public int R
        {
            get
            {
                return r;
            }
            set
            {
                r = (0 < value && value <= 200) ? value : r;
            }
        }
        public int X
        {
            get
            {
                return x;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
        }
        public int MouseX
        {
            get
            {
                return mouseX;
            }
        }
        public int MouseY
        {
            get
            {
                return mouseY;
            }
        }
        abstract public void Move(int x, int y, Rectangle form);
        abstract public void Draw(Graphics graphics);
        abstract public bool IsInside(int x, int y);

        static public List<Shape> Definition(List<Shape> points, Graphics graphics)
        {
            Shape[] points_arr = points.ToArray();
            double k, b;
            bool wasBroken;
            short sign;
            foreach (Shape point in points_arr)
            {
                point.isInHull = false;
            }
            for (int i = 0; i < points_arr.Length; ++i)
            {
                for (int j = i + 1; j < points_arr.Length; ++j)
                {
                    sign = 0;
                    wasBroken = false;
                    if (points_arr[i].X == points_arr[j].X)
                    {
                        for (int m = 0; m < points_arr.Length; ++m)
                        {
                            if (m != i && m != j)
                            {
                                if (sign == 0)
                                {
                                    if (points_arr[m].X > points_arr[i].X)
                                    {
                                        sign = 1;
                                    }
                                    else if (points_arr[m].X < points_arr[i].X)
                                    {
                                        sign = -1;
                                    }
                                }
                                else if ((points_arr[m].X-points_arr[i].X)*sign < 0)
                                {
                                    wasBroken = true;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        k = ((double) (points_arr[j].Y - points_arr[i].Y)) / (points_arr[j].X - points_arr[i].X);
                        b = points_arr[i].Y - k * points_arr[i].X;
                        for (int m = 0; m < points_arr.Length; ++m)
                        {
                            if (m != i && m != j)
                            {
                                if (sign == 0)
                                {
                                    if (points_arr[m].Y > points_arr[m].X * k + b)
                                    {
                                        sign = 1;
                                    }
                                    else if (points_arr[m].Y < points_arr[m].X * k + b)
                                    {
                                        sign = -1;
                                    }
                                }
                                else if ((points_arr[m].Y - points_arr[m].X * k - b) * sign < 0)
                                {
                                    wasBroken = true;
                                    break;
                                }
                            }
                        }
                    }
                    
                    if (!wasBroken)
                    {
                        points_arr[i].isInHull = true;
                        points_arr[j].isInHull = true;
                        graphics.DrawLine(new Pen(Form1.HullColor, R/10),points_arr[i].X, points_arr[i].Y, points_arr[j].X, points_arr[j].Y);
                    }
                }
            }
            return new List<Shape>(points_arr);
        }
        static public List<Shape> Andrew(List<Shape> points)
        {
            int n = points.Count(), k = 0;
            List<Shape> H = new List<Shape>(new Shape[2*n]);

            points.Sort((a, b) =>
                 a.X == b.X ? a.Y.CompareTo(b.Y) : a.X.CompareTo(b.X));
            for (int i = 0; i < n; ++i)
            {
                while (k >= 2 && ((H[k - 1].X - H[k - 2].X) * (points[i].Y - H[k - 2].Y) -
                    (H[k - 1].Y - H[k - 2].Y) * (points[i].X - H[k - 2].X)) <= 0)
                    k--;
                H[k++] = points[i];
            }
            for (int i = n - 2, t = k + 1; i >= 0; i--)
            {
                while (k >= t && ((H[k - 1].X - H[k - 2].X) * (points[i].Y - H[k - 2].Y) -
                    (H[k - 1].Y - H[k - 2].Y) * (points[i].X - H[k - 2].X)) <= 0)
                    k--;
                H[k++] = points[i];
            }
            return H.Take(k - 1).ToList();
        }
    }
}
