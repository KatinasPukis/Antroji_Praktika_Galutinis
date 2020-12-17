using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntrojiPraktika.Backend;
using AntrojiPraktika.Backend.Models;

namespace AntrojiPraktika
{
    public partial class AddNewCourse : Form
    {
        private UserDB duombaze;

        public AddNewCourse()
        {
            InitializeComponent();
            duombaze = new UserDB();
            List<Teacher> teacherList = duombaze.GetTeacher();
            foreach (Teacher teacher in teacherList)
            {
                comboBox1.Items.Add(teacher.Name + " " + teacher.Surname);
            }
            List<Group> grouplist = duombaze.GetGroup();
            foreach (Group group in grouplist)
            {
                comboBox2.Items.Add(group.GroupName);
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonAddCourse_Click(object sender, EventArgs e)
        {


            string courseName = textBoxCourseName.Text;
            string teacherselected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            int teacherid = 0;
            int groupid = 0;
            int courseid = 0;
            List<Teacher> teacherlist = duombaze.GetTeacher();
            foreach (Teacher teacher in teacherlist)
            {
                if (teacherselected == teacher.Name + " " + teacher.Surname)
                {
                    teacherid = teacher.Id;

                }
            }
            duombaze.AddNewCourse(courseName, teacherid);
            string groupselected = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
            List<Group> grouplist = duombaze.GetGroup();
            foreach (Group group in grouplist)
            {
                if (groupselected == group.GroupName)
                {
                    groupid = group.Id;
                }
            }
            List<Course> courselist = duombaze.GetCourse();
            foreach (Course course in courselist)
            {
                if (courseName == course.Name)
                {
                    courseid = course.Id;
                }
            }
            duombaze.AddNewLesson(teacherid, groupid, courseid);
           
            MessageBox.Show("Paskaita sekmingai prideta");
            this.Close();
        }
    }
}
