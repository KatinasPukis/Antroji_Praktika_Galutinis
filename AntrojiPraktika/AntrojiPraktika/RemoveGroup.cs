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
    public partial class RemoveGroup : Form
    {
        private UserDB duombaze;
        public RemoveGroup()
        {
            duombaze = new UserDB();
            InitializeComponent();
            List<Group> grouplist = duombaze.GetGroup();
            foreach(Group group in grouplist)
            {
                comboBox1.Items.Add(group.GroupName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string groupselected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            int groupid = 0;
            List<Group> grouplist = duombaze.GetGroup();
            foreach (Group group in grouplist)
            {
                if(groupselected==group.GroupName)
                {
                    groupid = group.Id;
                }
            }
           
            
            duombaze.RemoveGroup(groupid, groupselected);
            MessageBox.Show("Grupe sekmingai panaikinta");
            this.Close();
        }
    }
}
