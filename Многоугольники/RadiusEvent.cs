using System;

namespace Многоугольники
{
    public class RadiusEventArgs : EventArgs
    {
        public RadiusEventArgs()
        {
            r = 50;
        }

        public RadiusEventArgs(int r)
        {
            this.r = r;
        }
        private int r;

        public int R
        {
            get
            {
                return r;
            }
        }
    }
    public delegate void RadiusEventHandler(object sender, RadiusEventArgs e);
}