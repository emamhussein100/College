using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace College
{
    public partial class Faculty : Form
    {
        Function Con;
        public Faculty()
        {
            InitializeComponent();
            Con = new Function();
            FetchFacultyCourse();
            ShowFaculty();
        }
        private void FetchFacultyCourse()
        {
            string Query = "select * from Course";
            CourseCb.ValueMember = Con.GetData(Query).Columns["CId"].ToString();
            CourseCb.DisplayMember = Con.GetData(Query).Columns["CName"].ToString();
            CourseCb.DataSource = Con.GetData(Query);
        }
        private void ShowFaculty()
        {
            string Query = "select * from Faculty";
            FacultyList.DataSource = Con.GetData(Query);
        }
        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Students obj = new Students();
            obj.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (FName.Text == "" || GenderC.SelectedIndex == -1 || FacultyDesignation.SelectedIndex == -1 || FMobile.Text == "" || CourseCb.SelectedIndex == -1 || FEmail.Text == "" || FEducatio.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string fname = FName.Text;
                    string mobile = FMobile.Text;
                    string email = FEmail.Text;
                    string Education = FEducatio.Text;
                    string Gender = GenderC.SelectedItem.ToString();
                    string facultyDesignation = FacultyDesignation.SelectedItem.ToString();
                    int course_Id = Convert.ToInt32(CourseCb.SelectedValue.ToString());
                    string Query = "insert into Faculty values('{0}','{1}','{2}','{3}','{4}','{5}',{6})";
                    Query = string.Format(Query, fname, Gender, mobile, email, Education, facultyDesignation, course_Id);
                    Con.SetData(Query);
                    MessageBox.Show("Faculty Added!");
                    ShowFaculty();
                    FName.Text = "";
                    FEmail.Text = "";
                    FEducatio.Text = "";
                    FMobile.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int key = 0;
        private void FacultyList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FName.Text = FacultyList.SelectedRows[0].Cells[1].Value.ToString();
            GenderC.Text = FacultyList.SelectedRows[0].Cells[2].Value.ToString();
            FMobile.Text = FacultyList.SelectedRows[0].Cells[3].Value.ToString();
            FEmail.Text = FacultyList.SelectedRows[0].Cells[4].Value.ToString();
            FEducatio.Text = FacultyList.SelectedRows[0].Cells[5].Value.ToString();
            FacultyDesignation.Text = FacultyList.SelectedRows[0].Cells[6].Value.ToString();
            CourseCb.Text = FacultyList.SelectedRows[0].Cells[7].Value.ToString();
            if (FName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(FacultyList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (FName.Text == "" || GenderC.SelectedIndex == -1 || FacultyDesignation.SelectedIndex == -1 || FMobile.Text == "" || CourseCb.SelectedIndex == -1 || FEmail.Text == "" || FEducatio.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string fname = FName.Text;
                    string mobile = FMobile.Text;
                    string email = FEmail.Text;
                    string Education = FEducatio.Text;
                    string Gender = GenderC.SelectedItem.ToString();
                    string facultyDesignation = FacultyDesignation.SelectedItem.ToString();
                    int course_Id = Convert.ToInt32(CourseCb.SelectedValue.ToString());
                    string Query = "update  Faculty set FName = '{0}',Gender = '{1}',Mobile = '{2}', Email = '{3}',Education = '{4}',Designation = '{5}', Course_Id = {6} where FId = {7}";
                    Query = string.Format(Query, fname, Gender, mobile, email, Education, facultyDesignation, course_Id, key);
                    Con.SetData(Query);
                    MessageBox.Show("Faculty Updated!");
                    ShowFaculty();
                    FName.Text = "";
                    FEmail.Text = "";
                    FEducatio.Text = "";
                    FMobile.Text = "";
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
                MessageBox.Show("Select a Faculty!!");
            }
            else
            {
                try
                {

                    string Query = "delete from Faculty where FId = {0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    MessageBox.Show("Faculty Deleted!");
                    ShowFaculty();
                    FName.Text = "";
                    FEmail.Text = "";
                    FEducatio.Text = "";
                    FMobile.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Course obj = new Course();
            obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

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
