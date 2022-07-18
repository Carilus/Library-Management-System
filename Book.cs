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
    public partial class Book : Form
    {
        public Book()
        {
            InitializeComponent();
        }

        private void Book_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM BOOKS;";
            DBConnect conn = new DBConnect();
            conn.Dispay(query, dataGridBook);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtBCateg.Text = "";
            txtBookID.Text = "";
            txtBPublisher.Text = "";
            txtBEdition.Text = "";
            txtBName.Text = "";
            txtBNofPages.Text = "";
            txtBAuthor.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO BOOKS(Name,Book_ID,Category,Author,Publisher,Edition,Number_Of_Pages) VALUES ('" + txtBName.Text + "','" + txtBookID.Text + "','" + txtBCateg.Text + "','" + txtBAuthor.Text + "','" + txtBPublisher.Text + "','" + txtBEdition.Text + "','" + txtBNofPages.Text + "');";
            DBConnect conn = new DBConnect();
            conn.AddData(query);

            string query1 = "SELECT * FROM BOOKS;";
            conn.Dispay(query1, dataGridBook);
            this.btnCancel_Click(this, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM BOOKS WHERE BOOK_ID = '" + txtBookID.Text + "';";
            DBConnect conn = new DBConnect();
            conn.delete(query);

            string query1 = "SELECT * FROM BOOKS;";
            conn.Dispay(query1, dataGridBook);
            this.btnCancel_Click(this, null);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DBConnect con = new DBConnect();
            string query = "UPDATE BOOKS SET Name = '" + txtBName.Text + "',Category = '" + txtBCateg.Text + "',Author = '" + txtBAuthor.Text + "',Publisher= '" + txtBPublisher.Text + "' WHERE Book_ID ='" + txtBookID.Text + "';";
            if (txtBookID.Text != null && txtBName.Text != null && txtBEdition != null && txtBNofPages != null && txtBPublisher != null)
            {
                con.update(query);
            }
            else
            {
                MessageBox.Show("Operation cannot be completed, check your values", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string query1 = "SELECT * FROM BOOKS;";
            con.Dispay(query1, dataGridBook);
            this.btnCancel_Click(this, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBooks_TextChanged(object sender, EventArgs e)
        {
            string query = "select * from BOOKS where Name like '" + textBooks.Text + "%';";
            DBConnect con = new DBConnect();
            con.Dispay(query, dataGridBook);
        }

        private void dataGridBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //MessageBox.Show(dataGridMember.SelectedRows[0].Cells[1].Value.ToString());
                string query = "select * from BOOKS where Book_ID = '" + dataGridBook.SelectedRows[0].Cells[1].Value.ToString() + "';";
                DBConnect con = new DBConnect();
                DataSet ds = con.getData(query, dataGridBook);
                txtBName.Text = ds.Tables[0].Rows[0][0].ToString();
                txtBookID.Text = ds.Tables[0].Rows[0][1].ToString();
                txtBCateg.Text = ds.Tables[0].Rows[0][2].ToString();
                txtBAuthor.Text = ds.Tables[0].Rows[0][3].ToString();
                txtBPublisher.Text= ds.Tables[0].Rows[0][4].ToString();
                txtBEdition.Text = ds.Tables[0].Rows[0][5].ToString();
                txtBNofPages.Text = ds.Tables[0].Rows[0][6].ToString();

            }
            catch (Exception me)
            {
                MessageBox.Show(me.Message);
            }
        }
    }
}
