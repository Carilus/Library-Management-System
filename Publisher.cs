using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Publisher : Form
    {
        public Publisher()
        {
            InitializeComponent();
        }

        private void Publisher_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM PUBLISHER;";
            DBConnect conn = new DBConnect();
            conn.Dispay(query, dataGridPublish);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPAddress.Text = "";
            txtPName.Text = "";
            txtPPhone.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO PUBLISHER(Name,Address,Phone) VALUES ('" + txtPName.Text + "','" + txtPAddress.Text + "','" + txtPPhone.Text + "');";
            DBConnect conn = new DBConnect();
            conn.AddData(query);

            string query1 = "SELECT * FROM PUBLISHER;";
            conn.Dispay(query1, dataGridPublish);
            this.btnCancel_Click(this, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM PUBLISHER WHERE Name = '" + txtPName.Text + "';";
            DBConnect conn = new DBConnect();
            conn.delete(query);
            string query1 = "SELECT * FROM PUBLISHER;";
            conn.Dispay(query1, dataGridPublish);
            this.btnCancel_Click(this, null);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DBConnect con = new DBConnect();
            string query = "UPDATE PUBLISHER SET Address = '" + txtPAddress.Text + "',Phone = '" + txtPPhone.Text + "' WHERE Name ='" + txtPName.Text + "';";
            if (txtPAddress.Text != null && txtPName.Text != null && txtPPhone.Text != null)
            {
                con.update(query);
            }
            else
            {
                MessageBox.Show("Operation cannot be completed, check your values", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string query1 = "SELECT * FROM PUBLISHER;";
            con.Dispay(query1, dataGridPublish);
            this.btnCancel_Click(this, null);
        }

        private void txtPublisher_TextChanged(object sender, EventArgs e)
        {
            string query = "select * from PUBLISHER where Name like '" + txtPublisher.Text + "%';";
            DBConnect con = new DBConnect();
            con.Dispay(query, dataGridPublish);
        }

        private void dataGridPublish_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                //MessageBox.Show(dataGridMember.SelectedRows[0].Cells[1].Value.ToString());
                string query = "select * from PUBLISHER where Name = '" + dataGridPublish.SelectedRows[0].Cells[0].Value.ToString() + "';";
                DBConnect con = new DBConnect();
                DataSet ds = con.getData(query, dataGridPublish);
                txtPName.Text = ds.Tables[0].Rows[0][0].ToString();
                txtPAddress.Text = ds.Tables[0].Rows[0][1].ToString();
                txtPPhone.Text = ds.Tables[0].Rows[0][2].ToString();

            }
            catch (Exception me)
            {
                MessageBox.Show(me.Message);
            }
        }
    }
}
