<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateReg.aspx.cs" Inherits="Trabajo_Martos_Stefania.CreateReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 188px">
            <asp:Label ID="Label1" runat="server" Text="Monto"></asp:Label>
            <asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
            <br />

            <asp:DropDownList ID="DdlCuenta" runat="server" DataSourceID="SqlDtCuentas" DataTextField="descripcion" DataValueField="id"></asp:DropDownList>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Tipo"></asp:Label>
            <asp:DropDownList ID="dpTipo" runat="server">
                <asp:ListItem Value="Debe"></asp:ListItem>
                <asp:ListItem Value="Haber"></asp:ListItem>
            </asp:DropDownList>
            <br>
             <br>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Registro " OnClick="btnGuardar_Click" />
        </div>
        <asp:SqlDataSource ID="SqlDtCuentas" runat="server" ConnectionString="<%$ ConnectionStrings:EstudioContableConnectionString %>" SelectCommand="SELECT [id], [descripcion] FROM [Cuentas]"></asp:SqlDataSource>
    </form>
</body>
</html>
