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
    public partial class ChangeGrade : Form
    {
        private UserDB duombaze;
        public ChangeGrade()
        {
            InitializeComponent();
            duombaze = new UserDB();
            List<Student> studentlist = duombaze.GetStudent();
            List<Group> grouplist = duombaze.GetGroup();
            List<Lesson> lessonlist = duombaze.Getlesson();
            List<Teacher> teacherlist = duombaze.GetTeacher();
            int studentgroupid = 0;
            int teacherid = 0;
            foreach (Teacher teacher in teacherlist)
            {
                if (MainWindow.LoggedInUser.GetFullName() == teacher.Name + " " + teacher.Surname)
                {
                    teacherid = teacher.Id;
                }
            }
            foreach (Student student in studentlist)
            {
                foreach (Group group in grouplist)
                {
                    if (student.GroupName == group.GroupName)
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

        private void ChangeGrade_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentselected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            int studentid = 0;
            int studentgrade = 0;
            int lessonid = 0;
            int teacherid = 0;
            List<Student> studenlist = duombaze.GetStudent();
            foreach (Student student in studenlist)
            {
                if (studentselected == student.Name + " " + student.Surname)
                {
                    studentid = student.Id;
                }
            }
            List<Grade> gradelist = duombaze.GetGrade();
            foreach (Grade grade in gradelist)
            {
                if (studentid == grade.StudentId)
                {
                    studentgrade = grade.Gradenumber;
                }

            }
            Console.WriteLine(studentgrade);
            studentgrade = Int32.Parse(this.comboBox2.GetItemText(this.comboBox2.SelectedItem));
            List<Teacher> teacherlist = duombaze.GetTeacher();
            foreach(Teacher teacher in teacherlist)
            {
                if(MainWindow.LoggedInUser.GetFullName()== teacher.Name+ " "+ teacher.Surname)
                {
                    teacherid = teacher.Id;
                }
            }
            List<Lesson> lessonlist = duombaze.Getlesson();
            foreach(Grade grade in gradelist)
            {
                if(teacherid==grade.TeacherId)
                {
                    foreach(Lesson lesson in lessonlist)
                    {
                        if(teacherid==lesson.Teacherid)
                        {
                        lessonid = lesson.Id;

                        }
                    }
                }
            }
            duombaze.ChangeGrade(studentgrade, studentid, teacherid, lessonid);
            MessageBox.Show("Sekmingai pakeistas pazymis!");
            this.Close();
            

        }
    }
}
