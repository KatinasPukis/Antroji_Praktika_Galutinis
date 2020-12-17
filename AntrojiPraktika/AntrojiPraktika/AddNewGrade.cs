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
    public partial class AddNewGrade : Form
    {
        private UserDB duombaze;
        public AddNewGrade()
        {
            InitializeComponent();
            duombaze = new UserDB();
            List<Student> studentlist = duombaze.GetStudent();
            List<Group> grouplist = duombaze.GetGroup();
            List<Lesson> lessonlist = duombaze.Getlesson();
            List<Teacher> teacherlist = duombaze.GetTeacher();
            int studentgroupid = 0;
            int teacherid = 0;
            foreach(Teacher teacher in teacherlist)
            {
                if(MainWindow.LoggedInUser.GetFullName()==teacher.Name +" "+ teacher.Surname)
                {
                    teacherid = teacher.Id;
                }
            }
            foreach(Student student in studentlist)
            {
                foreach(Group group in grouplist)
                {
                if(student.GroupName==group.GroupName)
                    {
                        studentgroupid = group.Id;
                        foreach (Lesson lesson in lessonlist)
                        {
                            if (teacherid == lesson.Teacherid && studentgroupid == lesson.Groupid)
                            {
                                
                                    comboBox1.Items.Add(student.Name + " " + student.Surname);
                                
                            }
                        }
                        

                    }

                }
            }
          
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string studentselected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            string gradetext = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
            int grade = Int32.Parse(gradetext);
            int studentid = 0;
            int teacherid = 0;
            List<Teacher> teacherlist = duombaze.GetTeacher();
            foreach(Teacher teacher in teacherlist)
            {
                if(MainWindow.LoggedInUser.GetFullName()== teacher.Name + " " + teacher.Surname)
                {
                    teacherid = teacher.Id;
                }
            }
            

            
            int lessonid = 0;
            List<Student> studentlist = duombaze.GetStudent();
            foreach(Student student in studentlist)
            {
                if(studentselected==student.Name + " " + student.Surname)
                {
                    studentid = student.Id;
                }
            }
            List<Lesson> lessonlist = duombaze.Getlesson();
            foreach(Lesson lesson in lessonlist)
            {
                if(lesson.Teacherid == teacherid)
                {
                    lessonid = lesson.Id;
                }
            }

            duombaze.AddNewGrade(grade, studentid, teacherid,lessonid);
            MessageBox.Show("Pazymis sekmingai pridetas");
            this.Close();
        }
    }
}
