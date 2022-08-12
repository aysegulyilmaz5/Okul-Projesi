using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace School_Project
{
    public partial class Form_Club : Form
    {
        public Form_Club()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-IP4RS08;Initial Catalog=School;Integrated Security=True");
        public void list()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Table_Club", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void Form_Club_Load(object sender, EventArgs e)
        {
            list();
        }

        private void button_lists_Click(object sender, EventArgs e)
        {
            list();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand command = new SqlCommand("INSERT INTO Table_Club (ClubName) VALUES(@p1)",baglanti);
            command.Parameters.AddWithValue("@p1", textBox_name.Text);
            command.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Club is added in list");
            list();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.LightSlateGray;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_ıd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox_name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand command = new SqlCommand("Delete  From Table_Club where ClubId=@p1", baglanti);
            command.Parameters.AddWithValue("@p1", textBox_ıd.Text);
            command.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Club is deleted");
            list();


        }

        private void button_update_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand command = new SqlCommand("Update Tabel_Club set ClubName = @p1 where ClubId=@p2", baglanti);
            command.Parameters.AddWithValue("@p1", textBox_name.Text);
            command.Parameters.AddWithValue("@p2", textBox_ıd.Text);
            command.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Club is update");
            list();

        }
    }
}
