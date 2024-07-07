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
    public partial class Fee : Form
    {
        public Fee()
        {
            InitializeComponent();
            Con = new Function();
            ShowFees();
            FetchFeesCourse();
            FetchFeesStudent();
        }
        Function Con;
        private void FetchFeesCourse()
        {
            string Query = "select * from Course";
            CourseCb.ValueMember = Con.GetData(Query).Columns["CId"].ToString();
            CourseCb.DisplayMember = Con.GetData(Query).Columns["CName"].ToString();
            CourseCb.DataSource = Con.GetData(Query);
        }
        private void FetchFeesStudent()
        {
            string Query = "select * from Student";
            StudentCb.ValueMember = Con.GetData(Query).Columns["RollNumber"].ToString();
            StudentCb.DisplayMember = Con.GetData(Query).Columns["SName"].ToString();
            StudentCb.DataSource = Con.GetData(Query);
        }

        private void ShowFees()
        {
            string Query = "select * from Fees";
            FeesList.DataSource = Con.GetData(Query);
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (StudentCb.SelectedIndex == -1 || CourseCb.SelectedIndex == -1 || AdcademicY.Text == "" || TFees.Text == "" || PFees.Text == "" || FBalance.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string Academic = AdcademicY.Text;
                    string tfees = TFees.Text;
                    string pfees = PFees.Text;
                    string balance = FBalance.Text;
                    int course_Id = Convert.ToInt32(CourseCb.SelectedValue.ToString());
                    int Student_Id = Convert.ToInt32(StudentCb.SelectedValue.ToString());
                    string Query = "insert into Fees values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, Student_Id, course_Id, Academic, tfees, pfees, balance);
                    Con.SetData(Query);
                    MessageBox.Show("Fees Added!");
                    ShowFees();
                    AdcademicY.Text = "";
                    TFees.Text = "";
                    PFees.Text = "";
                    FBalance.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int key = 0;
        private void FeesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            StudentCb.Text = FeesList.SelectedRows[0].Cells[1].Value.ToString();
            CourseCb.Text = FeesList.SelectedRows[0].Cells[2].Value.ToString();
            AdcademicY.Text = FeesList.SelectedRows[0].Cells[3].Value.ToString();
            TFees.Text = FeesList.SelectedRows[0].Cells[4].Value.ToString();
            PFees.Text = FeesList.SelectedRows[0].Cells[5].Value.ToString();
            FBalance.Text = FeesList.SelectedRows[0].Cells[6].Value.ToString();
            if (AdcademicY.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(FeesList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (StudentCb.SelectedIndex == -1 || CourseCb.SelectedIndex == -1 || AdcademicY.Text == "" || TFees.Text == "" || PFees.Text == "" || FBalance.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string Academic = AdcademicY.Text;
                    string tfees = TFees.Text;
                    string pfees = PFees.Text;
                    string balance = FBalance.Text;
                    int course_Id = Convert.ToInt32(CourseCb.SelectedValue.ToString());
                    int Student_Id = Convert.ToInt32(StudentCb.SelectedValue.ToString());
                    string Query = "Update  Fees set Student_Id = '{0}', Course_Id = '{1}', AcademicYear = '{2}', TotalFees = '{3}', PaidFees = '{4}', Balance = '{5}' where FCode = {6} ";
                    Query = string.Format(Query, Student_Id, course_Id, Academic, tfees, pfees, balance, key);
                    Con.SetData(Query);
                    MessageBox.Show("Fees Updated!");
                    ShowFees();
                    AdcademicY.Text = "";
                    TFees.Text = "";
                    PFees.Text = "";
                    FBalance.Text = "";
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
                MessageBox.Show("Select a Fee!!");
            }
            else
            {
                try
                {

                    string Query = "delete from Fees where FCode = {0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    MessageBox.Show("Fee Deleted!");
                    ShowFees();
                    AdcademicY.Text = "";
                    TFees.Text = "";
                    PFees.Text = "";
                    FBalance.Text = "";
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
            Faculty faculty = new Faculty();
            faculty.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Course course = new Course();
            course.Show();
            this.Hide();
        }
    }
}
