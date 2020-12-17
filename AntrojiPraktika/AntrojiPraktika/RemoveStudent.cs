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
    public partial class RemoveStudent : Form
    {
        private UserDB duombaze;
        public RemoveStudent()
        {
            InitializeComponent();
            duombaze = new UserDB();
            List<Student> studentlist = duombaze.GetStudent();
            foreach(Student student in studentlist)
            {
                comboBox1.Items.Add(student.Name + " " + student.Surname);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentselected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            int studentid = 0;
            string studentname="";
            string studentsurname="";
            List<Student> studentlist = duombaze.GetStudent();
            
            foreach (Student student in studentlist)
            {
                if(studentselected== student.Name + " " + student.Surname)
                {
                    studentid = student.Id;
                    studentname = student.Name;
                    studentsurname = student.Surname;
                }
            }
            
            duombaze.RemoveStudent(studentid,studentname,studentsurname);
            MessageBox.Show("Studentas sekmingai pasalintas");
            this.Close();
        }
    }
}
