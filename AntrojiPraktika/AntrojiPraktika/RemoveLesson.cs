using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntrojiPraktika.Backend.Models;

namespace AntrojiPraktika
{
    public partial class RemoveLesson : Form
    {
        private UserDB duombaze;
        public RemoveLesson()
        {
            InitializeComponent();
            duombaze = new UserDB();
            List<Course> courselist = duombaze.GetCourse();
            List<Lesson> lessonlist = duombaze.Getlesson();
            foreach (Course course in courselist)
            {
                foreach(Lesson lesson in lessonlist)
                {
                    if(lesson.Courseid==course.Id)
                    {
                     comboBox1.Items.Add(course.Name);

                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string courseselected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            int courseid = 0;
            int lessonid = 0;
            List<Course> courselist = duombaze.GetCourse();
            List<Lesson> lessonlist = duombaze.Getlesson();
            foreach (Course course in courselist)
            {
                if(courseselected==course.Name)
                {
                    courseid = course.Id;
                }
            }
            foreach(Lesson lesson in lessonlist)
            {
                if(lesson.Courseid==courseid)
                {
                    lessonid = lesson.Id;
                }
            }

            duombaze.RemoveLesson(lessonid , courseid);
            MessageBox.Show("Paskaita sekmingai panaikinta");
            this.Close();
        }

        private void RemoveLesson_Load(object sender, EventArgs e)
        {
            
        }
    }
}
