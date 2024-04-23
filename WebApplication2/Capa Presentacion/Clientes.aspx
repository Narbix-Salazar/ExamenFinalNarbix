<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="ExamenFinal.Capa_Presentacion.Clientes_View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        /* Tu estilo CSS aquí */
    </style>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>Gestión de Clientes</h1>

    <form id="formAgregarCliente" runat="server">
        <label for="nombre">Nombre:</label>
        <asp:TextBox ID="txtNombre" runat="server" required></asp:TextBox><br>
        <label for="email">Email:</label>
        <asp:TextBox ID="txtEmail" runat="server" required></asp:TextBox><br>
        <label for="telefono">Teléfono:</label>
        <asp:TextBox ID="txtTelefono" runat="server" required></asp:TextBox><br>
        <asp:Button ID="btnAgregarCliente" runat="server" Text="Agregar Cliente" OnClick="AgregarCliente_Click" /><br><br>
    </form>

    <form id="formBorrarCliente" runat="server">
        <label for="idBorrar">ID del Cliente:</label>
        <asp:TextBox ID="txtIdBorrar" runat="server" required></asp:TextBox><br>
        <asp:Button ID="btnBorrarCliente" runat="server" Text="Borrar Cliente" OnClick="BorrarCliente_Click" /><br><br>
    </form>

    <form id="formModificarCliente" runat="server">
        <label for="idModificar">ID del Cliente:</label>
        <asp:TextBox ID="txtIdModificar" runat="server" required></asp:TextBox><br>
        <label for="nombreModificar">Nuevo Nombre:</label>
        <asp:TextBox ID="txtNombreModificar" runat="server"></asp:TextBox><br>
        <label for="emailModificar">Nuevo Email:</label>
        <asp:TextBox ID="txtEmailModificar" runat="server"></asp:TextBox><br>
        <label for="telefonoModificar">Nuevo Teléfono:</label>
        <asp:TextBox ID="txtTelefonoModificar" runat="server"></asp:TextBox><br>
        <asp:Button ID="btnModificarCliente" runat="server" Text="Modificar Cliente" OnClick="ModificarCliente_Click" /><br><br>
    </form>

    <asp:GridView ID="GridViewClientes" runat="server" AutoGenerateColumns="true"></asp:GridView><br>

    <asp:Button ID="btnMenu" runat="server" Text="Ir al Menú" OnClick="btnMenu_Click" />
</body>
</html>
