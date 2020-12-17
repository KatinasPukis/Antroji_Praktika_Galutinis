using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntrojiPraktika.Backend.Models;

namespace AntrojiPraktika
{
    public partial class GradeControl : UserControl
    {
        public UserDB duombaze = new UserDB();
        public GradeControl(Grade grade)
        {
            InitializeComponent();
            
            List<Lesson> lessonlist = duombaze.Getlesson();
            List<Course> courselist = duombaze.GetCourse();
            List<Grade> gradelist = duombaze.GetGrade();
            string lessonname = "";
            foreach (Lesson lesson in lessonlist)
            {
                if (grade.LessonId == lesson.Id)
                {
                    foreach (Course course in courselist)
                    {
                        if (lesson.Courseid == course.Id)
                        {
                          lessonname = course.Name;
                        }
                    }
                }
            }
            labelCourseName.Text = lessonname.ToString();
            labelGrade.Text = "Ivertinimas:" + " " + grade.Gradenumber.ToString();
        }
    }
}
