using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BurgerManor
{
    public partial class Login : Form
    {
        SqlConnection sqlCon;
        public Login()
        {
            InitializeComponent();
            sqlCon = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=BurgerManor;Integrated Security=True;");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string passWord = txtPass.Text;

            string queryAdmin = "SELECT A_Password, AID FROM ADMINISTRATOR WHERE A_Username = @Username";
            string queryCust = "SELECT C_Password, CID FROM CUSTOMERS WHERE C_Username = @Username";

            SqlCommand commandAdmin = new SqlCommand(queryAdmin, sqlCon);
            commandAdmin.Parameters.AddWithValue("@Username", username);


            SqlCommand commandCust = new SqlCommand(queryCust, sqlCon);
            commandCust.Parameters.AddWithValue("@Username", username);

            try
            {
                sqlCon.Open();

                SqlDataReader readerCust = commandCust.ExecuteReader();
                if (readerCust.Read())
                {
                    object custPassOB = readerCust["C_Password"];
                    object custIdOB = readerCust["CID"];
                    int userId = Convert.ToInt32(custIdOB);
                    string hashedPassword = custPassOB == DBNull.Value ? null : custPassOB.ToString();
                    if (hashedPassword != null && VerifyPassword(passWord, hashedPassword))
                    {
                        // Pass user ID to main dashboard form
                        CustomerDash custDash = new CustomerDash(userId);
                        custDash.ShowDialog();
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password");
                        return;
                    }
                }
                readerCust.Close();

                SqlDataReader readerAdmin = commandAdmin.ExecuteReader();
                if (readerAdmin.Read())
                {
                    object adminPassOB = readerAdmin["A_Password"];
                    object adminIdOB = readerAdmin["AID"];
                    int userId = Convert.ToInt32(adminIdOB);
                    string hashedPassword = adminPassOB == DBNull.Value ? null : adminPassOB.ToString();
                    if (hashedPassword != null && VerifyPassword(passWord, hashedPassword))
                    {
                        AdminDash adminDash = new AdminDash(userId);
                        adminDash.ShowDialog();
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password");
                        return;
                    }
                }


                else
                {
                    MessageBox.Show("User not found");
                }
                readerAdmin.Close();

            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Error: " + sqlEx.Message);
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

        private string HashPassword(string password)
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

        private bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            string hashedEnteredPassword = HashPassword(enteredPassword);
            return string.Equals(hashedEnteredPassword, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
            this.Close();
        }

        private void chkBoxSPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxSPwd.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }
    }
}
