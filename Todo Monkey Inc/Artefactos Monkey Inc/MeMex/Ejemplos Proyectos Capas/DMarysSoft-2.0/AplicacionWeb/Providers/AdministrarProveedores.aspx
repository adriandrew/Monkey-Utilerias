<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarProveedores.aspx.cs" Inherits="DMarysSoft.Providers.AdministrarProveedores1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<h2 style="text-align: center">Administrar Proveedores</h2>
     <table class="style2">
        <tr>
            <td class="style3">
                <asp:Label ID="Label1" runat="server" Text="Nombre Empresa:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombreEmpresa" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label2" runat="server" Text="Direccion Empresa:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDireccionEmpresa" runat="server" Width="148px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label3" runat="server" Text="Telefono Empresa:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTelefonoEmpresa" runat="server" Width="145px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                    onclick="btnGuardar_Click" Width="134px" />
            </td>
            <td>
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                    onclick="btnCancelar_Click" />
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="grvProveedores" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" 
        onrowdeleting="grvProveedores_RowDeleting" 
        onselectedindexchanged="grvProveedores_SelectedIndexChanged" 
        style="font-size: x-large">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
            <asp:BoundField DataField="idProveedor" HeaderText="Id Proveedor" />
            <asp:BoundField DataField="nombreEmpresa" HeaderText="Nombre Empresa" />
            <asp:BoundField DataField="direccionEmpresa" HeaderText="Direccion Empresa" />
            <asp:BoundField DataField="telefonoEmpresa" HeaderText="Telefono Empresa" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
 </asp:Content>
