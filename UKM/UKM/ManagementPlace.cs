using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UKM.ServiceAdmin;

namespace UKM
{
    public partial class ManagementPlace : Form
    {
        ServiceAdmin.Service1Client obj = new ServiceAdmin.Service1Client();
        public ManagementPlace()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu m = new Menu();
            m.Show();
        }

        private void ManagementPlace_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void getData() {
            lvPlace.Items.Clear();
            lvPlace.Columns.Clear();
            lvPlace.Columns.Add("ID", 70, HorizontalAlignment.Left);
            lvPlace.Columns.Add("Place Name", 150, HorizontalAlignment.Left);
            lvPlace.GridLines = true;
            lvPlace.FullRowSelect = true;
            lvPlace.Activation = ItemActivation.TwoClick;
            lvPlace.View = View.Details;
            lvPlace.MultiSelect = false;
            IList<Place> data = new List<Place>();
            data = obj.GetPlace("");

            for (int i = 0; i < data.Count(); i++)
            {
                ListViewItem li = new ListViewItem(data[i].Id, 0);
                li.SubItems.Add(data[i].Name);
                lvPlace.Items.Add(li);
            }
        }

        private void lvPlace_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtID.Text = lvPlace.SelectedItems[0].Text;
            txtPlace.Text = Convert.ToString(lvPlace.SelectedItems[0].SubItems[1].Text);
        }

        private void deleteData() {
            int result = obj.doDeletePlace(txtID.Text);
            if (result > 0)
            {
                MessageBox.Show("Delete Success!");
            }
            else
            {
                MessageBox.Show("Delete Fail");
            }
       }

        private void insertData() {
            Place acc = new Place();
            acc.Name = txtPlace.Text;
            int result = obj.doInsertPlace(acc);
            if (result > 0)
            {
                MessageBox.Show("Save Success!");
            }
            else
            {
                MessageBox.Show("Save Fail!");
            }
        }

        private void updateData() {
            Place acc = new Place();
            acc.Id = txtID.Text;
            acc.Name = txtPlace.Text;

            int result = obj.doUpdatePlace(acc);
            if (result > 0)
            {
                MessageBox.Show("Update Success!");
            }
            else
            {
                MessageBox.Show("Update Fail");
            }
        }

        private void searchData() {
            lvPlace.Items.Clear();
            lvPlace.Columns.Clear();
            lvPlace.Columns.Add("ID", 70, HorizontalAlignment.Left);
            lvPlace.Columns.Add("Place Name", 150, HorizontalAlignment.Left);
            lvPlace.GridLines = true;
            lvPlace.FullRowSelect = true;
            lvPlace.Activation = ItemActivation.TwoClick;
            lvPlace.View = View.Details;
            lvPlace.MultiSelect = false;
            IList<Place> data = new List<Place>();
            data = obj.GetPlace(txtSearch.Text);

            for (int i = 0; i < data.Count(); i++)
            {
                ListViewItem li = new ListViewItem(data[i].Id, 0);
                li.SubItems.Add(data[i].Name);
                lvPlace.Items.Add(li);
            }
        }

        private int validasi() {
            int hasil = 0;
            if (txtPlace.Text.Length == 0)
            {
                errorProvider1.SetError(txtPlace, "Place can't be null!");
                txtPlace.Focus();
                hasil = 1;
            }
            else {
                errorProvider1.Clear();
                hasil = 0;
            }
            return hasil;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(validasi() == 0){
                insertData();
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

        private void button5_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset() {
            txtID.Text = "";
            txtPlace.Text = "";
        }
    }
}
