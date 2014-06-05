<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarVentas.aspx.cs" Inherits="DMarysSoftWEB.Formulario_web16" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2 style="text-align: center">Mostrar Ventas</h2>
    <table class="style2">
        <tr>
            <td>
                
                <asp:Calendar ID="CalendarInicio" runat="server" 
                    onselectionchanged="CalendarInicio_SelectionChanged"></asp:Calendar>
            </td>
            <td>
                <asp:Calendar ID="CalendarFin" runat="server" 
                    onselectionchanged="CalendarFin_SelectionChanged"></asp:Calendar>
            </td>
        </tr>
    </table>
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
        onclick="btnBuscar_Click" />
    <asp:Label ID="txtFecha" runat="server"></asp:Label>
    <br />
    <asp:GridView ID="grvMostrarVentas" runat="server" Width="582px" 
        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
        GridLines="None" style="font-size: x-large">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="idVenta" HeaderText="Id Venta" />
            <asp:BoundField DataField="cliente" HeaderText="Cliente" />
            <asp:BoundField DataField="fecha" HeaderText="Fecha" />
            <asp:BoundField DataField="total" HeaderText="Total" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    </asp:Content>
