using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace ExamenFinal.Capa_Presentacion
{
    public partial class Agentes : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAgentes();
            }
        }

        protected void CargarAgentes()
        {
            // Cadena de conexión a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["ExamenfinalBD"].ConnectionString;

            // Consulta SQL para seleccionar todos los agentes
            string query = "SELECT * FROM Agentes";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Enlazar los datos al GridView
                        gvAgentes.DataSource = dataTable;
                        gvAgentes.DataBind();
                    }
                }
            }
        }

        protected void AgregarAgente(object sender, EventArgs e)
        {
            string nombreAgente = nombre.Value;
            string emailAgente = email.Value;
            string telefonoAgente = telefono.Value;

            // Cadena de conexión a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["ExamenfinalBD"].ConnectionString;

            // Consulta SQL para insertar un nuevo agente en la base de datos
            string query = "INSERT INTO Agentes (Nombre, Email, Telefono) VALUES (@Nombre, @Email, @Telefono)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombreAgente);
                command.Parameters.AddWithValue("@Email", emailAgente);
                command.Parameters.AddWithValue("@Telefono", telefonoAgente);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Éxito al agregar el agente
                        // Aquí puedes agregar lógica adicional si lo deseas, como mostrar un mensaje de éxito
                        Response.Write("<script>alert('Agente agregado correctamente.');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al agregar el agente.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }

        protected void BorrarAgente(int idAgente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ExamenfinalBD"].ConnectionString;
            string query = "DELETE FROM Agentes WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", idAgente);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Agente eliminado correctamente');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('No se encontró ningún agente con el ID proporcionado');</script>");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Error al eliminar el agente: " + ex.Message + "');</script>");
                    }
                }
            }
        }

        protected void ModificarAgente(object sender, EventArgs e)
        {
            int idModificar = Convert.ToInt32(idModificar.Value);
            string nombre = nombreModificar.Value;
            string email = emailModificar.Value;
            string telefono = telefonoModificar.Value;

            // Cadena de conexión a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["ExamenfinalBD"].ConnectionString;

            // Consulta SQL para modificar un agente en la base de datos
            string query = "UPDATE Agentes SET Nombre = @Nombre, Email = @Email, Telefono = @Telefono WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", idModificar);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Telefono", telefono);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('Agente modificado correctamente.');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('No se encontró ningún agente con el ID proporcionado');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error al modificar el agente: " + ex.Message + "');</script>");
                }
            }

        }
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }
    }
}
