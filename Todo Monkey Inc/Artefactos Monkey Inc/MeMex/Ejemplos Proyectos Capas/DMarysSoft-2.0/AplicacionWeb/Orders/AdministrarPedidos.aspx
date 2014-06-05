<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarPedidos.aspx.cs" Inherits="DMarysSoft.Orders.AdministrarPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 134px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2 style="text-align: center">Administrar Pedidos</h2>
    
        <table class="style2">
            <tr>
                <td class="style3">
                    <asp:Label ID="Label1" runat="server" Text="Codigo Producto"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCodigoProducto" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label11" runat="server" Text="Proveedor"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlProveedor" runat="server">
                    </asp:DropDownList>
                    <asp:Label ID="lblProveedor" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label12" runat="server" Text="Sucursal"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSucursal" runat="server">
                    </asp:DropDownList>
                    <asp:Label ID="lblSucursal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label13" runat="server" Text="Stock"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label14" runat="server" Text="Precio"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label7" runat="server" Text="Talla"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTalla" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label4" runat="server" Text="Modelo"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label6" runat="server" Text="Color"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtColor" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label3" runat="server" Text="Marca"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label5" runat="server" Text="Estilo"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEstilo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label15" runat="server" Text="Sexo"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSexo" runat="server">
                        <asp:ListItem>Hombre</asp:ListItem>
                        <asp:ListItem>Mujer</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label16" runat="server" Text="Descuento"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDescuento" runat="server">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="87px" 
                        onclick="btnGuardar_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="84px" 
                        onclick="btnCancelar_Click" />
                </td>
            </tr>
        </table>
    
    <div style="overflow:auto; width:770px; height:auto" >
    <asp:GridView ID="grvPedidos" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
        GridLines="None" style="margin-right: 0px; font-size: large;" 
            onrowdeleting="grvPedidos_RowDeleting" 
            onselectedindexchanged="grvPedidos_SelectedIndexChanged" 
            ForeColor="#333333">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
            <asp:BoundField DataField="codigoProducto" HeaderText="Código Producto" />
            <asp:BoundField DataField="idProveedor" HeaderText="Proveedor" />
            <asp:BoundField DataField="idSucursal" HeaderText="Sucursal" />
            <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
            <asp:BoundField DataField="stock" HeaderText="Stock" />
            <asp:BoundField DataField="precio" HeaderText="Precio" />
            <asp:BoundField DataField="talla" HeaderText="Talla" />
            <asp:BoundField DataField="modelo" HeaderText="Modelo" />
            <asp:BoundField DataField="color" HeaderText="Color" />
            <asp:BoundField DataField="marca" HeaderText="Marca" />
            <asp:BoundField DataField="estilo" HeaderText="Estilo" />
            <asp:BoundField DataField="sexo" HeaderText="Sexo" />
<asp:BoundField DataField="descuento" HeaderText="Descuento"></asp:BoundField>
<asp:BoundField DataField="fechaIngreso" HeaderText="Fecha de Ingreso"></asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    </div>
    <asp:GridView ID="grvPrueba" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="idProveedor" HeaderText="Id Proveedor" />
            <asp:BoundField DataField="nombreEmpresa" HeaderText="Nombre Empresa" />
        </Columns>
    </asp:GridView>
    <br />
</asp:Content>
