using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_1_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = (hScrollBar1.Value).ToString();
            label4.Text = (hScrollBar2.Value).ToString();
            dateTimePicker1.MaxDate = new DateTime(DateTime.Today.Year - hScrollBar2.Value,DateTime.Today.Month, DateTime.Today.Day);
            dateTimePicker1.MinDate = new DateTime(DateTime.Today.Year - hScrollBar1.Value, DateTime.Today.Month, DateTime.Today.Day);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = (hScrollBar1.Value).ToString();
            if (hScrollBar2.Value >= hScrollBar1.Value) hScrollBar2.Value = hScrollBar1.Value - 1;
            hScrollBar2.Maximum = hScrollBar1.Value+8;

            dateTimePicker1.MinDate = new DateTime(DateTime.Today.Year - hScrollBar1.Value, DateTime.Today.Month, DateTime.Today.Day);
        }

        private void hScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            label4.Text = (hScrollBar2.Value).ToString();

            dateTimePicker1.MaxDate = new DateTime(DateTime.Today.Year - hScrollBar2.Value, DateTime.Today.Month, DateTime.Today.Day);
        }
    }
}
