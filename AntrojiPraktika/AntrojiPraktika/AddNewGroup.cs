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
    public partial class AddNewGroup : Form
    {
        private UserDB duombaze;
        public AddNewGroup()
        {
            InitializeComponent();
            duombaze = new UserDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string groupname = textBox1.Text;
            duombaze.AddNewGroup(groupname);
            MessageBox.Show("Nauja grupe sekmingai prideta");
            this.Close();
        }
    }
}
