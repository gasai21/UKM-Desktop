using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UKM.ServiceCoach;

namespace UKM
{
    public partial class ManagementCoach : Form
    {
        ServiceCoach.Service1Client obj = new ServiceCoach.Service1Client();
        public ManagementCoach()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu m = new Menu();
            m.Show();
        }

        private void ManagementCoach_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void updateData() {
            Coach acc = new Coach();
            acc.Id = txtID.Text;
            acc.Name = txtname.Text;
            acc.Gender = cbGender.SelectedItem.ToString();
            acc.Address = txtaddress.Text;
            acc.Phone = txtPhone.Text;

            int result = obj.doUpdateCoach(acc);
            if (result > 0)
            {
                MessageBox.Show("Update Success");
            }
            else {
                MessageBox.Show("Update Fail");
            }
        }

        private void searchData() {
            lvCoach.Items.Clear();
            lvCoach.Columns.Clear();
            lvCoach.Columns.Add("ID", 70, HorizontalAlignment.Left);
            lvCoach.Columns.Add("Name", 150, HorizontalAlignment.Left);
            lvCoach.Columns.Add("Gender", 150, HorizontalAlignment.Left);
            lvCoach.Columns.Add("Address", 150, HorizontalAlignment.Left);
            lvCoach.Columns.Add("Phone Number", 150, HorizontalAlignment.Left);
            lvCoach.GridLines = true;
            lvCoach.FullRowSelect = true;
            lvCoach.Activation = ItemActivation.TwoClick;
            lvCoach.View = View.Details;
            lvCoach.MultiSelect = false;
            IList<Coach> data = new List<Coach>();
            data = obj.GetCoach(txtSearch.Text);

            for (int i = 0; i < data.Count(); i++)
            {
                ListViewItem li = new ListViewItem(data[i].Id, 0);
                li.SubItems.Add(data[i].Name);
                li.SubItems.Add(data[i].Gender);
                li.SubItems.Add(data[i].Address);
                li.SubItems.Add(data[i].Phone);
                lvCoach.Items.Add(li);
            }
        }

        private int validasi() {
            int hasil = 0;
            if(txtname.Text.Length == 0){
                errorProvider1.SetError(txtname,"Name Can't be null!");
                txtname.Focus();
                hasil = 1;
            }else if(txtaddress.Text.Length == 0){
                errorProvider1.Clear();
                errorProvider1.SetError(txtaddress,"Address can't be null!");
                hasil = 1;
                txtaddress.Focus();
            }
            else if (txtPhone.Text.Length == 0)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPhone, "Phone Number Can't be null!");
                hasil = 1;
                txtPhone.Focus();
            }
            else {
                errorProvider1.Clear();
                hasil = 0;
            }
            return hasil;
        }

        private void getdata() {
            lvCoach.Items.Clear();
            lvCoach.Columns.Clear();
            lvCoach.Columns.Add("ID", 70, HorizontalAlignment.Left);
            lvCoach.Columns.Add("Name", 150, HorizontalAlignment.Left);
            lvCoach.Columns.Add("Gender", 150, HorizontalAlignment.Left);
            lvCoach.Columns.Add("Address", 150, HorizontalAlignment.Left);
            lvCoach.Columns.Add("Phone Number", 150, HorizontalAlignment.Left);
            lvCoach.GridLines = true;
            lvCoach.FullRowSelect = true;
            lvCoach.Activation = ItemActivation.TwoClick;
            lvCoach.View = View.Details;
            lvCoach.MultiSelect = false;
            IList<Coach> data = new List<Coach>();
            data = obj.GetCoach("");

            for (int i = 0; i < data.Count(); i++)
            {
                ListViewItem li = new ListViewItem(data[i].Id, 0);
                li.SubItems.Add(data[i].Name);
                li.SubItems.Add(data[i].Gender);
                li.SubItems.Add(data[i].Address);
                li.SubItems.Add(data[i].Phone);
                lvCoach.Items.Add(li);
            }
       }
       
      private void saveData() {
          Coach acc = new Coach();
          acc.Name = txtname.Text;
          acc.Gender = cbGender.SelectedItem.ToString();
          acc.Address = txtaddress.Text;
          acc.Phone = txtPhone.Text;

          int result = obj.doInsertCoach(acc);
          if (result > 0)
          {
              MessageBox.Show("Save Success");
          }
          else {
              MessageBox.Show("Save Fail");
          }
      }

      private void button1_Click(object sender, EventArgs e)
      {
          if(validasi() == 0){
            saveData();
            getdata();
          }else{
              validasi();
          }
          
      }

      private void deleteData() {
          int result = obj.doDeleteCoach(txtID.Text);
          if (result > 0)
          {
              MessageBox.Show("Delete Success");
          }
          else {
              MessageBox.Show("Delete Fail");
          }
      }

      private void reset() {
          txtID.Text = "";
          txtname.Text = "";
          txtPhone.Text = "";
          txtaddress.Text = "";
          cbGender.Text = "Male";
          getdata();
      }

      private void lvCoach_MouseDoubleClick(object sender, MouseEventArgs e)
      {
          txtID.Text = lvCoach.SelectedItems[0].Text;
          txtname.Text = Convert.ToString(lvCoach.SelectedItems[0].SubItems[1].Text);
          cbGender.Text = Convert.ToString(lvCoach.SelectedItems[0].SubItems[2].Text);
          txtaddress.Text = Convert.ToString(lvCoach.SelectedItems[0].SubItems[3].Text);
          txtPhone.Text = Convert.ToString(lvCoach.SelectedItems[0].SubItems[4].Text);
      }

      private void button4_Click(object sender, EventArgs e)
      {
          if(validasi() == 0){
              deleteData();
              getdata();
          }else{
            validasi();
          }
          
      }

      private void button2_Click(object sender, EventArgs e)
      {
          if (validasi() == 0)
          {
              updateData();
              getdata();
          }
          else {
              validasi();
          }
      }

      private void button3_Click(object sender, EventArgs e)
      {
          searchData();
      }

      private void button5_Click(object sender, EventArgs e)
      {
          reset();
      }

      private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
      {
          if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
          {
              e.Handled = true;
          }
      }
    }
}
