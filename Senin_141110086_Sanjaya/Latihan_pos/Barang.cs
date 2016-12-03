using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Latihan_6_1
{
    public partial class btnSimpan : Form
    {

        public btnSimpan()
        {
            InitializeComponent();
        }
        MySqlConnection koneksi = new MySqlConnection("Server=127.0.0.1;Database=pos;Uid=root;Pwd=12345");
        DataTable oDT;
        MySqlDataAdapter oDA;
        MySqlCommand command;
        void reset()
        {
            command = new MySqlCommand("select ifnull(max(id),0)+1 from barang", koneksi);
            oDA = new MySqlDataAdapter(command);
            oDT = new DataTable();
            oDA.Fill(oDT);
            txtID.Text = oDT.Rows[0][0].ToString();
            txtKode.Text = "";
            txtNama.Text = "";
            txtJumlahAwal.Text = "";
            txtHargaJual.Text = "";
            txtHargaHPP.Text = "";
            dtpCreatedAt.Value = DateTime.Today;
            dtpEditedAt.Value = DateTime.Today;
        }
        void showAll()
        {
            command =new MySqlCommand( "select * from barang",koneksi);
            oDA = new MySqlDataAdapter(command);
            oDT = new DataTable();
            oDA.Fill(oDT);
            dataGridView1.DataSource = oDT;
        }
        void insertData()
        {
            try
            {
                koneksi.Open();
                command = new MySqlCommand("insert into barang values(@id,@kode,@nama,@jumlahawal,@hargahpp,@hargajual,@createdat,@editedat)", koneksi);
                command.Parameters.AddWithValue("@id", txtID.Text);
                command.Parameters.AddWithValue("@kode", txtKode.Text);
                command.Parameters.AddWithValue("@nama", txtNama.Text);
                command.Parameters.AddWithValue("@jumlahawal", int.Parse(txtNama.Text));
                command.Parameters.AddWithValue("@hargahpp", Convert.ToDecimal(txtHargaHPP.Text));
                command.Parameters.AddWithValue("@hargajual", Convert.ToDecimal(txtHargaJual.Text));
                command.Parameters.AddWithValue("@createdat", dtpCreatedAt.Value);
                command.Parameters.AddWithValue("@editedat", dtpEditedAt.Value);
                command.ExecuteNonQuery();
                koneksi.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            showAll();
            reset();
        }
        private void Barang_Load(object sender, EventArgs e)
        {
            showAll();
            reset();
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int index = dataGridView1.SelectedCells[0].RowIndex;
                txtID.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                txtKode.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                txtNama.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                txtJumlahAwal.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
                txtHargaHPP.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
                txtHargaJual.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
                //MessageBox.Show(dataGridView1.Rows[index].Cells[6].Value.ToString());
                dtpCreatedAt.Value = DateTime.Parse(dataGridView1.Rows[index].Cells[6].Value.ToString());
                dtpEditedAt.Value = DateTime.Parse(dataGridView1.Rows[index].Cells[7].Value.ToString());
            }

        }
    }
}
