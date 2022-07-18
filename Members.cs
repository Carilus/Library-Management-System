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
    public partial class Members : Form
    {
        public Members()
        {
            InitializeComponent();
        }

        private void Members_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM MEMBERS;";
            DBConnect conn = new DBConnect();
            conn.Dispay(query, dataGridMember);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DBConnect con = new DBConnect();
            string query = "UPDATE MEMBERS SET Name = '" + txtMName.Text + "',Address = '" + txtMAddress.Text + "',Phone = '" + txtMPhone.Text + "' WHERE Member_ID ='" + txtMID.Text + "';";
            if (txtMID.Text != null && txtMName.Text != null && txtMAddress.Text != null && txtMPhone.Text != null)
            {
                con.update(query);
            }
            else
            {
                MessageBox.Show("Operation cannot be completed, check your values", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            string query3 = "SELECT * FROM MEMBERS;";

            con.Dispay(query3, dataGridMember);
            this.btnCancel_Click(this, null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO MEMBERS(Name,Member_ID,Address,Phone) VALUES ('" + txtMName.Text + "','" + txtMID.Text + "','" + txtMAddress.Text + "','" + txtMPhone.Text + "');";
            DBConnect conn = new DBConnect();
            conn.AddData(query);

            string query2 = "SELECT * FROM MEMBERS;";

            conn.Dispay(query2, dataGridMember);
            this.btnCancel_Click(this, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtMAddress.Text = "";
            txtMID.Text = "";
            txtMName.Text = "";
            txtMPhone.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM MEMBERS WHERE Member_ID = '" + txtMID.Text + "';";
            DBConnect conn = new DBConnect();
            conn.delete(query);
            string query1 = "SELECT * FROM MEMBERS;";
            conn.Dispay(query1, dataGridMember);
            btnCancel_Click(this, null);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = "select * from MEMBERS where Name like '" + textBox1.Text + "%';";
            DBConnect con = new DBConnect();
            con.Dispay(query, dataGridMember);
        }

        private void dataGridMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //MessageBox.Show(dataGridMember.SelectedRows[0].Cells[1].Value.ToString());
                string query = "select * from MEMBERS where Member_ID = '" + dataGridMember.SelectedRows[0].Cells[1].Value.ToString() + "';";
                DBConnect con = new DBConnect();
                DataSet ds = con.getData(query, dataGridMember);
                txtMName.Text = ds.Tables[0].Rows[0][0].ToString();
                txtMID.Text = ds.Tables[0].Rows[0][1].ToString();
                txtMAddress.Text = ds.Tables[0].Rows[0][2].ToString();
                txtMPhone.Text = ds.Tables[0].Rows[0][3].ToString();
            }
            catch(Exception me)
            {
                MessageBox.Show(me.Message);
            }

        }
    }
}
