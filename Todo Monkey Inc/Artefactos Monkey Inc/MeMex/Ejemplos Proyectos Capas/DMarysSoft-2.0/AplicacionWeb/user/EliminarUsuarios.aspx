<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarUsuarios.aspx.cs" Inherits="DMarysSoftWEB.Formulario_web110" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2 style="text-align: center">Eliminar Usuarios</h2>
<div style="overflow:auto; width:770px; height:auto" >
    <asp:GridView ID="gvEliminarUsuarios" runat="server" AllowSorting="True" 
        AutoGenerateColumns="False" CellPadding="4" DataSourceID="sdsDeleteUsers" 
        ForeColor="#333333" GridLines="None" AllowPaging="True" 
        onrowdeleted="GridView_RowDeleted" 
        onselectedindexchanged="gvEliminarUsuarios_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" 
                SortExpression="UserName" />
            <asp:BoundField DataField="RoleName" HeaderText="RoleName" 
                SortExpression="RoleName" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:CheckBoxField DataField="IsApproved" HeaderText="IsApproved" 
                SortExpression="IsApproved" />
            <asp:CheckBoxField DataField="IsLockedOut" HeaderText="IsLockedOut" 
                SortExpression="IsLockedOut" />
            <asp:BoundField DataField="Comment" HeaderText="Comment" 
                SortExpression="Comment" />
            <asp:BoundField DataField="UserId" HeaderText="UserId" 
                SortExpression="UserId" />
            <asp:BoundField DataField="RoleId" HeaderText="RoleId" 
                SortExpression="RoleId" />
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
    </div>
    <asp:SqlDataSource ID="sdsDeleteUsers" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        
        SelectCommand="SELECT aspnet_Users.UserName, aspnet_Roles.RoleName, aspnet_Membership.Email, aspnet_Membership.IsApproved, aspnet_Membership.IsLockedOut, aspnet_Membership.Comment, aspnet_Users.UserId, aspnet_UsersInRoles.RoleId FROM aspnet_Users INNER JOIN aspnet_UsersInRoles ON aspnet_Users.UserId = aspnet_UsersInRoles.UserId INNER JOIN aspnet_Roles ON aspnet_UsersInRoles.RoleId = aspnet_Roles.RoleId INNER JOIN aspnet_Membership ON aspnet_Users.UserId = aspnet_Membership.UserId" 
        DeleteCommand="SELECT ApplicationId, UserId, UserName, LoweredUserName, MobileAlias, IsAnonymous, LastActivityDate FROM aspnet_Users">
      
    </asp:SqlDataSource>
        
    <br />
    <asp:Label ID="lblSeleccionado" runat="server" style="font-weight: 700" 
        Text="Valor seleccionado"></asp:Label>
</asp:Content>
