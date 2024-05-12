using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BurgerManor
{
    public partial class Register : Form
    {
        SqlConnection sqlCon;

        public Register()
        {
            InitializeComponent();
            sqlCon = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=BurgerManor;Integrated Security=True;");

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {


            string email = txtEmail.Text;
            string username = txtUser.Text;
            string password = txtPass.Text;
            string confPassword = txtConfPass.Text;



            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter a username.", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confPassword)
            {
                MessageBox.Show("Passwords do not match", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter a password.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string encryptPass = EncryptPassword(password);

            string query;
            string message;

            if (rbtnAdmin.Checked)
            {
                if (IsAdminUsernameTaken(username))
                {
                    MessageBox.Show("Username is taken by another admin");
                    return;
                }

                query = "INSERT INTO ADMINISTRATOR ( A_Email, A_Username, A_Password) VALUES (@Email, @Username, @Password);";
                message = "Admin registration successful";
            }
            else if (rbtnCust.Checked)
            {
                if (IsCustomerUsernameTaken(username))
                {
                    MessageBox.Show("Username is taken by another customer");
                    return;
                }

                query = "INSERT INTO CUSTOMERS ( C_Email, C_Username, C_Password) VALUES (@Email, @Username, @Password);";
                message = "Customer registration successful";
            }
            else
            {
                MessageBox.Show("Please select user type");
                return;
            }

            try
            {
                sqlCon.Open();
                SqlCommand comm = new SqlCommand(query, sqlCon);

                comm.Parameters.AddWithValue("@Email", email);
                comm.Parameters.AddWithValue("@Username", username);
                comm.Parameters.AddWithValue("@Password", encryptPass);
                comm.ExecuteNonQuery();

                MessageBox.Show(message);
                txtEmail.Clear();
                txtUser.Clear();
                txtPass.Clear();
                txtConfPass.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private bool IsAdminUsernameTaken(string username)
        {
            bool isUATaken = false;

            string query = "SELECT COUNT(*) FROM ADMINISTRATOR WHERE A_Username = @Username";
            sqlCon.Open();
            SqlCommand comm = new SqlCommand(query, sqlCon);

            comm.Parameters.AddWithValue("@Username", username);

            try
            {
                int count = (int)comm.ExecuteScalar();
                if (count > 0)
                {
                    isUATaken = true;
                }
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                sqlCon.Close();
            }

            return isUATaken;
        }

        private bool IsCustomerUsernameTaken(string username)
        {
            bool isUCTaken = false;

            string query = "SELECT COUNT(*) FROM ADMINISTRATOR WHERE C_Username = @Username";
            sqlCon.Open();
            SqlCommand comm = new SqlCommand(query, sqlCon);

            comm.Parameters.AddWithValue("@Username", username);

            try
            {
                int count = (int)comm.ExecuteScalar();
                if (count > 0)
                {
                    isUCTaken = true;
                }
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                sqlCon.Close();
            }


            return isUCTaken;
        }

        private void chkBoxSPwd_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
            txtConfPass.UseSystemPasswordChar = false;
        }
    }
}
