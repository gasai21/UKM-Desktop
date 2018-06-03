using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UKM
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            ManageCaptain ca = new ManageCaptain();
            ca.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagementCoach mc = new ManagementCoach();
            mc.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagementUKM mk = new ManagementUKM();
            mk.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagementPlace mp = new ManagementPlace();
            mp.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagementSchedule ms = new ManagementSchedule();
            ms.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
