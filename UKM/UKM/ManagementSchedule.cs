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
    public partial class ManagementSchedule : Form
    {
        ServiceAdmin.Service1Client obj = new ServiceAdmin.Service1Client();
        public ManagementSchedule()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu m = new Menu();
            m.Show();
        }

        private void ManagementSchedule_Load(object sender, EventArgs e)
        {
            getPlace();
        }

        private void getPlace() {
            IList<Place> data = new List<Place>();
            data = obj.GetPlace("");

            for (int i = 0; i < data.Count(); i++)
            {
                cbPlace.Items.Add(data[i].Name);
            }
        }

        private void insertData() {
            Schedule acc = new Schedule();
            acc.Day = cbDay.SelectedItem.ToString();
            acc.Starttime = txtStart.Text;
            acc.Endtime = txtEnd.Text;
            string conv = obj.convertplace(cbPlace.SelectedItem.ToString());
            acc.Idplace = conv;

            int result = obj.doInsertSchedule(acc);
            if(result == 1){
                MessageBox.Show("save success!");
            }else if(result == 2){
                MessageBox.Show("data already available");
            }else{
                MessageBox.Show("save fail");
            }
        }

        private void deleteData() {
            int result = obj.doDeleteSchedule(txtID.Text);
            if (result > 0)
            {
                MessageBox.Show("Delete success");
            }
            else {
                MessageBox.Show("Delete fail");
            }
        }

        private void updateData() {
            Schedule acc = new Schedule();
            acc.Day = cbDay.SelectedItem.ToString();
            acc.Starttime = txtStart.Text;
            acc.Endtime = txtEnd.Text;
            string conv = obj.convertplace(cbPlace.SelectedItem.ToString());
            acc.Idplace = conv;
            acc.Id = txtID.Text;

            int result = obj.doUpdateSchedule(acc);
            if (result == 1)
            {
                MessageBox.Show("update success!");
            }
            else
            {
                MessageBox.Show("update fail");
            }
        }

        private void searchData() {
            lvSchedule.Items.Clear();
            lvSchedule.Columns.Clear();
            lvSchedule.Columns.Add("ID", 70, HorizontalAlignment.Left);
            lvSchedule.Columns.Add("Day", 150, HorizontalAlignment.Left);
            lvSchedule.Columns.Add("Start Time", 150, HorizontalAlignment.Left);
            lvSchedule.Columns.Add("End Time", 150, HorizontalAlignment.Left);
            lvSchedule.Columns.Add("ID Place", 150, HorizontalAlignment.Left);
            lvSchedule.GridLines = true;
            lvSchedule.FullRowSelect = true;
            lvSchedule.Activation = ItemActivation.TwoClick;
            lvSchedule.View = View.Details;
            lvSchedule.MultiSelect = false;
            IList<Schedule> data = new List<Schedule>();
            data = obj.GetSchedule(txtSearch.Text);

            for (int i = 0; i < data.Count(); i++)
            {
                ListViewItem li = new ListViewItem(data[i].Id, 0);
                li.SubItems.Add(data[i].Day);
                li.SubItems.Add(data[i].Starttime);
                li.SubItems.Add(data[i].Endtime);
                li.SubItems.Add(data[i].Idplace);
                lvSchedule.Items.Add(li);
            }
        }

        private void getData() {
            lvSchedule.Items.Clear();
            lvSchedule.Columns.Clear();
            lvSchedule.Columns.Add("ID", 70, HorizontalAlignment.Left);
            lvSchedule.Columns.Add("Day", 150, HorizontalAlignment.Left);
            lvSchedule.Columns.Add("Start Time", 150, HorizontalAlignment.Left);
            lvSchedule.Columns.Add("End Time", 150, HorizontalAlignment.Left);
            lvSchedule.Columns.Add("ID Place", 150, HorizontalAlignment.Left);
            lvSchedule.GridLines = true;
            lvSchedule.FullRowSelect = true;
            lvSchedule.Activation = ItemActivation.TwoClick;
            lvSchedule.View = View.Details;
            lvSchedule.MultiSelect = false;
            IList<Schedule> data = new List<Schedule>();
            data = obj.GetSchedule("");

            for (int i = 0; i < data.Count(); i++)
            {
                ListViewItem li = new ListViewItem(data[i].Id, 0);
                li.SubItems.Add(data[i].Day);
                li.SubItems.Add(data[i].Starttime);
                li.SubItems.Add(data[i].Endtime);
                li.SubItems.Add(data[i].Idplace);
                lvSchedule.Items.Add(li);
            }
        }

        private int validasi() {
            int hasil = 0;
            if (txtStart.Text.Length == 0)
            {
                errorProvider1.SetError(txtStart, "Start can't be null!");
                hasil = 1;
                txtStart.Focus();
            }
            else if(txtEnd.Text.Length == 0){
                errorProvider1.Clear();
                errorProvider1.SetError(txtEnd,"End can't be null!");
                hasil = 1;
                txtEnd.Focus();
            }else{
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
            txtStart.Text = "";
            txtEnd.Text = "";
            txtID.Text = "";

        }
    }
}
