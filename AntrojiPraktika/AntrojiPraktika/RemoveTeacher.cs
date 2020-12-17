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
    public partial class RemoveTeacher : Form
    {
        private UserDB duombaze;
        public RemoveTeacher()
        {
            InitializeComponent();
            duombaze = new UserDB();
            List<Teacher> teacherlist = duombaze.GetTeacher();
            
            foreach(Teacher teacher in teacherlist)
            {
                comboBox1.Items.Add(teacher.Name + " " + teacher.Surname);
                
            }
        }

        private void RemoveTeacher_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string teacherelected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            int teacherid = 0;
            string teachername = "";
            string teachersurname = "";
            List<Teacher> teacherlist = duombaze.GetTeacher();
            foreach(Teacher teacher in teacherlist)
            {
                if(teacherelected == teacher.Name + " " + teacher.Surname)
                {
                    teacherid = teacher.Id;
                    teachername = teacher.Name;
                    teachersurname = teacher.Surname;
                }
            }
            duombaze.RemoveTeacher(teacherid, teachername, teachersurname);
            MessageBox.Show("Destytojas sekmingai pasalintas");
            this.Close();
        }
    }
}
