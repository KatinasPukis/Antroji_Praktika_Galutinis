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
    public partial class RemarkForm : Form
    {
        private UserDB duombaze;
        
       
        public RemarkForm()
        {
            InitializeComponent();
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RemarkForm_Load(object sender, EventArgs e)
        {
            duombaze = new UserDB();
            int studentid = 0;
            List<Student> studentlist = duombaze.GetStudent();
            List<Grade> gradelist= duombaze.GetGrade();
            int gradetest = 0;
            foreach(Student student in studentlist)
            {
                if(MainWindow.LoggedInUser.GetFullName()== student.Name + " " + student.Surname)
                {
                    studentid = student.Id;
                    
                    
                }
            }
            foreach(Grade grade in gradelist)
            {
                if(studentid == grade.StudentId) // jeigu prisijungusio sutdenot id sutampa su pazymio id esancio studento
                {
                    gradetest = grade.Gradenumber;
                    GradeControl gg = new GradeControl(grade);
                    flowLayoutPanel1.Controls.Add(gg);
                }
            }

           



        }
    }
}
