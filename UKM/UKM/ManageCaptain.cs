using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UKM.CrudCaptain;

namespace UKM
{
    public partial class ManageCaptain : Form
    {
        CrudCaptain.Service1Client obj = new CrudCaptain.Service1Client();
        public ManageCaptain()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu m = new Menu();
            m.Show();
        }

        private void ManageCaptain_Load(object sender, EventArgs e)
        {
            getData();
            getUKM();
        }

        private void getUKM() {
            IList<cUkm> data = new List<cUkm>();
            data = obj.GetUKM("");

            for (int i = 0; i < data.Count(); i++)
            {
                cbUkm.Items.Add(data[i].Ukmname);
            }
        }

        private void saveData() {
            Account acc = new Account();
            StudentUKM su = new StudentUKM();
            acc.Nim = txtNim.Text;
            acc.Name = txtName.Text;
            acc.Gender = cbgender.SelectedItem.ToString();
            acc.Address = txtAddress.Text;
            acc.PhoneNumber = txtPhone.Text;
            acc.Faculty = cbFaculty.SelectedItem.ToString();
            acc.Major = txtMajor.Text;
            acc.Batch = cbBatch.SelectedItem.ToString();
            acc.Username = txtUsername.Text;
            acc.Password = txtPassword.Text;
            string conv = obj.convertukm(cbUkm.SelectedItem.ToString());
            su.Ukmid = conv;

            int result = obj.doInsertCaptainAdmin(acc,su);
            if (result > 0)
            {
                MessageBox.Show("Save Success!");
            }
            else {
                MessageBox.Show("Save Fail");
            }
            
        }

        private void deleteData() {
            int result = obj.doDeleteAdmin(txtid.Text);
            if (result > 0)
            {
                MessageBox.Show("Delete Success!");
            }
            else {
                MessageBox.Show("Delete Fail!");
            }
        }

        private void updateData() {
            Account acc = new Account();
            StudentUKM su = new StudentUKM();
            acc.Nim = txtNim.Text;
            acc.Name = txtName.Text;
            acc.Gender = cbgender.SelectedItem.ToString();
            acc.Address = txtAddress.Text;
            acc.PhoneNumber = txtPhone.Text;
            acc.Faculty = cbFaculty.SelectedItem.ToString();
            acc.Major = txtMajor.Text;
            acc.Batch = cbBatch.SelectedItem.ToString();
            acc.Username = txtUsername.Text;
            acc.Password = txtPassword.Text;
            string conv = obj.convertukm(cbUkm.SelectedItem.ToString());
            su.Ukmid = conv;
            acc.Id = txtid.Text;

            int result = obj.doUpdateAdmin(acc);
            if (result > 0)
            {
                MessageBox.Show("Update Success!");
            }
            else {
                MessageBox.Show("Update Fail!");
            }
        }

        private void searchData() {
            lvCaptain.Items.Clear();
            lvCaptain.Columns.Clear();
            lvCaptain.Columns.Add("ID", 70, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("NIM", 150, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("Name", 150, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("Gender", 150, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("Address", 150, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("Phone Number", 150, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("Faculty", 150, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("Major", 150, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("Batch", 150, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("Username", 150, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("Password", 150, HorizontalAlignment.Left);
            lvCaptain.GridLines = true;
            lvCaptain.FullRowSelect = true;
            lvCaptain.Activation = ItemActivation.TwoClick;
            lvCaptain.View = View.Details;
            lvCaptain.MultiSelect = false;
            IList<Account> data = new List<Account>();
            data = obj.GetCaptain(txtSearch.Text);

            for (int i = 0; i < data.Count(); i++)
            {
                ListViewItem li = new ListViewItem(data[i].Id, 0);
                li.SubItems.Add(data[i].Nim);
                li.SubItems.Add(data[i].Name);
                li.SubItems.Add(data[i].Gender);
                li.SubItems.Add(data[i].Address);
                li.SubItems.Add(data[i].PhoneNumber);
                li.SubItems.Add(data[i].Faculty);
                li.SubItems.Add(data[i].Major);
                li.SubItems.Add(data[i].Batch);
                li.SubItems.Add(data[i].Username);
                li.SubItems.Add(data[i].Password);
                lvCaptain.Items.Add(li);
            }
        }

        private void getData() {
            lvCaptain.Items.Clear();
            lvCaptain.Columns.Clear();
            lvCaptain.Columns.Add("ID", 70, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("NIM", 150, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("Name", 150, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("Gender", 150, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("Address", 150, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("Phone Number", 150, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("Faculty", 150, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("Major", 150, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("Batch", 150, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("Username", 150, HorizontalAlignment.Left);
            lvCaptain.Columns.Add("Password", 150, HorizontalAlignment.Left);
            lvCaptain.GridLines = true;
            lvCaptain.FullRowSelect = true;
            lvCaptain.Activation = ItemActivation.TwoClick;
            lvCaptain.View = View.Details;
            lvCaptain.MultiSelect = false;
            IList<Account> data = new List<Account>();
            data = obj.GetCaptain("");

            for (int i = 0; i < data.Count(); i++ )
            {
                ListViewItem li = new ListViewItem(data[i].Id, 0);
                li.SubItems.Add(data[i].Nim);
                li.SubItems.Add(data[i].Name);
                li.SubItems.Add(data[i].Gender);
                li.SubItems.Add(data[i].Address);
                li.SubItems.Add(data[i].PhoneNumber);
                li.SubItems.Add(data[i].Faculty);
                li.SubItems.Add(data[i].Major);
                li.SubItems.Add(data[i].Batch);
                li.SubItems.Add(data[i].Username);
                li.SubItems.Add(data[i].Password);
                lvCaptain.Items.Add(li);
            }
        }

        private int validasi() {
            int hasil = 0;
            if(txtNim.Text.Length == 0){
                errorProvider1.SetError(txtNim,"Nim can't be null!");
                txtNim.Focus();
                hasil = 1;
            }else if(txtName.Text.Length == 0){
                errorProvider1.Clear();
                errorProvider1.SetError(txtName, "Name can't be null!");
                txtName.Focus();
                hasil = 1;
            }else if(txtAddress.Text.Length == 0){
                errorProvider1.Clear();
                errorProvider1.SetError(txtAddress, "Address can't be null!");
                txtAddress.Focus();
                hasil = 1;
            }else if(txtPhone.Text.Length ==0){
                errorProvider1.Clear();
                errorProvider1.SetError(txtPhone, "Phone Number can't be null!");
                txtAddress.Focus();
                hasil = 1;
            }else if(txtMajor.Text.Length == 0){
                errorProvider1.Clear();
                errorProvider1.SetError(txtMajor, "Major can't be null!");
                txtMajor.Focus();
                hasil = 1;
            }else if(txtUsername.Text.Length == 0){
                errorProvider1.Clear();
                errorProvider1.SetError(txtUsername, "Username can't be null!");
                txtUsername.Focus();
                hasil = 1;
            }
            else if (txtPassword.Text.Length == 0)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPassword, "Password can't be null!");
                txtPassword.Focus();
                hasil = 1;
            }
            else {
                errorProvider1.Clear();
                hasil = 0;
            }
            return hasil;
        }

        private void lvCaptain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtid.Text = lvCaptain.SelectedItems[0].Text;
            txtNim.Text = Convert.ToString(lvCaptain.SelectedItems[0].SubItems[1].Text);
            txtName.Text = Convert.ToString(lvCaptain.SelectedItems[0].SubItems[2].Text);
            cbgender.Text = Convert.ToString(lvCaptain.SelectedItems[0].SubItems[3].Text);
            txtAddress.Text = Convert.ToString(lvCaptain.SelectedItems[0].SubItems[4].Text);
            txtPhone.Text = Convert.ToString(lvCaptain.SelectedItems[0].SubItems[5].Text);
            cbFaculty.Text = Convert.ToString(lvCaptain.SelectedItems[0].SubItems[6].Text);
            txtMajor.Text = Convert.ToString(lvCaptain.SelectedItems[0].SubItems[7].Text);
            cbBatch.Text = Convert.ToString(lvCaptain.SelectedItems[0].SubItems[8].Text);
            txtUsername.Text = Convert.ToString(lvCaptain.SelectedItems[0].SubItems[9].Text);
            txtPassword.Text = Convert.ToString(lvCaptain.SelectedItems[0].SubItems[10].Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(validasi() == 0){
                saveData();
                getData();
            }else{
                validasi();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            searchData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(validasi() == 0){
                updateData();
                getData();    
            }else{
                validasi();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(validasi() == 0){
                deleteData();
                getData();
            }else{
                validasi();
            }
            
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtNim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
