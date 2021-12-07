using System.Collections.Generic;
using System.Linq;

namespace Измерение
{
    public class ePoint
    {
        private int x, y;
        private bool isInHull;

        public ePoint(int x, int y, bool isInHull)
        {
            this.x = x;
            this.y = y;
            this.isInHull = isInHull;
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

        static public void Definition(List<ePoint> points)
        {
            ePoint[] points_arr = points.ToArray();
            double k, b;
            bool wasBroken;
            short sign;
            foreach (ePoint point in points_arr)
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
                    }
                }
            }
        }

        static public void Andrew(List<ePoint> points)
        {
            int n = points.Count(), k = 0;
            List<ePoint> H = new List<ePoint>(new ePoint[2*n]);

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
            H.Take(k - 1).ToList();
        }
    }
}