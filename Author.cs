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
    public partial class Author : Form
    {
        public Author()
        {
            InitializeComponent();
        }

        private void Author_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM AUTHOR;";
            DBConnect conn = new DBConnect();
            conn.Dispay(query, dataGridAuthor);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtAAdress.Text = "";
            txtAName.Text = "";
            txtAphone.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM AUTHOR WHERE Name = '" + txtAName.Text + "';";
            DBConnect conn = new DBConnect();
            conn.delete(query);
            string query1 = "SELECT * FROM AUTHOR;";
            conn.Dispay(query1, dataGridAuthor);
            this.btnCancel_Click(this, null);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DBConnect con = new DBConnect();
            string query = "UPDATE AUTHOR SET Address = '" + txtAAdress.Text + "',Phone = '" + txtAphone.Text + "' WHERE Name ='" + txtAName.Text + "';";
            if (txtAName.Text != null && txtAphone.Text != null && txtAAdress.Text != null)
            {
                con.update(query);
            }
            else
            {
                MessageBox.Show("Operation cannot be completed, check your values", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string query1 = "SELECT * FROM AUTHOR;";
            con.Dispay(query1, dataGridAuthor);
            this.btnCancel_Click(this, null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DBConnect conn = new DBConnect();
            string query = "INSERT INTO AUTHOR(Name,Address,Phone) VALUES ('" + txtAName.Text + "','" + txtAAdress.Text + "','" + txtAphone.Text + "');";
            conn.AddData(query);
            string query1 = "SELECT * FROM AUTHOR;";
            conn.Dispay(query1, dataGridAuthor);
            this.btnCancel_Click(this, null);
        }

        private void textAuthor_TextChanged(object sender, EventArgs e)
        {
            string query = "select * from AUTHOR where Name like '" + textAuthor.Text + "%';";
            DBConnect con = new DBConnect();
            con.Dispay(query, dataGridAuthor);
        }

        private void dataGridAuthor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //MessageBox.Show(dataGridMember.SelectedRows[0].Cells[1].Value.ToString());
                string query = "select * from AUTHOR where Name = '" + dataGridAuthor.SelectedRows[0].Cells[0].Value.ToString() + "';";
                DBConnect con = new DBConnect();
                DataSet ds = con.getData(query, dataGridAuthor);
                txtAName.Text = ds.Tables[0].Rows[0][0].ToString();
                txtAAdress.Text = ds.Tables[0].Rows[0][1].ToString();
                txtAphone.Text = ds.Tables[0].Rows[0][2].ToString();
              
            }
            catch (Exception me)
            {
                MessageBox.Show(me.Message);
            }

        }
    }
}
