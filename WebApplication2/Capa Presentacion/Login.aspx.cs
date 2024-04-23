using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace ExamenFinal.Presentacion
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Aquí podrías manejar cualquier lógica necesaria al cargar la página
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = username.Value;
            string password = password.Value;


            if (ValidarCredenciales(username, password))
            {
                Response.Redirect("Menu.aspx"); // Redireccionar a Menu.aspx
            }
            else
            {
                Response.Write("<script>alert('Usuario o contraseña incorrectos');</script>");
            }
        }

        private bool ValidarCredenciales(string username, string password)
        {
 
            string connectionString = ConfigurationManager.ConnectionStrings["ExamenfinalBD"].ConnectionString;

   
            string query = "SELECT COUNT(*) FROM Usuarios WHERE Username = @Username AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}
