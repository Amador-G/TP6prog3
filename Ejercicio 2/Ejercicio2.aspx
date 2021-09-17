<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP6_GRUPO1.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-size: xx-large">
            Inicio</div>
        <p style="text-align: center">
            <a href="SeleccionarProductos.aspx">Seleccionar Productos</a></p>
        <p style="text-align: center">
            <asp:LinkButton ID="lbEliminarProductos" runat="server" OnClick="lbEliminarProductos_Click">Eliminar Productos Seleccionados</asp:LinkButton>
        </p>
    </form>
    <p style="text-align: center">
        <a href="MostrarProductos.aspx">Mostrar Productos</a></p>
</body>
</html>
