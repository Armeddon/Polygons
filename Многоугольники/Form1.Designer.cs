namespace Многоугольники
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.shapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.andrewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.definitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comparisonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.andrewChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointDrawColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointFillColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shapeDrawColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shapeToolStripMenuItem, this.algorithmToolStripMenuItem, this.chartToolStripMenuItem, this.colorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // shapeToolStripMenuItem
            // 
            this.shapeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circleToolStripMenuItem,
            this.squareToolStripMenuItem,
            this.triangleToolStripMenuItem});
            this.shapeToolStripMenuItem.Name = "shapeToolStripMenuItem";
            this.shapeToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.shapeToolStripMenuItem.Text = "Shape";
            // 
            // chartToolStripMenuItem
            // 
            this.chartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.comparisonToolStripMenuItem,
                this.andrewChartToolStripMenuItem});
            this.chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            this.chartToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.chartToolStripMenuItem.Text = "Chart";
            //
            // algorithmToolStripMenuItem
            //
            this.algorithmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.definitionToolStripMenuItem,
                this.andrewToolStripMenuItem});
            this.algorithmToolStripMenuItem.Name = "algorithmToolStripMenuItem";
            this.algorithmToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.algorithmToolStripMenuItem.Text = "Algorithm";
            //
            // colorToolStripMenuItem
            //
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.pointDrawColorToolStripMenuItem,
                this.pointFillColorToolStripMenuItem,
                this.shapeDrawColorToolStripMenuItem});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.colorToolStripMenuItem.Text = "Color";
            //
            // pointDrawColorToolStripMenuItem
            //
            this.pointDrawColorToolStripMenuItem.Name = "pointDrawColorToolStripMenuItem";
            this.pointDrawColorToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.pointDrawColorToolStripMenuItem.Text = "Shape Draw Color";
            this.pointDrawColorToolStripMenuItem.Click +=
                new System.EventHandler(this.pointDrawColorToolStripMenuItem_Click);
            //
            // pointFillColorToolStripMenuItem
            //
            this.pointFillColorToolStripMenuItem.Name = "pointFillColorToolStripMenuItem";
            this.pointFillColorToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.pointFillColorToolStripMenuItem.Text = "Shape Fill Color";
            this.pointFillColorToolStripMenuItem.Click +=
                new System.EventHandler(this.pointFillColorToolStripMenuItem_Click);
            //
            // shapeDrawColorToolStripMenuItem
            //
            this.shapeDrawColorToolStripMenuItem.Name = "shapeDrawColorToolStripMenuItem";
            this.shapeDrawColorToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.shapeDrawColorToolStripMenuItem.Text = "Hull Draw Color";
            this.shapeDrawColorToolStripMenuItem.Click +=
                new System.EventHandler(this.shapeDrawColorToolStripMenuItem_Click);
            // 
            // circleToolStripMenuItem
            // 
            this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            this.circleToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.circleToolStripMenuItem.Text = "Circle";
            this.circleToolStripMenuItem.Click += new System.EventHandler(this.circleToolStripMenuItem_Click);
            // 
            // squareToolStripMenuItem
            // 
            this.squareToolStripMenuItem.Name = "squareToolStripMenuItem";
            this.squareToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.squareToolStripMenuItem.Text = "Square";
            this.squareToolStripMenuItem.Click += new System.EventHandler(this.squareToolStripMenuItem_Click);
            // 
            // triangleToolStripMenuItem
            // 
            this.triangleToolStripMenuItem.Name = "triangleToolStripMenuItem";
            this.triangleToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.triangleToolStripMenuItem.Text = "Triangle";
            this.triangleToolStripMenuItem.Click += new System.EventHandler(this.triangleToolStripMenuItem_Click);
            // 
            // andrewToolStripMenuItem
            // 
            this.andrewToolStripMenuItem.Name = "andrewToolStripMenuItem";
            this.andrewToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.andrewToolStripMenuItem.Text = "Andrew";
            this.andrewToolStripMenuItem.Click += new System.EventHandler(this.andrewToolStripMenuItem_Click);
            // 
            // definitionToolStripMenuItem
            // 
            this.definitionToolStripMenuItem.Name = "definitionToolStripMenuItem";
            this.definitionToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.definitionToolStripMenuItem.Text = "Definition";
            this.definitionToolStripMenuItem.Click += new System.EventHandler(this.definitionToolStripMenuItem_Click);
            // 
            // comparisonToolStripMenuItem
            // 
            this.comparisonToolStripMenuItem.Name = "comparisonToolStripMenuItem";
            this.comparisonToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.comparisonToolStripMenuItem.Text = "Comparison";
            this.comparisonToolStripMenuItem.Click += new System.EventHandler(this.comparisonToolStripMenuItem_Click);
            // 
            // andrewChartToolStripMenuItem
            // 
            this.andrewChartToolStripMenuItem.Name = "andrewChartToolStripMenuItem";
            this.andrewChartToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.andrewChartToolStripMenuItem.Text = "Andrew";
            this.andrewChartToolStripMenuItem.Click += new System.EventHandler(this.andrewChartToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Многоугольники";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem shapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem andrewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem definitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comparisonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem andrewChartToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointDrawColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointFillColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shapeDrawColorToolStripMenuItem;

    }
}

