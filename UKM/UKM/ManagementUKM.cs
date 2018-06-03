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
    public partial class ManagementUKM : Form
    {
        ServiceAdmin.Service1Client obj = new ServiceAdmin.Service1Client();
        public ManagementUKM()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu m = new Menu();
            m.Show();
        }

        private void ManagementUKM_Load(object sender, EventArgs e)
        {
            getDataCoach();
            getData();
        }

        private void getDataCoach() {
            IList<Coach> data = new List<Coach>();
            data = obj.GetCoach("");
            for (int i = 0; i < data.Count(); i++)
            {
                cbCoach.Items.Add(data[i].Name);
            }
        }

        private void deleteData() {
            int result = obj.doDeleteUKM(txtID.Text);
            if (result > 0)
            {
                MessageBox.Show("Delete Success!");
            }
            else {
                MessageBox.Show("Delete Fail");
            }
        }

        private void insertData() {
            cUkm acc = new cUkm();
            acc.Ukmname = txtUKM.Text;
            acc.Desc = txtDesc.Text;
            string Ccoach = obj.convertcoach(cbCoach.SelectedItem.ToString());
            acc.Idcoach = Ccoach;

            int result = obj.doInsertUKM(acc);
            if (result > 0)
            {
                MessageBox.Show("Save Success!");
            }
            else {
                MessageBox.Show("Save Fail!");
            }
        }

        private void updateDate() {
            cUkm acc = new cUkm();
            acc.Id = txtID.Text;
            acc.Ukmname = txtUKM.Text;
            acc.Desc = txtDesc.Text;
            string Ccoach = obj.convertcoach(cbCoach.SelectedItem.ToString());
            acc.Idcoach = Ccoach;

                int result = obj.doUpdateUKM(acc);
            if (result > 0)
            {
                MessageBox.Show("Update Success!");
            }
            else {
                MessageBox.Show("Update Fail");
            }
        }

        private void searchData() {
            lvUKM.Items.Clear();
            lvUKM.Columns.Clear();
            lvUKM.Columns.Add("ID", 70, HorizontalAlignment.Left);
            lvUKM.Columns.Add("Name UKM", 150, HorizontalAlignment.Left);
            lvUKM.Columns.Add("Description", 150, HorizontalAlignment.Left);
            lvUKM.Columns.Add("ID Coach", 150, HorizontalAlignment.Left);
            lvUKM.GridLines = true;
            lvUKM.FullRowSelect = true;
            lvUKM.Activation = ItemActivation.TwoClick;
            lvUKM.View = View.Details;
            lvUKM.MultiSelect = false;
            IList<cUkm> data = new List<cUkm>();
            data = obj.GetUKM(txtSearch.Text);

            for (int i = 0; i < data.Count(); i++)
            {
                ListViewItem li = new ListViewItem(data[i].Id, 0);
                li.SubItems.Add(data[i].Ukmname);
                li.SubItems.Add(data[i].Desc);
                li.SubItems.Add(data[i].Idcoach);
                lvUKM.Items.Add(li);
            }
        }

        private void getData(){
            lvUKM.Items.Clear();
            lvUKM.Columns.Clear();
            lvUKM.Columns.Add("ID", 70, HorizontalAlignment.Left);
            lvUKM.Columns.Add("Name UKM", 150, HorizontalAlignment.Left);
            lvUKM.Columns.Add("Description", 150, HorizontalAlignment.Left);
            lvUKM.Columns.Add("ID Coach", 150, HorizontalAlignment.Left);
            lvUKM.GridLines = true;
            lvUKM.FullRowSelect = true;
            lvUKM.Activation = ItemActivation.TwoClick;
            lvUKM.View = View.Details;
            lvUKM.MultiSelect = false;
            IList<cUkm> data = new List<cUkm>();
            data = obj.GetUKM("");

            for (int i = 0; i < data.Count(); i++)
            {
                ListViewItem li = new ListViewItem(data[i].Id, 0);
                li.SubItems.Add(data[i].Ukmname);
                li.SubItems.Add(data[i].Desc);
                li.SubItems.Add(data[i].Idcoach);
                lvUKM.Items.Add(li);
            }
        }

        private int validasi() {
            int hasil = 0;
                if(txtUKM.Text.Length == 0){
                    errorProvider1.SetError(txtUKM,"UKM can't be null!");
                    hasil = 1;
                    txtUKM.Focus();
                }
                else if (txtDesc.Text.Length == 0)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtDesc, "Desc can't be null!");
                    hasil = 1;
                    txtDesc.Focus();
                }
                else {
                    hasil = 0;
                    errorProvider1.Clear();
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

        private void lvUKM_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtID.Text = lvUKM.SelectedItems[0].Text;
            txtUKM.Text = Convert.ToString(lvUKM.SelectedItems[0].SubItems[1].Text);
            txtDesc.Text = Convert.ToString(lvUKM.SelectedItems[0].SubItems[2].Text);
            cbCoach.Text = Convert.ToString(lvUKM.SelectedItems[0].SubItems[3].Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            searchData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(validasi() == 0){
                updateDate();
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
            txtDesc.Text = "";
            txtID.Text = "";
            txtUKM.Text = "";
        }
    }
}
