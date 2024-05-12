using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BurgerManor
{
    public partial class CustomerDash : Form
    {
        public SqlConnection sqlCon;
        public SqlCommand cmd;
        public SqlDataAdapter dataAdapter;
        public SqlDataReader dataReader;

        private PictureBox product;
        private Label productName;
        private Label ofStock;
        private Label productPrice;

        private int userId;
        public CustomerDash(int userId)
        {
            InitializeComponent();
            sqlCon = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=BurgerManor;Integrated Security=True;");
            this.userId = userId;

        }

        private void CustomerDash_Load(object sender, EventArgs e)
        {
            panelHomeMain.Visible = true;
            panelHomeMain.Enabled = true;
            panelburger.Visible = false;
            panelburger.Enabled = false;
            panelFries.Visible = false;
            panelFries.Enabled = false;
            fLPanelHome.Controls.Clear(); // Clear existing picture boxes
            loadDataHome();

            receipt.Columns["OrderName"].DataPropertyName = "P_NAME";
            receipt.Columns["OrderPrice"].DataPropertyName = "P_PRICE";
        }


        private void UpdateProductStock(int productId, int purchasedQuantity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=BurgerManor;Integrated Security=True;"))
                {
                    connection.Open();

                    // Begin transaction
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Retrieve the current stock quantity of the product
                            string selectQuery = "SELECT P_QUANTITY FROM PRODUCTS WHERE PID = @ProductId";
                            SqlCommand selectCmd = new SqlCommand(selectQuery, connection, transaction);
                            selectCmd.Parameters.AddWithValue("@ProductId", productId);

                            // Execute the command to retrieve the current stock quantity
                            int currentStock = Convert.ToInt32(selectCmd.ExecuteScalar());

                            // Calculate the new stock quantity after the purchase
                            int newStock = currentStock - purchasedQuantity;

                            if (newStock < 0)
                            {
                                MessageBox.Show("Insufficient stock.");
                                return;
                            }

                            // Update the database with the new stock quantity
                            string updateQuery = "UPDATE PRODUCTS SET P_QUANTITY = @NewStock WHERE PID = @ProductId";
                            SqlCommand updateCmd = new SqlCommand(updateQuery, connection, transaction);
                            updateCmd.Parameters.AddWithValue("@NewStock", newStock);
                            updateCmd.Parameters.AddWithValue("@ProductId", productId);
                            updateCmd.ExecuteNonQuery();

                            // Commit the transaction
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction in case of any error
                            transaction.Rollback();
                            MessageBox.Show("Error updating product stock: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }




        private void OnClick(object sender, EventArgs e)
        {
            string tag = ((PictureBox)sender).Tag.ToString();
            string productName = "";
            double productPrice = 0.0;
            double unitPrice = 0.0;
            int availableQuantity = 0;
            char add = '+';
            char remove = '-';
            try
            {
                // Make sure to close any pending transaction before opening the connection
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }

                sqlCon.Open();
                string query = "SELECT P_NAME, P_PRICE, P_QUANTITY FROM PRODUCTS WHERE PID LIKE @Tag";
                using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@Tag", tag);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            productName = reader["P_NAME"].ToString();
                            availableQuantity = Convert.ToInt32(reader["P_QUANTITY"]);
                            unitPrice = Convert.ToDouble(reader["P_PRICE"]);
                            productPrice = Convert.ToDouble(reader["P_PRICE"]);
                        }
                    }
                }

                bool productFound = false;
                foreach (DataGridViewRow row in receipt.Rows)
                {
                    if (row.Cells["OrderName"].Value.ToString() == productName)
                    {
                        productFound = true;
                        int quantity = Convert.ToInt32(row.Cells["OrderQuantity"].Value);
                        if (quantity < availableQuantity)
                        {
                            row.Cells["OrderQuantity"].Value = quantity + 1; // Increase quantity
                            row.Cells["OrderPrice"].Value = (quantity + 1) * unitPrice; // Update price
                        }
                        else
                        {
                            MessageBox.Show("Maximum quantity reached for this product.");
                        }
                        break;
                    }
                }

                if (!productFound && availableQuantity > 0)
                {
                    receipt.Rows.Add(receipt.Rows.Count + 1, tag, productName, 1, unitPrice.ToString("#,##0.00"), productPrice.ToString("#,##0.00"), remove, add);
                }
                else if (availableQuantity <= 0)
                {
                    MessageBox.Show("Product is out of stock.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
        }





        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            this.Hide();

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            panelHomeMain.Visible = true;
            panelHomeMain.Enabled = true;
            panelburger.Visible = false;
            panelburger.Enabled = false;
            panelFries.Visible = false;
            panelFries.Enabled = false;
            fLPanelHome.Controls.Clear(); // Clear existing picture boxes
            loadDataHome();
        }

        private void loadDataHome()
        {
            try
            {
                sqlCon.Open();
                string query = "SELECT P_IMAGE, P_NAME, P_PRICE, P_QUANTITY, PID FROM PRODUCTS";
                cmd = new SqlCommand(query, sqlCon);
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    receipt.ColumnHeadersVisible = false;

                    long len = dataReader.GetBytes(0, 0, null, 0, 0);
                    byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                    dataReader.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                    product = new PictureBox();
                    product.Width = 162;
                    product.Height = 170;
                    product.BackgroundImageLayout = ImageLayout.Zoom;
                    product.BorderStyle = BorderStyle.FixedSingle;
                    product.BackColor = Color.FromArgb(231, 235, 238);
                    product.Cursor = Cursors.Hand;
                    string productId = dataReader["PID"].ToString();
                    product.Tag = productId;

                    productPrice = new Label();
                    double price = Convert.ToDouble(dataReader["P_PRICE"]);
                    string formattedPrice = String.Format("{0:0.00}", price);
                    productPrice.Text = formattedPrice;
                    productPrice.BackColor = Color.FromArgb(35, 40, 45);
                    productPrice.ForeColor = Color.White;
                    productPrice.Width = 70;
                    productPrice.TextAlign = ContentAlignment.MiddleCenter;
                    productPrice.Font = new Font("Cooper Black", 11, FontStyle.Regular);

                    productName = new Label();
                    productName.Text = dataReader["P_NAME"].ToString();
                    productName.BackColor = Color.FromArgb(35, 40, 45);
                    productName.ForeColor = Color.White;
                    productName.Dock = DockStyle.Bottom;
                    productName.Height = 30;
                    productName.Font = new Font("Cooper Black", 12, FontStyle.Regular);
                    productName.TextAlign = ContentAlignment.MiddleCenter;
                    productName.Padding = new Padding(0, 5, 0, 0);

                    MemoryStream ms = new MemoryStream(array);
                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(ms);
                    product.BackgroundImage = bitmap;

                    product.Controls.Add(productPrice);
                    product.Controls.Add(productName);
                    fLPanelHome.Controls.Add(product);

                    product.Click += new EventHandler(OnClick);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                if (dataReader != null)
                    dataReader.Close();
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {
            panelHomeMain.Visible = false;
            panelHomeMain.Enabled = false;
            panelburger.Visible = true;
            panelburger.Enabled = true;
            panelFries.Visible = false;
            panelFries.Enabled = false;
            fLPanelBurger.Controls.Clear(); // Clear existing picture boxes
            loadDataBurger();
        }

        private void loadDataBurger()
        {
            try
            {
                sqlCon.Open();
                string query = "SELECT P_IMAGE, P_NAME, P_PRICE, P_QUANTITY, P_CATEGORY, PID FROM PRODUCTS";
                cmd = new SqlCommand(query, sqlCon);
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    string category = dataReader["P_CATEGORY"].ToString().ToLower();
                    if (category == "figurine")
                    {
                        receipt.ColumnHeadersVisible = false;

                        long len = dataReader.GetBytes(0, 0, null, 0, 0);
                        byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                        dataReader.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                        product = new PictureBox();
                        product.Width = 162;
                        product.Height = 170;
                        product.BackgroundImageLayout = ImageLayout.Zoom;
                        product.BorderStyle = BorderStyle.FixedSingle;
                        product.BackColor = Color.FromArgb(231, 235, 238);
                        product.Cursor = Cursors.Hand;
                        string productId = dataReader["PID"].ToString();
                        product.Tag = productId;

                        productPrice = new Label();
                        double price = Convert.ToDouble(dataReader["P_PRICE"]);
                        string formattedPrice = String.Format("{0:0.00}", price);
                        productPrice.Text = formattedPrice;
                        productPrice.BackColor = Color.FromArgb(13, 16, 19);
                        productPrice.ForeColor = Color.White;
                        productPrice.Width = 70;
                        productPrice.TextAlign = ContentAlignment.MiddleCenter;
                        productPrice.Font = new Font("Cooper Black", 11, FontStyle.Regular);

                        productName = new Label();
                        productName.Text = dataReader["P_NAME"].ToString();
                        productName.BackColor = Color.FromArgb(13, 16, 19);
                        productName.ForeColor = Color.White;
                        productName.Dock = DockStyle.Bottom;
                        productName.Height = 30;
                        productName.Font = new Font("Cooper Black", 12, FontStyle.Regular);
                        productName.TextAlign = ContentAlignment.MiddleCenter;
                        productName.Padding = new Padding(0, 5, 0, 0);

                        MemoryStream ms = new MemoryStream(array);
                        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(ms);
                        product.BackgroundImage = bitmap;

                        product.Controls.Add(productPrice);
                        product.Controls.Add(productName);
                        fLPanelBurger.Controls.Add(product);

                        product.Click += new EventHandler(OnClick);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                if (dataReader != null)
                    dataReader.Close();
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
        }

        private void btnFries_Click(object sender, EventArgs e)
        {
            panelHomeMain.Visible = false;
            panelHomeMain.Enabled = false;
            panelburger.Visible= false;
            panelburger.Enabled = false;
            panelFries.Visible = true;
            panelFries.Enabled = true;
            flPanelFries.Controls.Clear(); // Clear existing picture boxes
            loadDataFries();
        }

        private void loadDataFries()
        {

            try
            {
                sqlCon.Open();
                string query = "SELECT P_IMAGE, P_NAME, P_PRICE, P_QUANTITY, P_CATEGORY, PID FROM PRODUCTS";
                cmd = new SqlCommand(query, sqlCon);
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    string category = dataReader["P_CATEGORY"].ToString().ToLower();
                    if (category == "plushy")
                    {
                        receipt.ColumnHeadersVisible = false;

                        long len = dataReader.GetBytes(0, 0, null, 0, 0);
                        byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                        dataReader.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                        product = new PictureBox();
                        product.Width = 162;
                        product.Height = 170;
                        product.BackgroundImageLayout = ImageLayout.Zoom;
                        product.BorderStyle = BorderStyle.FixedSingle;
                        product.BackColor = Color.FromArgb(231, 235, 238);
                        product.Cursor = Cursors.Hand;
                        string productId = dataReader["PID"].ToString();
                        product.Tag = productId;

                        productPrice = new Label();
                        double price = Convert.ToDouble(dataReader["P_PRICE"]);
                        string formattedPrice = String.Format("{0:0.00}", price);
                        productPrice.Text = formattedPrice;
                        productPrice.BackColor = Color.FromArgb(35, 40, 45);
                        productPrice.ForeColor = Color.White;
                        productPrice.Width = 70;
                        productPrice.TextAlign = ContentAlignment.MiddleCenter;
                        productPrice.Font = new Font("Cooper Black", 11, FontStyle.Regular);

                        productName = new Label();
                        productName.Text = dataReader["P_NAME"].ToString();
                        productName.BackColor = Color.FromArgb(35, 40, 45);
                        productName.ForeColor = Color.White;
                        productName.Dock = DockStyle.Bottom;
                        productName.Height = 30;
                        productName.Font = new Font("Cooper Black", 12, FontStyle.Regular);
                        productName.TextAlign = ContentAlignment.MiddleCenter;
                        productName.Padding = new Padding(0, 5, 0, 0);

                        MemoryStream ms = new MemoryStream(array);
                        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(ms);
                        product.BackgroundImage = bitmap;

                        product.Controls.Add(productPrice);
                        product.Controls.Add(productName);
                        flPanelFries.Controls.Add(product);

                        product.Click += new EventHandler(OnClick);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                if (dataReader != null)
                    dataReader.Close();
                if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
        }
    }
}
