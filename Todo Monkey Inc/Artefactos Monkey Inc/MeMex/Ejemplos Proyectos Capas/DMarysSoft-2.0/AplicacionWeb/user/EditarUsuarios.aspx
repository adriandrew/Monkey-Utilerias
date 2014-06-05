<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarUsuarios.aspx.cs" Inherits="DMarysSoftWEB.Formulario_web19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2 style="text-align: center">Editar Usuarios</h2>
    <asp:GridView ID="gvEditarUsuarios" runat="server" 
        AutoGenerateColumns="False" CellPadding="4" DataSourceID="sdsEditUsers" 
        ForeColor="#333333" GridLines="None" onrowediting="gvEditarUsuarios_RowEditing" 
        onrowupdated="gvEditarUsuarios_RowUpdated" 
        onrowupdating="gvEditarUsuarios_RowUpdating">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" 
                SortExpression="UserName" />
            <asp:BoundField DataField="RoleName" HeaderText="RoleName" ReadOnly="True" 
                SortExpression="RoleName" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Comment" HeaderText="Comment" 
                SortExpression="Comment" />
            <asp:BoundField DataField="UserId" HeaderText="UserId" 
                SortExpression="UserId" />
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
    <asp:SqlDataSource ID="sdsEditUsers" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT aspnet_Users.UserName, aspnet_Roles.RoleName, aspnet_Membership.Email, aspnet_Membership.Comment, aspnet_Users.UserId FROM aspnet_Users INNER JOIN aspnet_UsersInRoles ON aspnet_Users.UserId = aspnet_UsersInRoles.UserId INNER JOIN aspnet_Roles ON aspnet_UsersInRoles.RoleId = aspnet_Roles.RoleId INNER JOIN aspnet_Membership ON aspnet_Users.UserId = aspnet_Membership.UserId" 
        UpdateCommand="UPDATE aspnet_Membership SET Email = @Email, Comment = @Comment WHERE (UserId = @UserId)">
        <UpdateParameters>
            <asp:Parameter Name="Email" />
            <asp:Parameter Name="Comment" />
            <asp:Parameter Name="UserId" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    <asp:Label ID="lblSeleccionado" runat="server" style="font-weight: 700" 
        Text="Valor seleccionado"></asp:Label>
</asp:Content>
