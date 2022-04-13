using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Измерение;

namespace Многоугольники
{
    public partial class Form1 : Form
    {
        private ComparisonChartForm form2;
        private RadiusForm radForm;
        Rectangle ActualForm;
        List<Shape> shapes;
        static public Color HullColor;
        enum Figures
        {
            circle,
            square,
            triangle
        };
        Figures figure;
        Algorithms alg;
        private bool dinamics;
        enum Algorithms
        {
            definition,
            andrew
        };
        public Form1()
        {
            InitializeComponent();
        }
        public List<Shape> Shapes
        {
            get
            {
                return shapes;
            }
        }
        private Random rnd;
        private void timer1_Tick(object sender, EventArgs e)
        {
            bool isAnyoneMoving = false;
            if (dinamics)
            {
                foreach (Shape shape in shapes)
                {
                    shape.Move(shape.X + rnd.Next(-1,2), shape.Y + rnd.Next(-1,2), this.ActualForm);
                    if (!isAnyoneMoving && shape.ismoving) isAnyoneMoving = true;
                }
                if (shapes.Count > 3 && !isAnyoneMoving)
                {
                    if (alg == Algorithms.andrew)
                    {
                        DeleteAndrew();
                    }
                    else if (alg == Algorithms.definition)
                    {
                        DeleteDefinition();
                    }
                }
                Refresh();
            }
        }

        private void toolBar1_Click(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button == this.startToolBarButton)
            {
                dinamics = true;
            }
            else if (e.Button == this.stopToolBarButton)
            {
                dinamics = false;
            }
        }
        private void DeleteAndrew()
        {
            shapes = Shape.Andrew(shapes);
        }
        private void DeleteDefinition()
        {
            List<Shape> shapesToHell = new List<Shape>();
            foreach (Shape shape in shapes)
            {
                if (!shape.isInHull)
                {
                    shapesToHell.Add(shape);
                }
            }
            foreach (Shape shape in shapesToHell)
            {
                shapes.Remove(shape);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            shapes = new List<Shape>();
            figure = Figures.triangle;
            alg = Algorithms.definition;
            HullColor = Color.BlueViolet;
            ActualForm = new Rectangle(0,menuStrip1.Size.Height + toolBar1.Size.Height,
                ClientSize.Width,
                ClientSize.Height-menuStrip1.Size.Height - toolBar1.Size.Height);
            triangleToolStripMenuItem.Checked = true;
            definitionToolStripMenuItem.Checked = true;
            Shape.LineClr = Color.Black;
            Shape.FillClr = Color.OrangeRed;
            Shape.R = 40;
            rnd = new Random();
            dinamics = false;
            timer1.Start();
            Refresh();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (shapes.Count > 2)
            {
                if (alg == Algorithms.andrew)
                {
                    Shape[] shapes_arr = shapes.ToArray();
                    Point[] points = new Point[shapes_arr.Length];
                    for (int i = 0; i < shapes_arr.Length; ++i)
                    {
                        points[i] = new Point(shapes_arr[i].X, shapes_arr[i].Y);
                    }
                    e.Graphics.DrawPolygon(new Pen(HullColor,Shape.R/10), points);
                }
                else if (alg == Algorithms.definition)
                {
                    shapes = Shape.Definition(shapes, e.Graphics);
                }
            }
            foreach (Shape shape in shapes)
            {
                shape.Draw(e.Graphics);
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            bool missed = true;
            int toHell = 0;
            bool isAnyoneToHell = false;
            int maxIndex = -1;
            if (e.Button == MouseButtons.Left)
            {
                foreach (Shape shape in shapes)
                {
                    if (shape.IsInside(e.X, e.Y))
                    {
                        missed = false;
                        shape.ismoving = true;
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                foreach (Shape shape in shapes)
                {
                    if (shape.IsInside(e.X, e.Y))
                    {
                        if (shape.createOrderIndex > maxIndex)
                        {
                            maxIndex = shape.createOrderIndex;
                        }
                    }
                }
                foreach(Shape shape in shapes)
                {
                    if (shape.createOrderIndex == maxIndex)
                    {
                        toHell = shapes.IndexOf(shape);
                        isAnyoneToHell = true;
                        missed = false;
                    }
                }
                if (isAnyoneToHell)
                {
                    shapes.RemoveAt(toHell);
                    Refresh();
                }
            }

            if (missed && Shape.IsMouseInHull(e.X, e.Y, shapes))
            {
                foreach (Shape shape in shapes)
                {
                    shape.ismoving = true;
                }
            }
            else if (missed && e.Button == MouseButtons.Left)
            {
                switch (figure)
                {
                    case Figures.circle:
                    {
                        Shapes.Add(new Circle(e.X, e.Y, shapes.Count));
                        break;
                    }
                    case Figures.square:
                    {
                        Shapes.Add(new Square(e.X, e.Y, shapes.Count));
                        break;
                    }
                    case Figures.triangle:
                    {
                        Shapes.Add(new Triangle(e.X, e.Y, shapes.Count));
                        break;
                    }
                }
                Refresh();
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Shape shape in shapes)
            {
                if (shape.ismoving)
                {
                    shape.Move(e.X, e.Y, ActualForm);
                    Refresh();
                }
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Shape shape in shapes)
            {
                shape.ismoving = false;
            }

            if (shapes.Count > 3)
            {
                if (alg == Algorithms.andrew)
                {
                    DeleteAndrew();
                }
                else if (alg == Algorithms.definition)
                {
                    DeleteDefinition();
                }
            }
            Refresh();
        }
        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figure = Figures.circle;
            circleToolStripMenuItem.Checked = true;
            squareToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = false;
        }
        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figure = Figures.square;
            circleToolStripMenuItem.Checked = false;
            squareToolStripMenuItem.Checked = true;
            triangleToolStripMenuItem.Checked = false;
        }
        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figure = Figures.triangle;
            circleToolStripMenuItem.Checked = false;
            squareToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = true;
        }
        private void andrewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alg = Algorithms.andrew;
            definitionToolStripMenuItem.Checked = false;
            andrewToolStripMenuItem.Checked = true;
        }
        private void definitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alg = Algorithms.definition;
            andrewToolStripMenuItem.Checked = false;
            definitionToolStripMenuItem.Checked = true;
        }
        private void pointDrawColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Shape.LineClr = colorDialog1.Color;
                Refresh();
            }
        }
        private void pointFillColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Shape.FillClr = colorDialog1.Color;
                Refresh();
            }
        }
        private void shapeDrawColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                HullColor = colorDialog1.Color;
                Refresh();
            }
        }
        private void radiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radForm == null || !radForm.IsDisposed)
                radForm = new RadiusForm(this);
            radForm.Show();
        }
        public void radius_Changed(object sender, RadiusEventArgs e)
        {
            Shape.R = e.R;
            Refresh();
        }
        private void comparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2 = new ComparisonChartForm(Charts.Comparison);
            form2.ShowDialog();
        }
        private void andrewChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2 = new ComparisonChartForm(Charts.Andrew);
            form2.ShowDialog();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            ActualForm = new Rectangle(0,menuStrip1.Size.Height+toolBar1.Size.Height,
                ClientSize.Width,
                ClientSize.Height-menuStrip1.Size.Height-toolBar1.Size.Height);
            if (Shapes != null)
            {
                Shape[] copy = new Shape[shapes.Count()];
                shapes.CopyTo(copy);
                foreach (Shape shape in copy)
                {
                    if (Shape.R * 2 > this.ActualForm.Width ||
                        Shape.R * 2 > this.ActualForm.Height)
                    {
                        shapes.Remove(shape);
                    }
                    else switch (figure)
                    {
                        case Figures.circle:
                            if (shape.X >= ActualForm.Width - Shape.R)
                            {
                                shape.Move(ActualForm.Width + shape.MouseX - Shape.R, shape.Y + shape.MouseY, ActualForm);
                            }
                            if (shape.Y - ActualForm.Y >= ActualForm.Height - Shape.R)
                            {
                                shape.Move(shape.X+shape.MouseX, ActualForm.Height +shape.MouseY-Shape.R, ActualForm);
                            }
                            break;
                        case Figures.square:
                            if (shape.X >= ActualForm.Width - Shape.R * Math.Sqrt(2) / 2)
                            {
                                shape.Move((int)Math.Round(ActualForm.Width + shape.MouseX - Shape.R * Math.Sqrt(2) / 2), shape.Y+shape.MouseY, ActualForm);
                            }
                            if (shape.Y - ActualForm.Y >= ActualForm.Height - Shape.R * Math.Sqrt(2) / 2)
                            {
                                shape.Move(shape.X+shape.MouseX, (int)Math.Round(ActualForm.Height +shape.MouseY - Shape.R * Math.Sqrt(2) / 2), ActualForm);
                            }
                            break;
                        case Figures.triangle:
                            if (shape.X >= ActualForm.Width - 1.5 * Shape.R / Math.Sqrt(3))
                            {
                                shape.Move((int)Math.Round(ActualForm.Width+shape.MouseX - 1.5 * Shape.R / Math.Sqrt(3)), shape.Y+shape.MouseY, ActualForm);
                            }
                            if (shape.Y - ActualForm.Y >= ActualForm.Height - Shape.R / 2)
                            {
                                shape.Move(shape.X+shape.MouseX, (int)Math.Round((double)(ActualForm.Height + shape.MouseY - Shape.R/2)), ActualForm);
                            }
                            break;
                    }
                }
            }
            Refresh();
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int r = Shape.R;
            Color lc = Shape.LineClr;
            Color fc = Shape.FillClr;
            SaveLoad.LoadState(ref shapes, ref HullColor, ref r, ref lc, ref fc, "/tmp/file");
            Shape.R = r;
            Shape.LineClr = lc;
            Shape.FillClr = fc;
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLoad.SaveState(shapes, HullColor, Shape.R, Shape.LineClr, Shape.FillClr, "/tmp/file");
        }

        private void saveAsFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLoad.SaveState(shapes, HullColor, Shape.R, Shape.LineClr, Shape.FillClr, "/tmp/file");
        }
    }
}