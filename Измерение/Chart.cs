using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Измерение
{
    public class Chart : PictureBox
    {
        public enum ChartType
        {
            Lines,
            Bars
        };
        public Chart(Point startPoint, int width, int height)
        {
            this.values = new List<long>();
            this.StartPoint = startPoint;
            this.Width = width;
            this.Height = height;
            this.FrameWidth = 50;
            this.Type = ChartType.Lines;
            this.AxisPen = new Pen( Color.Black ) { Width = 10 };
            this.DataPen = new Pen( Color.Red ) { Width = 4 };
            this.DataFont = new Font( FontFamily.GenericMonospace, 12 );
            this.LegendFont = new Font( FontFamily.GenericSansSerif, 12 );
            this.LegendPen = new Pen( Color.Navy );
        
            this.Build();
        }
        public void Draw(Graphics graphics)
        {
            this.grf = graphics;
            this.grf.DrawRectangle(
                new Pen( this.BackColor ),
                new Rectangle( StartPoint.X, StartPoint.Y, this.Width, this.Height ) );
            this.DrawAxis();
            this.DrawData();
            this.DrawLegends();
        }
        private void DrawLegends()
        {
            StringFormat verticalDrawFmt = new StringFormat {
                FormatFlags = StringFormatFlags.DirectionVertical
            };
            int legendXWidth = (int) this.grf.MeasureString(
                this.LegendX,
                this.LegendFont ).Width;
            int legendYHeight = (int) this.grf.MeasureString(
                this.LegendY,
                this.LegendFont,
                new Size( this.Width,
                    this.Height ),
                verticalDrawFmt ).Height;

            this.grf.DrawString(
                this.LegendX,
                this.LegendFont,
                this.LegendPen.Brush,
                new Point( 
                    ( this.Width - legendXWidth ) / 2 + StartPoint.X,
                    this.FramedEndPosition.Y + 5 +StartPoint.Y) );

            this.grf.DrawString(
                this.LegendY,
                this.LegendFont,
                this.LegendPen.Brush,
                new Point( 
                    this.FramedOrgPosition.X - ( this.FrameWidth / 2 ) + StartPoint.X,
                    ( this.Height - legendYHeight ) / 2  + StartPoint.Y),
                verticalDrawFmt );
        } 
        void DrawData()
        {
            int numValues = this.values.Count;
            var p = new Point(this.DataOrgPosition.X + StartPoint.X, this.DataOrgPosition.Y + StartPoint.Y);
            int xGap = this.GraphWidth / ( numValues + 1 );
            int baseLine = this.DataOrgPosition.Y + StartPoint.Y;

            
            //this.NormalizeData();
            for(int i = 0; i < numValues; ++i) {
                string tag = this.values[i].ToString();
                int tagWidth = (int) this.grf.MeasureString(
                    tag,
                    this.DataFont ).Width;
                var nextPoint = new Point(
                    p.X + xGap +StartPoint.X, baseLine -  (int)values[i] + StartPoint.Y
                );
                
                if ( this.Type == ChartType.Bars ) {
                    p = new Point( nextPoint.X +StartPoint.X, baseLine +StartPoint.Y);
                }
                
                this.grf.DrawLine( this.DataPen, p, nextPoint );
                /*
                if (i % ((double)numValues/10) == 0)
                    this.grf.DrawString( tag,
                        this.DataFont,
                        this.DataPen.Brush,
                        new Point(  StartPoint.X + 10,
                            nextPoint.Y +StartPoint.Y) );
                if (i % ((double)numValues/10) == 0)
                    this.grf.DrawString( Convert.ToString(i),
                        this.DataFont, 
                        this. DataPen.Brush,
                        new Point(nextPoint.X - tagWidth + StartPoint.X, Bottom - 30 + StartPoint.Y));
                */
                p = nextPoint;
            }
        }
        void DrawAxis()
        {
            // Y axis
            this.grf.DrawLine( this.AxisPen,
                new Point(this.FramedOrgPosition.X + StartPoint.X, this.FramedOrgPosition.Y + StartPoint.Y),
                new Point(
                    this.FramedOrgPosition.X + StartPoint.X,
                    this.FramedEndPosition.Y + StartPoint.Y) );
                                        
            // X axis
            this.grf.DrawLine( this.AxisPen,
                new Point(
                    this.FramedOrgPosition.X + StartPoint.X,
                    this.FramedEndPosition.Y + StartPoint.Y),
                new Point(this.FramedEndPosition.X + StartPoint.X, this.FramedEndPosition.Y + StartPoint.Y));
        }
        void Build()
        {
            Bitmap bmp = new Bitmap( this.Width, this.Height );
            this.Image = bmp;
            this.grf = Graphics.FromImage( bmp );
        }
        void NormalizeData()
        {
            long maxHeight = this.DataOrgPosition.Y - this.FrameWidth + StartPoint.Y;
            long maxValue = this.values.Max();

            this.normalizedData = this.values.ToArray();

            for(int i = 0; i < this.normalizedData.Length; ++i) {
                this.normalizedData[ i ] =
                    ( this.values[ i ] * maxHeight ) / maxValue;
            }
            
            return;
        }
        public void Add(long value)
        {
            this.values.Add(value);
        }
        public IEnumerable<long> Values {
            get {
                return this.values.ToArray();
            }
            set {
                this.values.Clear();
                this.values.AddRange( value );
            }
        }
        public Point DataOrgPosition {
            get {
                int margin = (int) ( this.AxisPen.Width * 2 );
                
                return new Point(
                    this.FramedOrgPosition.X + margin,
                    this.FramedEndPosition.Y - margin );
            }
        }
        public int FrameWidth {
            get; set;
        }
        public Point FramedOrgPosition {
            get {
                return new Point( this.FrameWidth, this.FrameWidth );
            }
        }
        public Point FramedEndPosition {
            get {
                return new Point( this.Width - this.FrameWidth,
                    this.Height - this.FrameWidth );
            }
        }
        public int GraphWidth {
            get {
                return this.Width - ( this.FrameWidth * 2 );
            }
        }
        public Pen AxisPen {
            get; set;
        }
        public Pen DataPen {
            get; set;
        }
        public Font DataFont {
            get; set;
        }
        public string LegendX {
            get; set;
        }
        public string LegendY {
            get; set;
        }
        public Font LegendFont {
            get; set;
        }
        public Pen LegendPen {
            get; set;
        }
        public ChartType Type {
            get; set;
        }

        public Point StartPoint { get; set; }
        Graphics grf;
        List<long> values;
        long[] normalizedData;
    }
}