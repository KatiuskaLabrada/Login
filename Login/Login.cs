using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public void logins() 
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT UserName, UserPassword FROM LoginModule WHERE UserName='" + txtUser.Text + "' AND UserPassword='" + txtPassword.Text + "'", conexion))
                    {
                        SqlDataReader data = cmd.ExecuteReader();

                        if (data.Read())
                        {
                            MessageBox.Show("Bienvenido" + " " + txtUser.Text + "!");
                        }
                        else
                        {
                            MessageBox.Show("Datos incorrectos.");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            logins();
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
