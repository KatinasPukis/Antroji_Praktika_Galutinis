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
    public partial class MainWindow : Form
    {
        

       
        public static User LoggedInUser;
        
        public MainWindow()
        {
            InitializeComponent();
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogInForm l = new LogInForm();
            l.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm r = new RegistrationForm();
            r.ShowDialog();
            this.Show();
            
        }
    }
}
