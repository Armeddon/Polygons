using System;
using System.ComponentModel;
using System.Security.Principal;
using System.Windows.Forms;

namespace Многоугольники
{
    partial class RadiusForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBar = new TrackBar();
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 150);
            this.Text = "Radius change";
            //
            // trackBar
            //
            trackBar.Name = "trackBar";
            trackBar.Minimum = 10;
            trackBar.Maximum = 70;
            trackBar.Text = "Radius";
            trackBar.Width = 400;
            trackBar.Height = 50;
            trackBar.Dock = DockStyle.Top;
            trackBar.Anchor = AnchorStyles.Top;
            trackBar.ValueChanged += new EventHandler(radiusChangedInner);
            //
            // radiusForm
            //
            this.Controls.Add(trackBar);
            this.Width = 400;
            this.Height = 150;
        }
        private System.Windows.Forms.TrackBar trackBar;

        #endregion
    }
}