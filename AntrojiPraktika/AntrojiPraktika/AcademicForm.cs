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
using AntrojiPraktika.Backend.Models;

namespace AntrojiPraktika
{
    public partial class AcademicForm : Form
    {
        private UserDB duombaze = new UserDB();
        
        public AcademicForm()
        {
            InitializeComponent();
            labelFullinfo.Text = MainWindow.LoggedInUser.GetFullName();
            label1.Text = MainWindow.LoggedInUser.GetGroupName();
            

            





        }

        private void ButtonPaskaitos_Click(object sender, EventArgs e)
        {
          
        }

        private void AcademicForm_Load(object sender, EventArgs e)
        {
            if(MainWindow.LoggedInUser.GetUserType()=="Studentas")
            {
                buttonPaskaitos.Visible = true;
                buttonIvertinimai.Visible = true;
            }
            if(MainWindow.LoggedInUser.GetUserType()=="Destytojas")
            {
                buttonAddgrade.Visible = true;
                buttonchangegrade.Visible = true;
            }
            if(MainWindow.LoggedInUser.GetUserType()=="Admin")
            {
                buttonAddCourse.Visible = true;
                buttonRemoveStudent.Visible = true;
                buttonRemoveGroup.Visible = true;
                buttonAddNewGroup.Visible = true;
                buttonRemoveLesson.Visible = true;
                buttonRemoveteacher.Visible = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAddCourse_Click(object sender, EventArgs e)
        {
            AddNewCourse c = new AddNewCourse();
            c.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LessonList l = new LessonList();
            l.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAddgrade_Click(object sender, EventArgs e)
        {
            AddNewGrade g = new AddNewGrade();
                g.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RemarkForm r = new RemarkForm();
                r.ShowDialog();
        }

        private void buttonchangegrade_Click(object sender, EventArgs e)
        {
            ChangeGrade c = new ChangeGrade();
            c.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            RemoveStudent rs = new RemoveStudent();
            rs.ShowDialog();
        }

        private void buttonRemoveGroup_Click(object sender, EventArgs e)
        {
            RemoveGroup rg = new RemoveGroup();
            rg.ShowDialog();
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            AddNewGroup ag = new AddNewGroup();
            ag.ShowDialog();
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            RemoveLesson rl = new RemoveLesson();
            rl.ShowDialog();
        }

        private void button1_Click_5(object sender, EventArgs e)
        {
            RemoveTeacher rt = new RemoveTeacher();
            rt.ShowDialog();
        }

        private void button1_Click_6(object sender, EventArgs e)
        {
            this.Close();
            MainWindow mw = new MainWindow();
            mw.ShowDialog();
        }
    }
}
