<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarProductos.aspx.cs" Inherits="TP6_GRUPO1.Ejercicio_2.MostrarProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="grdProdSel" runat="server" OnSelectedIndexChanged="grdProdSel_SelectedIndexChanged">
            </asp:GridView>
            <br />
            <a href="Ejercicio2.aspx">Volver a Inicio</a></div>
    </form>
</body>
</html>
