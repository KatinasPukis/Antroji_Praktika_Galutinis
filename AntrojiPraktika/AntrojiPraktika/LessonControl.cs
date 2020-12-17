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
    public partial class LessonControl : UserControl
    {
        public UserDB duombaze = new UserDB();
        public LessonControl(Course course)
        {
            InitializeComponent();
            labelCousename.Text = course.Name;
            
            List<Teacher> teacherlist = duombaze.GetTeacher();
            foreach(Teacher teacher in teacherlist)
            {
                if(teacher.Id==course.Teacherid)
                {
                    string teachername = teacher.Name + " " + teacher.Surname;
                    labelteachername.Text = teachername;
                }
            }
            
          
            



        }
    }
}
