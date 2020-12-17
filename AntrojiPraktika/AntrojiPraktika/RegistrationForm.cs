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
    public partial class RegistrationForm : Form
    {
        private UserDB duombaze;
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            duombaze = new UserDB();
            List<Group> grouplist = duombaze.GetGroup();
            foreach (Group group in grouplist)
            {
                comboBox2.Items.Add(group.GroupName);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {

                
                
                User user = new User(0,textBoxName.Text,textBoxSurname.Text,dateTimePicker1.Value,textBoxName.Text,textBoxSurname.Text,comboBox1.Text, comboBox2.Text);
                if(comboBox1.Text=="Studentas")
                {
                    
                    duombaze.AddNewStudent(textBoxName.Text, textBoxSurname.Text, comboBox2.Text);
                }
                if (comboBox1.Text == "Destytojas")
                {

                    duombaze.AddNewTeacher(textBoxName.Text, textBoxSurname.Text);
                }
                duombaze.Register(user);
                MessageBox.Show($" Sekmingai priregistruota");
                this.Close();



            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
