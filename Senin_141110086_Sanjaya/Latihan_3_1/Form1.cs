using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_3_1
{
    public partial class Form1 : Form
    {
        private List<coloredComboObject> lstColor;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstColor = coloredComboItems.GetColors();
            comboBox1.DataSource = lstColor ;
            comboBox1.ValueMember = "Color";
            comboBox1.DisplayMember = "Name";
        }
        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                Color clr = lstColor[e.Index].Color;
                using (Brush brush = new SolidBrush(clr))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds.X, e.Bounds.Y, 14, 14);
                }

                using (Brush brush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(lstColor[e.Index].Name.ToString(), e.Font, brush, e.Bounds.Left + 16, e.Bounds.Top);
                }
                e.DrawFocusRectangle();

            }
        }
    }
}
