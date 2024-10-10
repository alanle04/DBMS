using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem {
    public partial class FLogin : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-UTUDG2V\\SQLEXPRESS;Initial Catalog=hotel;Integrated Security=True");
        public FLogin()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        public bool emptyFields()
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                return true;
            }
            return false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("All fields are required to be filled.", "Errorr Message", MessageBoxButtons.OK);
            }
            else
            {
                if (connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        connection.Open();
                        string selectAccount = "SELECT COUNT(*) FROM account WHERE username = @username AND password = @password";
                        using (SqlCommand cmd = new SqlCommand(selectAccount, connection))
                        {
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());


                            int rowCount = (int)cmd.ExecuteScalar();
                            if (rowCount > 0)
                            {
                                string selectRole = "SELECT role FROM staff WHERE username = @username";

                                using(SqlCommand getRole = new SqlCommand(selectRole, connection))
                                {
                                    getRole.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                                    getRole.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                                    string role = getRole.ExecuteScalar() as string;

                                    MessageBox.Show("Login successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    if (role == "manager")
                                    {
                                        FManager fManager = new FManager();
                                        fManager.Show();

                                        this.Hide();
                                    }
                                    else if (role == "receptionist")
                                    {
                                        FReceptionist fReceptionist = new FReceptionist();
                                        fReceptionist.Show();

                                        this.Hide();
                                    }

                                }
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Username or Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }
        }
    }
}
