<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="ExamenFinal.Presentacion.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menú</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Menú Principal</h1>
            <div>
                <asp:Button ID="btnAgentes" runat="server" Text="Catálogo de Agentes" OnClick="btnAgentes_Click" />
                <asp:Button ID="btnClientes" runat="server" Text="Catálogo de Clientes" OnClick="btnClientes_Click" />
            </div>
        </div>
    </form>
</body>
</html>
