using System.Windows.Forms;

namespace College
{
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
            Con = new Function();
            FetchCourse();
            ShowStudent();
        }
        Function Con;
        private void FetchCourse()
        {
            string Query = "select * from Course";
            CourseCb.ValueMember = Con.GetData(Query).Columns["CId"].ToString();
            CourseCb.DisplayMember = Con.GetData(Query).Columns["CName"].ToString();
            CourseCb.DataSource = Con.GetData(Query);
        }
        private void ShowStudent()
        {
            string Query = "select * from Student";
            StudentList.DataSource = Con.GetData(Query);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Faculty obj = new Faculty();
            obj.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (SName.Text == "" || GenderC.SelectedIndex == -1 || SAddress.Text == "" || SMobile.Text == "" || CourseCb.SelectedIndex == -1 || SEmail.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string Sname = SName.Text;
                    string mobile = SMobile.Text;
                    string email = SEmail.Text;
                    string address = SAddress.Text;
                    string Gender = GenderC.SelectedItem.ToString();
                    int course_Id = Convert.ToInt32(CourseCb.SelectedValue.ToString());
                    string Query = "insert into Student values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, Sname, Gender, course_Id, mobile, email, address);
                    Con.SetData(Query);
                    MessageBox.Show("Student Added!");
                    ShowStudent();
                    SName.Text = "";
                    SEmail.Text = "";
                    SAddress.Text = "";
                    SMobile.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int key = 0;
        private void StudentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SName.Text = StudentList.SelectedRows[0].Cells[1].Value.ToString();
            GenderC.Text = StudentList.SelectedRows[0].Cells[2].Value.ToString();
            CourseCb.Text = StudentList.SelectedRows[0].Cells[3].Value.ToString();
            SMobile.Text = StudentList.SelectedRows[0].Cells[4].Value.ToString();
            SEmail.Text = StudentList.SelectedRows[0].Cells[5].Value.ToString();
            SAddress.Text = StudentList.SelectedRows[0].Cells[6].Value.ToString();
            if (SName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(StudentList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (SName.Text == "" || GenderC.SelectedIndex == -1 || SAddress.Text == "" || SMobile.Text == "" || CourseCb.SelectedIndex == -1 || SEmail.Text == "")
            {
                MessageBox.Show("Missig Data!!");
            }
            else
            {
                try
                {
                    string Sname = SName.Text;
                    string mobile = SMobile.Text;
                    string email = SEmail.Text;
                    string address = SAddress.Text;
                    string Gender = GenderC.SelectedItem.ToString();
                    int course_Id = Convert.ToInt32(CourseCb.SelectedValue.ToString());
                    string Query = "update  Student set SName = '{0}',Gender = '{1}', Course_Id = '{2}', Mobile = '{3}', Email = '{4}', Address= '{5}' where RollNumber = {6}";
                    Query = string.Format(Query, Sname, Gender, course_Id, mobile, email, address, key);
                    Con.SetData(Query);
                    MessageBox.Show("Student Updated!");
                    ShowStudent();
                    SName.Text = "";
                    SEmail.Text = "";
                    SAddress.Text = "";
                    SMobile.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a Student!!");
            }
            else
            {
                try
                {

                    string Query = "delete from Student where RollNumber = {0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    MessageBox.Show("Student Deleted!");
                    ShowStudent();
                    SName.Text = "";
                    SEmail.Text = "";
                    SAddress.Text = "";
                    SMobile.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Course obj = new Course();
            obj.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Fee fee = new Fee();
            fee.Show();
            this.Hide();
        }
    }
}
