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
using System.Data.SqlClient;

namespace AntrojiPraktika
{
    public partial class LessonList : Form
    {
        private UserDB duombaze= new UserDB();
        
        public LessonList()
        {
            InitializeComponent();
            
            
        }

        private void LessonList_Load(object sender, EventArgs e)
        {
            
            List<Group> grouplist = duombaze.GetGroup();
            List<Course> courselist = duombaze.GetCourse();
            int groupid = 0;
            int courseid = 0;
            foreach (Group group in grouplist)
            {
                if (MainWindow.LoggedInUser.GetGroupName() == group.GroupName)
                {
                    groupid = group.Id;
                }
            }
               
            List<Lesson> lessonlist = duombaze.Getlesson();
            Console.WriteLine(duombaze.Getlesson());
            foreach (Lesson lesson in lessonlist)
                {
                    if (groupid == lesson.Groupid)
                    {
                        courseid = lesson.Courseid;
                        foreach(Course course in courselist)
                    {
                        if(courseid == course.Id)
                        {
                            LessonControl lol = new LessonControl(course);
                            flowLayoutPanel1.Controls.Add(lol);
                        }
                    }

                    }
                }
                string coursename = null;
                foreach (Course course in courselist)
                {
                    if (courseid == course.Id)
                    {
                        coursename = course.Name;
                    }
                }
                
          
        }
    }
}
