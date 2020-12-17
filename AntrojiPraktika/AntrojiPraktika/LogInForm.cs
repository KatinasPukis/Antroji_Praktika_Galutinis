using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntrojiPraktika
{
    public partial class LogInForm : Form
    {
        private UserDB duombaze = new UserDB();
        public LogInForm()
        {
            InitializeComponent();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                MainWindow.LoggedInUser = duombaze.Login(textBoxUsername.Text, textBoxPassword.Text);
                this.Close();
                AcademicForm a = new AcademicForm();
                a.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }
    }
}
