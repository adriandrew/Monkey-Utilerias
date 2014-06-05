<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PuntoVenta.aspx.cs" Inherits="DMarysSoft.Sales.PuntoVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 60px;
        }
        .style4
        {
            width: 48px;
        }
        .style5
        {
            width: 300px;
        }
        .style6
        {
            width: 138px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2 style="text-align: center">Punto de Venta</h2>
    <asp:TextBox ID="txtCodigoProducto" runat="server" 
        ontextchanged="txtCodigoProducto_TextChanged"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvCodigoProducto" runat="server" 
        ControlToValidate="txtCodigoProducto" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:Label ID="Label1" runat="server" Text="Codigo del Producto"></asp:Label>
    <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
        Text="Agregar" />
    <br />
    <br />
<asp:RadioButton ID="rbContado" runat="server" Checked="True" 
    GroupName="rbTipoPago" Text="Contado" />
<asp:RadioButton ID="rbCredito" runat="server" GroupName="rbTipoPago" 
    Text="Credito" />
    <asp:GridView ID="grvPuntoVenta" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="760px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="descripcion" HeaderText="Producto" />
            <asp:BoundField DataField="talla" HeaderText="Talla" />
            <asp:BoundField DataField="marca" HeaderText="Marca" />
            <asp:BoundField DataField="stock" HeaderText="Cantidad" />
            <asp:BoundField DataField="precio" HeaderText="Precio" />
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <table align="left" class="style2">
        <tr>
            <td class="style3">
                <asp:Label ID="Label2" runat="server" Text="Recibido"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRecibido" runat="server" Width="137px"></asp:TextBox>
            </td>
            <td class="style4">
                <asp:RequiredFieldValidator ID="rfvRecibido" runat="server" 
                    ControlToValidate="txtRecibido" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="style4">
                <asp:Label ID="Label3" runat="server" Text="Cambio"></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtCambio" runat="server" ReadOnly="True" Width="146px">0</asp:TextBox>
            </td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                <asp:Label ID="Label5" runat="server" Text="IVA"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtIva" runat="server" ReadOnly="True" Width="170px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                <asp:Label ID="Label6" runat="server" Text="Total"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True" Width="170px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar Venta" 
                    onclick="btnCancelar_Click" />
            </td>
            <td class="style4">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnCobrar" runat="server" Text="Cobrar" 
                    onclick="btnCobrar_Click" />
            </td>
        </tr>
        </table>
    <br />
</asp:Content>
