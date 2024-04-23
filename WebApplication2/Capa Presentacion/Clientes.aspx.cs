using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace ExamenFinal.Capa_Presentacion
{
    public partial class Clientes_View : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
            }
        }
        protected void CargarClientes()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ExamenfinalBD"].ConnectionString;
            string query = "SELECT * FROM Clientes";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                GridViewClientes.DataSource = reader;
                GridViewClientes.DataBind();
            }
        }

        protected void AgregarCliente(object sender, EventArgs e)
        {
            string nombre = Request.Form["nombre"];
            string email = Request.Form["email"];
            string telefono = Request.Form["telefono"];

            // Cadena de conexión a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["ExamenfinalBD"].ConnectionString;

            // Consulta SQL para insertar un nuevo cliente en la base de datos
            string query = "INSERT INTO Clientes (Nombre, Email, Telefono) VALUES (@Nombre, @Email, @Telefono)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Telefono", telefono);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Éxito al agregar el cliente
                        // Puedes agregar lógica adicional aquí, como mostrar un mensaje de éxito
                        Response.Write("<script>alert('Cliente agregado correctamente.');</script>");
                    }
                    else
                    {
                        // Error al agregar el cliente
                        Response.Write("<script>alert('Error al agregar el cliente.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    // Error al conectarse a la base de datos o ejecutar la consulta SQL
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        protected void BorrarCliente(object sender, EventArgs e)
        {
            int idBorrar = Convert.ToInt32(Request.Form["idBorrar"]);

            // Cadena de conexión a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["ExamenfinalBD"].ConnectionString;

            // Consulta SQL para eliminar un cliente de la base de datos
            string query = "DELETE FROM Clientes WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", idBorrar);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Éxito al borrar el cliente
                        Response.Write("<script>alert('Cliente borrado correctamente.');</script>");
                    }
                    else
                    {
                        // No se encontró ningún cliente con el ID proporcionado
                        Response.Write("<script>alert('No se encontró ningún cliente con el ID proporcionado.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    // Error al conectarse a la base de datos o ejecutar la consulta SQL
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        protected void ModificarCliente(object sender, EventArgs e)
        {
            int idModificar = Convert.ToInt32(Request.Form["idModificar"]);
            string nuevoNombre = Request.Form["nombreModificar"];
            string nuevoEmail = Request.Form["emailModificar"];
            string nuevoTelefono = Request.Form["telefonoModificar"];

            // Cadena de conexión a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["ExamenfinalBD"].ConnectionString;

            // Consulta SQL para modificar un cliente en la base de datos
            string query = "UPDATE Clientes SET Nombre = @Nombre, Email = @Email, Telefono = @Telefono WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nuevoNombre);
                command.Parameters.AddWithValue("@Email", nuevoEmail);
                command.Parameters.AddWithValue("@Telefono", nuevoTelefono);
                command.Parameters.AddWithValue("@ID", idModificar);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Éxito al modificar el cliente
                        Response.Write("<script>alert('Cliente modificado correctamente.');</script>");
                    }
                    else
                    {
                        // No se encontró ningún cliente con el ID proporcionado
                        Response.Write("<script>alert('No se encontró ningún cliente con el ID proporcionado.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    // Error al conectarse a la base de datos o ejecutar la consulta SQL
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }

}
