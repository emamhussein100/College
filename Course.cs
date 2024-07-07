using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace College
{
    public partial class Course : Form
    {
        Function Con;
        public Course()
        {
            InitializeComponent();
            Con = new Function();
            ShowCourse();
        }

        private void ShowCourse()
        {
            string Query = "select * from Course";
            CourseList.DataSource = Con.GetData(Query);
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (CName.Text == "" || Duration.Text == "" || Language.Text == "" || CourseType.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string Cname = CName.Text;
                    string duration = Duration.Text;
                    string language = Language.Text;
                    string courseType = CourseType.Text;
                    string Query = "insert into Course values('{0}','{1}','{2}','{3}')";
                    Query = string.Format(Query, Cname, duration, language, courseType);
                    Con.SetData(Query);
                    MessageBox.Show("Course Added!");
                    ShowCourse();
                    CName.Text = "";
                    Duration.Text = "";
                    Language.Text = "";
                    CourseType.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int key = 0;

        private void CourseList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CName.Text = CourseList.SelectedRows[0].Cells[1].Value.ToString();
            Duration.Text = CourseList.SelectedRows[0].Cells[2].Value.ToString();
            Language.Text = CourseList.SelectedRows[0].Cells[3].Value.ToString();
            CourseType.Text = CourseList.SelectedRows[0].Cells[4].Value.ToString();
            if (CName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CourseList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (CName.Text == "" || Duration.Text == "" || Language.Text == "" || CourseType.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string Cname = CName.Text;
                    string duration = Duration.Text;
                    string language = Language.Text;
                    string courseType = CourseType.Text;
                    string Query = "update  Course set CName= '{0}', CDuration = '{1}',Language = '{2}',CourseType = '{3}' where CId ={4}";
                    Query = string.Format(Query, Cname, duration, language, courseType, key);
                    Con.SetData(Query);
                    MessageBox.Show("Course Updated!");
                    ShowCourse();
                    CName.Text = "";
                    Duration.Text = "";
                    Language.Text = "";
                    CourseType.Text = "";
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
                MessageBox.Show("Select a Course!!");
            }
            else
            {
                try
                {

                    string Query = "delete from Course where CId = {0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    MessageBox.Show("Course Deleted!");
                    ShowCourse();
                    CName.Text = "";
                    Duration.Text = "";
                    Language.Text = "";
                    CourseType.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Students obj = new Students();
            obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Faculty obj = new Faculty();
            obj.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
