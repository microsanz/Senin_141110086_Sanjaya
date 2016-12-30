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
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
        }
        string max;
        MySqlConnection koneksi = new MySqlConnection("Server=127.0.0.1;Database=pos;Uid=root;Pwd=12345");
        DataTable oDT;
        MySqlDataAdapter oDA;
        MySqlCommand command;
        void reset()
        {
            command = new MySqlCommand("select ifnull(max(id),0)+1 from supplier", koneksi);
            oDA = new MySqlDataAdapter(command);
            oDT = new DataTable();
            oDA.Fill(oDT);
            max = oDT.Rows[0][0].ToString();
            txtID.Text = oDT.Rows[0][0].ToString();
            txtKode.Text = "";
            txtNama.Text = "";
            txtJumlahAwal.Text = "";
            dtpCreatedAt.Value = DateTime.Today;
            dtpEditedAt.Value = DateTime.Today;
        }
        void showAll()
        {
            command = new MySqlCommand("select * from supplier", koneksi);
            oDA = new MySqlDataAdapter(command);
            oDT = new DataTable();
            oDA.Fill(oDT);

            dataGridView1.DataSource = oDT;
        }
        void filteredSelect()
        {
            command = new MySqlCommand("select * from supplier where kode like concat('%', @kode, '%') and nama like concat('%', @nama, '%')", koneksi);
            command.Parameters.AddWithValue("@kode", txtKode.Text);
            command.Parameters.AddWithValue("@nama", txtNama.Text);
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
                command = new MySqlCommand("insert into supplier values(@id,@kode,@nama,@alamat,@createdat,@editedat)", koneksi);
                command.Parameters.AddWithValue("@id", txtID.Text);
                command.Parameters.AddWithValue("@kode", txtKode.Text);
                command.Parameters.AddWithValue("@nama", txtNama.Text);
                command.Parameters.AddWithValue("@alamat", txtJumlahAwal.Text);
                command.Parameters.AddWithValue("@createdat", dtpCreatedAt.Value);
                command.Parameters.AddWithValue("@editedat", dtpEditedAt.Value);
                command.ExecuteNonQuery();
                koneksi.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            showAll();
            reset();
        }
        void updateData()
        {
            koneksi.Open();
            try
            {
                command = new MySqlCommand("update supplier set kode=@kode,nama=@nama,Alamat=@alamat,created_at=@createdat,updated_at=@editedat where id=@id", koneksi);
                command.Parameters.AddWithValue("@id", txtID.Text);
                command.Parameters.AddWithValue("@kode", txtKode.Text);
                command.Parameters.AddWithValue("@nama", txtNama.Text);
                command.Parameters.AddWithValue("@alamat", txtJumlahAwal.Text);
                command.Parameters.AddWithValue("@createdat", dtpCreatedAt.Value);
                command.Parameters.AddWithValue("@editedat", DateTime.Today);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            showAll();
            reset();
            koneksi.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtID.Text == max)
            {
                insertData();
            }
            else
            {
                updateData();
            }
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
                dtpCreatedAt.Value = DateTime.Parse(dataGridView1.Rows[index].Cells[4].Value.ToString());
                dtpEditedAt.Value = DateTime.Parse(dataGridView1.Rows[index].Cells[5].Value.ToString());
            }

        }

        private void txtKode_TextChanged(object sender, EventArgs e)
        {
            filteredSelect();
        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {
            filteredSelect();
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            showAll();
            reset();
            dataGridView1.ClearSelection();
        }
    }
}
