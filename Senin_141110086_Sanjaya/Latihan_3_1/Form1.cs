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
namespace Latihan_3_1
{
    public partial class Form1 : Form
    {
        private List<coloredComboObject> lstColor;
        public Form1()
        {
            InitializeComponent();
            ComboBox box = (ComboBox)toolStripComboBox1.Control;
            box.DrawMode = DrawMode.OwnerDrawVariable;
            box.DrawItem += new DrawItemEventHandler(toolStripComboBox1_DrawItem);

            ComboBox box2 = (ComboBox)toolStripComboBox2.Control;
            box2.DrawMode = DrawMode.OwnerDrawVariable;
            box2.DrawItem += new DrawItemEventHandler(toolStripComboBox2_DrawItem);
        }
        public void fillFontCombo()
        {
            FontFamily[] families = FontFamily.Families;
            //Loop Through System Fonts
            foreach (FontFamily family in families)
            {
                //Set Current Font's Style To bold
                FontStyle style = FontStyle.Bold;
                //These Are Only Available In Italic, Not In "Regular",
                //So Test For Them, Else, Exception!!
                if (family.Name == "Monotype Corsiva" || family.Name == "Brush Script MT"
                || family.Name == "Harlow Solid Italic" || family.Name == "Palace Script MT" ||
                family.Name == "Vivaldi")
                {
                    //Set Style To Italic, To Overt "Regular" & Exception
                    style = style | FontStyle.Italic;
                }
                Font FCFont = new Font(family.Name, 10, style, GraphicsUnit.Point);
                //Display The Font Combo Items
                toolStripComboBox2.Items.Add(FCFont.Name);
            }
            toolStripComboBox2.SelectedIndex = 1;
        }



        //Add drawitem eventhandler for the combobox to paint the combobox

        private void toolStripComboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            //If the index is invalid, do nothing and exit.
            if (e.Index == -1 || e.Index >= toolStripComboBox2.Items.Count)
                return;
            //Draw the background of the item.
            e.DrawBackground();
            // Draw the focus rectangle
            if ((e.State & DrawItemState.Focus) != 0)
                e.DrawFocusRectangle();
            Brush b = null;
            try
            {
                // Create Background Brush.
                b = new SolidBrush(e.ForeColor);
                // Draw the item.
                FontStyle style = FontStyle.Bold;
                string strfont = toolStripComboBox2.Items[e.Index].ToString();
                if (strfont == "Monotype Corsiva" || strfont == "Brush Script MT"
                || strfont == "Harlow Solid Italic" || strfont == "Palace Script MT"
                || strfont == "Vivaldi")
                {
                    //Set Style To Italic, To Overt "Regular" & Exception
                    style = style | FontStyle.Italic | FontStyle.Regular;
                }

                Font nfont = new Font(strfont, 10, style);
                e.Graphics.DrawString(
                strfont,
                nfont,
                b,
                e.Bounds
                );

            } // End try
            finally
            {
                // Dispose the brush
                if (b != null)
                    b.Dispose();
                b = null;
            } // End finally
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            lstColor = coloredComboItems.GetColors();
            toolStripComboBox1.ComboBox.DataSource = lstColor;
            toolStripComboBox1.ComboBox.ValueMember = "Color";
            toolStripComboBox1.ComboBox.DisplayMember = "Name";
            toolStripComboBox3.ComboBox.Text = richTextBox1.SelectionFont.Size.ToString();
            toolStripComboBox2.ComboBox.Text = richTextBox1.SelectionFont.FontFamily.Name;
            toolStripComboBox1.ComboBox.Text = richTextBox1.SelectionColor.Name;
            fillFontCombo();
            for (int i = 1; i <= 100; i++)
            {
                toolStripComboBox3.ComboBox.Items.Add(i.ToString());
            }
        }
        private void toolStripComboBox1_DrawItem(object sender, DrawItemEventArgs e)
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
        
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.FromName(toolStripComboBox1.ComboBox.Text);

        }
        private void font(object sender, EventArgs e)
        {
            FontFamily foFa = new FontFamily("Arial"); //BUG!!! BUG!!! BUG!!! BUG!!! BUG!!! BUG!!! 
            FontStyle test = FontStyle.Regular;
            if (toolStripButton1.Checked) test = test | FontStyle.Bold;
            if (toolStripButton2.Checked) test = test | FontStyle.Italic;
            if (toolStripButton3.Checked) test = test | FontStyle.Underline;

            richTextBox1.SelectionFont = new Font(foFa, Convert.ToSingle(toolStripComboBox3.ComboBox.Text),test);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(richTextBox1.Rtf);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FontFamily foFa = new FontFamily("Arial"); //BUG!!! BUG!!! BUG!!! BUG!!! BUG!!! BUG!!! 
            toolStripButton3.Checked = !toolStripButton3.Checked;
            FontStyle test = FontStyle.Regular;
            if (toolStripButton1.Checked) test = test | FontStyle.Bold;
            if (toolStripButton2.Checked) test = test | FontStyle.Italic;
            if (toolStripButton3.Checked) test = test | FontStyle.Underline;
            richTextBox1.SelectionFont = new Font(foFa, Convert.ToSingle(toolStripComboBox3.ComboBox.Text), test);

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FontFamily foFa = new FontFamily("Arial"); //BUG!!! BUG!!! BUG!!! BUG!!! BUG!!! BUG!!! 
            toolStripButton2.Checked = !toolStripButton2.Checked;
            FontStyle test = FontStyle.Regular;
            if (toolStripButton1.Checked) test = test | FontStyle.Bold;
            if (toolStripButton2.Checked) test = test | FontStyle.Italic;
            if (toolStripButton3.Checked) test = test | FontStyle.Underline;
            richTextBox1.SelectionFont = new Font(foFa, Convert.ToSingle(toolStripComboBox3.ComboBox.Text), test);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FontFamily foFa = new FontFamily("Arial"); //BUG!!! BUG!!! BUG!!! BUG!!! BUG!!! BUG!!! 
            toolStripButton1.Checked = !toolStripButton1.Checked;
            FontStyle test = FontStyle.Regular;
            if (toolStripButton1.Checked) test = test | FontStyle.Bold;
            if (toolStripButton2.Checked) test = test | FontStyle.Italic;
            if (toolStripButton3.Checked) test = test | FontStyle.Underline;
            richTextBox1.SelectionFont = new Font(foFa, Convert.ToSingle(toolStripComboBox3.ComboBox.Text), test);

        }
    }
}
