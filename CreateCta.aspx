<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateCta.aspx.cs" Inherits="Trabajo_Martos_Stefania.CreateCta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Descripcion:    "></asp:Label>
            <asp:TextBox ID="txtcuenta" runat="server" Width="303px"></asp:TextBox>
           <br/>
           <br/>
           <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
            <br />
            <asp:DropDownList ID="dpLCuentas" runat="server" DataSourceID="SqlDataSource1" DataTextField="descripcion" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="dpLCuentas_SelectedIndexChanged"></asp:DropDownList>
         
            <br />
            <br />
            <div>
                 <asp:Button ID="btnGuardar" runat="server" Text="Guardar Registro" OnClick="btnGuardar_Click" />
            </div>
            <br />
            <br />
            <div>
                 <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
            </div>
                 <br />
            <br />
            <div>
                 <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"  />
            </div>
               
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EstudioContableConnectionString %>" SelectCommand="SELECT [id], [descripcion] FROM [Cuentas]" DeleteCommand="DELETE FROM [Cuentas] WHERE [id] = @id" InsertCommand="INSERT INTO [Cuentas] ([descripcion]) VALUES (@descripcion)" UpdateCommand="UPDATE [Cuentas] SET [descripcion] = @descripcion WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="descripcion" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:ControlParameter ControlID="txtcuenta" Name="descripcion" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="dpLCuentas" Name="id" PropertyName="SelectedValue" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
