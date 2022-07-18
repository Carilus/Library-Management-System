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
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            string query1 = "SELECT * FROM ISSUED_BOOKS;";
            DBConnect conn = new DBConnect();
            conn.Dispay(query1, dataGridRBook);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO RETURNED_BOOKS(Member_Name,Member_ID,Book,Return_Date,Elapse,Fine) VALUES ('" + txtRBMember.Text + "','" + txtRBMemberID.Text + "','" + txtRBBook.Text + "','" + dTPReturnDate.Text + "','" + txtElapse.Text + "','" + txtRBFine.Text + "');";
            DBConnect conn = new DBConnect();
            conn.AddData(query);
            string query2 = "DELETE FROM ISSUED_BOOKS WHERE Member_ID = '" + txtRBMemberID.Text + "';";
            conn.delete(query2);

            string query1 = "SELECT * FROM ISSUED_BOOKS;";
            conn.Dispay(query1, dataGridRBook);
            this.btnCancel_Click(this, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtElapse.Clear();
            txtRBBook.Clear();
            txtRBFine.Clear();
            txtRBMember.Clear();
            txtRBMemberID.Clear();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridRBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
