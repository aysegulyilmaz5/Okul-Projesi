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
    public partial class Form_StGrades : Form
    {
        public Form_StGrades()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-IP4RS08;Initial Catalog=School;Integrated Security=True");
        public string number;
        private void Form_StGrades_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT LessonName,Exam1,Exam2,Exam3,Project,Average,Situation FROM Table_Grades INNER JOIN Table_Lesson ON Table_Grades.LessonId = Table_Lesson.LessonId WHERE StId = 1", baglanti);
            command.Parameters.AddWithValue("@p1", number);
            //this.Text = number.ToString();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
