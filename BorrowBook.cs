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
    public partial class BorrowBook : Form
    {
        public BorrowBook()
        {
            InitializeComponent();
        }

        private void BorrowBook_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM BOOKS;";
            DBConnect conn = new DBConnect();
            conn.Dispay(query, dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtIBBook.Text = "";
            txtIBMemberID.Text = "";
            txtIBMemberName.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO ISSUED_BOOKS(Member_ID,Member_Name,Book,Date,Return_Date) VALUES ('" + txtIBMemberID.Text + "','" + txtIBMemberName.Text + "','" + txtIBBook.Text + "','" + dTPIssue.Text + "','" + dTPReturn.Text + "');";
            DBConnect conn = new DBConnect();
            string query2 = "DELETE FROM RETURNED_BOOKS WHERE Member_ID = '" + txtIBMemberID.Text + "';";
            conn.AddData(query);
            conn.delete(query2);
            this.button1_Click(this, null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
         //
            }
            catch (Exception me)
            {
                //MessageBox.Show(me.Message);
            }
        }
    }
}
