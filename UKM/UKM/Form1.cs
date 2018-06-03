using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UKM.ServiceLogin;

namespace UKM
{
    public partial class Form1 : Form
    {
        ServiceLogin.Service1Client obj = new ServiceLogin.Service1Client();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validasi() == 0)
            {
                if (doLogin() > 0)
                {
                    this.Hide();
                    Menu m = new Menu();
                    m.Show();
                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect");
                }
            }
            else {
                validasi();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private int validasi() {
            int i = 0;
            if(txtUsername.Text.Length == 0){
                errorProvider1.SetError(txtUsername, "Username Can't be null");
                txtUsername.Focus();
                i = 1;
            }
            else if (txtPassword.Text.Length == 0)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPassword, "Password can't be null");
                txtPassword.Focus();
                i = 1;
            }
            else {
                errorProvider1.Clear();
                i = 0;
            }
            return i;
        }

        private int doLogin(){
            int login = obj.doLoginAdmin(txtUsername.Text, txtPassword.Text);
            return login;
        }
    }
}
