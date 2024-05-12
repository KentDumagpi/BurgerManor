using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BurgerManor
{
    public partial class AdminDash : Form
    {
        static bool sidebarExpand;
        SqlConnection sqlCon;
        private int userId;
        public AdminDash(int userId)
        {
            InitializeComponent();
            sqlCon = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=BurgerManor;Integrated Security=True;");
            this.userId = userId;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            panelAddUsers.Visible = false;
            panelAddUsers.Enabled = false;
            panelAddProd.Visible = false;
            panelAddProd.Enabled = false;
            panelView.Enabled = false;
            panelView.Visible = false;
            panelProd.Visible = false;
            panelProd.Enabled = false;
            panelOrders.Enabled = false;
            panelOrders.Visible = false;
            lblAdmin.Visible = true;
            logoPic.Visible = true;
            panelEditUser.Visible = false;
            panelEditUser.Enabled = false;
            sidebar.BringToFront();
            searchUsers.BringToFront();
            clearSBarUsers.BringToFront();
            sidebarTimer.Start();
            if (sidebarExpand)
            {
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            lblAdmin.Visible = false;
            logoPic.Visible = false;
            panelView.Visible = true;
            panelView.Enabled = true;
            panelOrders.Visible = false;
            panelOrders.Enabled = false;
            panelProd.Enabled = false;
            panelProd.Visible = false;
            panelAddUsers.Visible = false;
            panelAddUsers.Enabled = false;
            panelAddProd.Visible = false;
            panelAddProd.Enabled = false;
            panelOrders.Enabled = false;
            panelOrders.Visible = false;
            panelEditUser.Visible = false;
            panelEditUser.Enabled = false;
            panelView.BringToFront();
            sidebar.BringToFront();
            sidebarTimer.Start();
            if (sidebarExpand)
            {
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            loadDataGridUsers();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            lblAdmin.Visible = false;
            logoPic.Visible = false;
            panelView.Visible = false;
            panelView.Enabled = false;
            panelProd.Enabled = false;
            panelProd.Visible = false;
            panelAddUsers.Visible = false;
            panelAddUsers.Enabled = false;
            panelAddProd.Visible = false;
            panelAddProd.Enabled = false;
            panelOrders.Enabled = true;
            panelOrders.Visible = true;
            panelEditUser.Visible = false;
            panelEditUser.Enabled = false;
            panelOrders.BringToFront();
            sidebar.BringToFront();
            sidebarTimer.Start();
            if (sidebarExpand)
            {
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            loadDataGridOrders();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            lblAdmin.Visible = false;
            logoPic.Visible = false;
            panelView.Visible = false;
            panelView.Enabled = false;
            panelOrders.Visible = false;
            panelOrders.Enabled = false;
            panelProd.Enabled = true;
            panelProd.Visible = true;
            panelAddUsers.Visible = false;
            panelAddUsers.Enabled = false;
            panelAddProd.Visible = false;
            panelAddProd.Enabled = false;
            panelOrders.Enabled = false;
            panelOrders.Visible = false;
            panelEditUser.Visible = false;
            panelEditUser.Enabled = false;
            panelProd.BringToFront();
            sidebar.BringToFront();
            sidebarTimer.Start();
            if (sidebarExpand)
            {
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            loadDataGridProducts();
        }

        private void AdminDash_Load(object sender, EventArgs e)
        {

            panelView.Visible = false;
            panelView.Enabled = false;
            panelAddUsers.Visible = false;
            panelAddUsers.Enabled = false;
            panelAddProd.Enabled = false;
            panelAddProd.Visible = false;
            panelOrders.Enabled = false;
            panelOrders.Visible = false;
            panelProd.Visible = false;
            panelProd.Enabled = false;
            panelOrders.Enabled = false;
            panelEditUser.Visible = false;
            panelEditUser.Enabled = false;
            logoPic.BringToFront();
            lblAdmin.BringToFront();
            sidebar.BringToFront();
        }

        private void loadDataGridUsers()
        {
            sqlCon.Open();
            SqlCommand com = new SqlCommand("SELECT C_ID AS CustomerID," +
                                "C_Username AS Username," +
                                "C_Firstname AS Firstname," +
                                "C_Lastname AS Lastname," +
                                "C_Email AS Email," +
                                "C_UserType AS Type " +
                                "FROM CUSTOMERS", sqlCon);

            com.ExecuteNonQuery();

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dgvView.DataSource = data;
            sqlCon.Close();
        }

        private void loadDataGridProducts()
        {
            try
            {
                sqlCon.Open();
                SqlCommand com = new SqlCommand("SELECT P_ID AS ProductID, " +
                                       "P_IMAGE AS ProductImage, " +
                                       "P_NAME AS ProductName, " +
                                       "P_QUANTITY AS ProductQuantity, " +
                                       "P_PRICE AS ProductPrice, " +
                                       "P_CATEGORY AS ProductCategory " +
                                 "FROM PRODUCTS", sqlCon);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
                DataTable data = new DataTable();
                data.Clear();
                dataAdapter.Fill(data);
                dgvProducts.DataSource = data;
                DataGridViewImageColumn pImage = new DataGridViewImageColumn();
                pImage = (DataGridViewImageColumn)dgvProducts.Columns[1];
                pImage.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }



        private void loadDataGridOrders()
        {
            sqlCon.Open();
            SqlCommand com = new SqlCommand("SELECT O_ID AS OrderId," +
                    "PRODUCT_ID AS ProductID," +
                    "PRODUCT_NAME AS ProductName," +
                    "ORDERED_QUANTITY AS OrderedQuantity," +
                    "PRODUCT_PRICE AS ProductPrice," +
                    "ORDER_TOTAL_PRICE AS OrderTotalPrice," +
                    "ORDER_DATE AS OrderDate " +
                    "FROM ORDERS", sqlCon);


            com.ExecuteNonQuery();

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dgvOrders.DataSource = data;
            sqlCon.Close();
        }



        private void LoadAdminAccounts()
        {
            sqlCon.Open();
            SqlCommand com = new SqlCommand("SELECT A_ID AS AdminID," +
                                            "A_Username AS Username," +
                                            "A_Password AS Password," +
                                            "A_Firstname AS Firstname," +
                                            "A_Lastname AS Lastname," +
                                            "A_Email AS Email," +
                                            "A_UserType AS Type " +
                                            "FROM ADMINISTRATOR", sqlCon);

            com.ExecuteNonQuery();

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dgvEditUser.DataSource = data;
            sqlCon.Close();
        }

        private void loadCustomerAccounts()
        {
            sqlCon.Open();
            SqlCommand com = new SqlCommand("SELECT C_ID AS CustomerID," +
                                "C_Username AS Username," +
                                "C_Password AS Password," +
                                "C_Firstname AS Firstname," +
                                "C_Lastname AS Lastname," +
                                "C_Email AS Email," +
                                "C_UserType AS Type " +
                                "FROM CUSTOMERS", sqlCon);

            com.ExecuteNonQuery();

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable data = new DataTable();
            adapter.Fill(data);
            dgvEditUser.DataSource = data;
            sqlCon.Close();
        }

        private void ClearInputFields()
        {
            txtBoxFName.Clear();
            txtBoxLname.Clear();
            txtBoxEmail.Clear();
            rbtnAdmin.Checked = false;
            rbtnCustomer.Checked = false;
            txtBoxUName.Clear();
            txtBoxPassword.Clear();
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
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

        private string DecryptPassword(string encryptedPassword)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(encryptedPassword));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }










        private void btnAddUser_Click(object sender, EventArgs e)
        {

            if (rbtnAdmin.Checked || rbtnCustomer.Checked)
            {
                string userType = rbtnAdmin.Checked ? "admin" : "customer";

                string firstname = txtBoxFName.Text;
                string lastname = txtBoxLname.Text;
                string email = txtBoxEmail.Text;
                string username = txtBoxUName.Text;
                string password = txtBoxPassword.Text;
                string encryptedPassword = password;


                if (string.IsNullOrWhiteSpace(firstname))
                {
                    MessageBox.Show("Please enter a valid first name.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(lastname))
                {
                    MessageBox.Show("Please enter a valid last name.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                if (string.IsNullOrWhiteSpace(username))
                {
                    MessageBox.Show("Please enter a valid username.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please enter a valid password.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string insertQuery = "";
                if (userType == "admin")
                {
                    insertQuery = @"INSERT INTO ADMINISTRATOR (A_FIRSTNAME, A_LASTNAME, A_EMAIL, A_USERTYPE, A_USERNAME, A_PASSWORD)
                    VALUES (@Firstname, @Lastname, @Email, @UserType, @Username, @Password)";
                }
                else
                {
                    string encryptedPwd = EncryptPassword(password);
                    insertQuery = @"INSERT INTO CUSTOMERS (C_FIRSTNAME, C_LASTNAME, C_EMAIL, C_USERTYPE, C_USERNAME, C_PASSWORD)
                    VALUES (@Firstname, @Lastname, @Email, @UserType, @Username, @Password)";
                }

                using (SqlCommand cmd = new SqlCommand(insertQuery, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@Firstname", firstname);
                    cmd.Parameters.AddWithValue("@Lastname", lastname);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@UserType", userType);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", encryptedPassword);

                    try
                    {
                        sqlCon.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(userType + " added successfully.");
                            ClearInputFields();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add " + userType + ".");
                        }
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
                loadDataGridUsers();
            }
            else
            {
                MessageBox.Show("Please select user account type.", "User Type Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        private void closeAdd_Click(object sender, EventArgs e)
        {
            panelAddUsers.Visible = false;
            panelAddUsers.Enabled = false;
            panelView.Enabled = true;
            panelView.Visible = true;
            lblAdmin.Visible = true;
            logoPic.Visible = true;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            uploadPhoto.Filter = "Select image(*.JpG; *.png; *.Gif) | *.JpG; *.png; *.Gif";
            if (uploadPhoto.ShowDialog() == DialogResult.OK)
            {
                prodImage.Image = Image.FromFile(uploadPhoto.FileName);
                txtBoxImgPath.Text = uploadPhoto.FileName;
            }
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            MemoryStream memstr = new MemoryStream();
            prodImage.Image.Save(memstr, prodImage.Image.RawFormat);
            string PName = txtBoxPName.Text;
            string PDesc = txtBoxPDesc.Text;
            int PQuantity = int.Parse(txtBoxQuantity.Text);
            double PPrice = double.Parse(txtBoxPrice.Text);
            string PCategory = "";
            if (rbtnBurger.Checked)
            {
                PCategory = "figurine";
            }
            else
            {
                PCategory = "plushy";
            }

            string insertQuery = @"INSERT INTO PRODUCTS (P_IMAGE, P_DESCRIPTION, P_NAME, P_QUANTITY, P_PRICE, P_CATEGORY)
                           VALUES (@Image, @Description, @Name, @Quantity, @Price, @Category)";

            using (SqlCommand cmd = new SqlCommand(insertQuery, sqlCon))
            {
                cmd.Parameters.AddWithValue("@Image", memstr.ToArray());
                cmd.Parameters.AddWithValue("@Name", PName);
                cmd.Parameters.AddWithValue("@Quantity", PQuantity);
                cmd.Parameters.AddWithValue("@Price", PPrice);
                cmd.Parameters.AddWithValue("@Description", PDesc);
                cmd.Parameters.AddWithValue("@Category", PCategory);

                try
                {
                    sqlCon.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product added successfully.");
                        prodImage.Image = null;
                        txtBoxImgPath.Clear();
                        txtBoxImgPath.Clear();
                        txtBoxPName.Clear();
                        txtBoxPDesc.Clear();
                        txtBoxQuantity.Clear();
                        txtBoxPrice.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add product.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlCon.Close();
                }
            }
            loadDataGridProducts();
        }

        private void closeProd_Click(object sender, EventArgs e)
        {
            panelAddUsers.Visible = false;
            panelAddUsers.Enabled = false;
            panelAddProd.Enabled = false;
            panelAddProd.Visible = false;
            panelEditUser.Visible = false;
            panelEditUser.Enabled = false;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            panelAddUsers.Visible = false;
            panelAddUsers.Enabled = false;
            panelView.Enabled = false;
            panelView.Visible = false;
            panelOrders.Enabled = false;
            panelOrders.Visible = false;
            panelOrders.Enabled = false;
            panelOrders.Visible = false;
            panelAddProd.Visible = true;
            panelAddProd.Enabled = true;
            panelEditUser.Visible = false;
            panelEditUser.Enabled = false;
            panelAddProd.BringToFront();
        }

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            panelAddProd.Visible = false;
            panelAddProd.Enabled = false;
            panelView.Enabled = false;
            panelView.Visible = false;
            panelOrders.Enabled = false;
            panelOrders.Visible = false;
            panelOrders.Enabled = false;
            panelOrders.Visible = false;
            panelAddUsers.Visible = true;
            panelAddUsers.Enabled = true;
            panelEditUser.Visible = false;
            panelEditUser.Enabled = false;
            panelAddUsers.BringToFront();
        }

        private void btnEditUsers_Click(object sender, EventArgs e)
        {
            panelAddProd.Visible = false;
            panelAddProd.Enabled = false;
            panelView.Enabled = false;
            panelView.Visible = false;
            panelOrders.Enabled = false;
            panelOrders.Visible = false;
            panelOrders.Enabled = false;
            panelOrders.Visible = false;
            panelAddUsers.Visible = false;
            panelAddUsers.Enabled = false;
            panelEditUser.Visible = true;
            panelEditUser.Enabled = true;
            panelEditUser.BringToFront();
        }

        private void btnDeleteUsers_Click(object sender, EventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadAdminAccounts();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            loadCustomerAccounts();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {

        }

      
    }
}
