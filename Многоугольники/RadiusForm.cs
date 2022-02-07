using System;
using System.Windows.Forms;

namespace Многоугольники
{
    public partial class RadiusForm : Form
    {
        private event RadiusEventHandler radiusEvent;
        public RadiusForm()
        {
            InitializeComponent();
        }
        public RadiusForm(Form1 form)
        {
            InitializeComponent();
            radiusEvent += form.radius_Changed;
            this.scrollbar.Value = Shape.R;
        }
        private void radiusChangedInner(object sender, EventArgs e)
        {
            this.Text = Convert.ToString(scrollbar.Value);
            radiusEvent.Invoke(this, new RadiusEventArgs(scrollbar.Value));
        }
    }
}