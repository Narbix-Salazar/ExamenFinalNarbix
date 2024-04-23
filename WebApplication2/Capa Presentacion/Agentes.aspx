<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agentes.aspx.cs" Inherits="ExamenFinal.Capa_Presentacion.Agentes" %>

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
    <h1>Gestión de Agentes</h1>

    <!-- Formulario para agregar un agente -->
    <form id="formAgregarAgente" runat="server">
        <label for="nombre">Nombre:</label>
        <input type="text" id="nombre" runat="server" required><br>
        <label for="email">Email:</label>
        <input type="email" id="email" runat="server" required><br>
        <label for="telefono">Teléfono:</label>
        <input type="tel" id="telefono" runat="server" required><br>
        <asp:Button ID="btnAgregarAgente" runat="server" Text="Agregar Agente" OnClick="AgregarAgente" />
    </form>

    <!-- Formulario para borrar un agente -->
    <form id="formBorrarAgente" runat="server">
        <label for="idBorrar">ID del Agente:</label>
        <input type="number" id="idBorrar" runat="server" required><br>
        <asp:Button ID="btnBorrarAgente" runat="server" Text="Borrar Agente" OnClick="BorrarAgente" />
    </form>

    <!-- Formulario para modificar un agente -->
    <form id="formModificarAgente" runat="server">
        <label for="idModificar">ID del Agente:</label>
        <input type="number" id="idModificar" runat="server" required><br>
        <label for="nombreModificar">Nuevo Nombre:</label>
        <input type="text" id="nombreModificar" runat="server"><br>
        <label for="emailModificar">Nuevo Email:</label>
        <input type="email" id="emailModificar" runat="server"><br>
        <label for="telefonoModificar">Nuevo Teléfono:</label>
        <input type="tel" id="telefonoModificar" runat="server"><br>
        <asp:Button ID="btnModificarAgente" runat="server" Text="Modificar Agente" OnClick="ModificarAgente" />
    </form>

    <!-- GridView para mostrar los agentes -->
    <asp:GridView ID="gvAgentes" runat="server" AutoGenerateColumns="true">
    </asp:GridView>

    <!-- Botón para regresar al menú -->
    <asp:Button ID="btnMenu" runat="server" Text="Volver al Menú" OnClick="btnMenu_Click" />
</body>
</html>
