using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library_Management_System
{
    public partial class Admin : Form
    {
        Book book = new Book();
        Author author = new Author();
        Publisher publisher = new Publisher();
        Members members = new Members();
        BorrowBook borrow = new BorrowBook();
        ReturnBook returnBook = new ReturnBook();
        public Admin()
        {
            InitializeComponent();
        }

        private void movepanel(Control btn)
        {
            panel2.Width = btn.Width;
            panel2.Left = btn.Left;
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            movepanel(btnBook);
            btnReturn.Visible = false;
            btnBorrow.Visible = false;
            book.ShowDialog();
        }

        private void btnTransact_Click(object sender, EventArgs e)
        {
            movepanel(btnTransact);
            btnReturn.Visible = true;
            btnBorrow.Visible = true;
        }

        private void btnAuthors_Click(object sender, EventArgs e)
        {
            movepanel(btnAuthors);
            btnReturn.Visible = false;
            btnBorrow.Visible = false;
            author.ShowDialog();
        }

        private void btnPublishers_Click(object sender, EventArgs e)
        {
            movepanel(btnPublishers);
            btnReturn.Visible = false;
            btnBorrow.Visible = false;
            publisher.ShowDialog();
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            movepanel(btnMembers);
            btnReturn.Visible = false;
            btnBorrow.Visible = false;
            members.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            movepanel(btnLogout);
            btnReturn.Visible = false;
            btnBorrow.Visible = false;
            this.Hide();

        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            borrow.ShowDialog();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            returnBook.ShowDialog();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
    }
    public class DBConnect
    {
        string myConString = "server=localhost;uid=root;pwd= ;database=LibraryDB";

        public void AddData(string query)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(myConString);
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader myReader;
                conn.Open();
                myReader = command.ExecuteReader();
                MessageBox.Show("Saves data to the Database.", "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader.Read())
                {

                }
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void delete(string query)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(myConString);
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader myReader;
                conn.Open();
                myReader = command.ExecuteReader();
                MessageBox.Show("Delete data from the Database.", "Delete Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader.Read())
                {

                }
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        public void Dispay(string query, DataGridView dg)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(myConString);
                conn.Open();
                MySqlCommand comand = new MySqlCommand(query, conn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = comand;
                DataTable dbdataset = new DataTable();
                da.Fill(dbdataset);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dbdataset;
                dg.DataSource = bsource;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
        public void update(string query)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(myConString);
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader myReader;
                conn.Open();
                myReader = command.ExecuteReader();
                MessageBox.Show("Update data.", "Data Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (myReader.Read())
                {

                }
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        public DataSet getData(string query,DataGridView dg)
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlConnection conn = new MySqlConnection(myConString);
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                conn.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }
    }
}
