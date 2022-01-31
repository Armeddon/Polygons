using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Измерение
{
    public enum Charts
    {
        Comparison,
        Andrew
    };

    public partial class ComparisonChartForm : Form
    {
        private List<Chart> charts;
        private Charts chartType;
        private List<ePoint> points;
        private Random rnd;
        private Stopwatch watch;
        public ComparisonChartForm()
        {
            InitializeComponent();
            chartType = Charts.Comparison;
        }
        public ComparisonChartForm(Charts chartType)
        {
            InitializeComponent();
            this.chartType = chartType;
        }
        private void ComparisonChartForm_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            charts = new List<Chart>();
            points = new List<ePoint>();
            rnd = new Random();
            watch = new Stopwatch();
            CreateSplineChart();
            Refresh();
        }
        private void ComparisonChartForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (var chart in charts)
            {
                chart.Draw(e.Graphics);
            }
        }
        private void CreateSplineChart()
        {
            switch (chartType)
            {
                case Charts.Comparison:
                {
                    charts.Add(new Chart(new Point(0,0), 700, 450));
                    charts.Add(new Chart(new Point(0,0), 700 ,450));
                    charts[1].DataPen = new Pen(Color.Aqua) {Width = 4};
                    this.Text = "Comparison chart";
                    Compare();
                    Refresh();
                    break;
                }
                case Charts.Andrew:
                {
                    charts.Add(new Chart(new Point(0,0), 700, 450));
                    this.Text = "Andrew chart";
                    Andrew();
                    Refresh();
                    break;
                }
                default:
                {
                    break;
                }
            }
        }
        private void Compare()
        {
            for (int i = 0; i < 20000; i += 500)
            {
                for (int j = 0; j < i; j++)
                {
                    points.Add(new ePoint(rnd.Next(0, 200), rnd.Next(0,200), false));
                }
                watch = Stopwatch.StartNew();
                ePoint.Definition(points);
                watch.Stop();
                charts[0].Add(watch.ElapsedMilliseconds);
                Console.WriteLine(i + " " + watch.ElapsedMilliseconds);
                points.Clear();
                for (int j = 0; j < i; j++)
                {
                    points.Add(new ePoint(rnd.Next(0, 200), rnd.Next(0,200), false));
                }
                watch = Stopwatch.StartNew();
                ePoint.Andrew(points);
                watch.Stop();
                charts[1].Add(watch.ElapsedMilliseconds);
                Console.WriteLine(i + " " + watch.ElapsedMilliseconds);
                points.Clear();
            }
        }
        private void Andrew()
        {
            for (int i = 0; i < 200000; i += 500)
            {
                for (int j = 0; j < i; j++)
                {
                    points.Add(new ePoint(rnd.Next(0, 200), rnd.Next(0,200), false));
                }
                watch = Stopwatch.StartNew();
                ePoint.Andrew(points);
                watch.Stop();
                charts[0].Add(watch.ElapsedMilliseconds);
                Console.WriteLine(i + " " + watch.ElapsedMilliseconds);
                points.Clear();
            }
        }
        
        static void Main()
        {
            
        }
    }
}