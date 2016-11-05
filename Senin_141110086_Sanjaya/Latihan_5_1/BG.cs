using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Reflection;

namespace Latihan_3_1
{
    public partial class BG : Form
    {
        Form1 form1 = (Form1)Form1.ActiveForm;
        public BG()
        {
            InitializeComponent();
            Color warna = new Color();
            PropertyInfo[] p = warna.GetType().GetProperties();

            comboBackColor.DrawMode = DrawMode.OwnerDrawFixed;

            foreach (PropertyInfo c in p)
            {
                if (c.PropertyType == typeof(System.Drawing.Color))
                {
                    comboBackColor.Items.Add(c.Name);
                }
            }

            this.comboBackColor.DrawItem += new DrawItemEventHandler(comboBackColor_DrawItem);
        }
        private void comboBackColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;
                Brush brush = new SolidBrush(e.BackColor);
                Brush tBrush = new SolidBrush(e.ForeColor);

                g.FillRectangle(brush, e.Bounds);
                string s = (string)this.comboBackColor.Items[e.Index].ToString();
                SolidBrush b = new SolidBrush(Color.FromName(s));
                e.Graphics.DrawRectangle(Pens.Black, 2, e.Bounds.Top + 1, 20, 11);
                e.Graphics.FillRectangle(b, 3, e.Bounds.Top + 2, 19, 10);
                e.Graphics.DrawString(s, this.Font, Brushes.Black, 25, e.Bounds.Top);
                brush.Dispose();
                tBrush.Dispose();
            }
            e.DrawFocusRectangle();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            form1.richTextBox1.BackColor = Color.White;
            this.Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            form1.richTextBox1.BackColor = Color.FromName(comboBackColor.Text);
            this.Dispose();
        }

        private void BG_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
            treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];
        }
    }
}
