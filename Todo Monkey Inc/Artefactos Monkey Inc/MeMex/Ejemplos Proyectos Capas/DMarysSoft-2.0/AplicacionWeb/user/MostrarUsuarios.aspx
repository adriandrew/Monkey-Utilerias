<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MostrarUsuarios.aspx.cs" Inherits="DMarysSoftWEB.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2 style="text-align: center">Mostrar Usuarios</h2>
    <div style="overflow:auto; width:770px; height:auto" >
    <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" 
    CellPadding="4" DataSourceID="sdsSelectUsers" ForeColor="#333333" 
    GridLines="None" AllowSorting="True" BorderWidth="3px" AllowPaging="True">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
        <asp:BoundField DataField="UserName" HeaderText="UserName" 
            SortExpression="UserName" />
        <asp:BoundField DataField="RoleName" HeaderText="RoleName" 
            SortExpression="RoleName" />
        <asp:BoundField DataField="Password" HeaderText="Password" 
            SortExpression="Password" />
        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        <asp:BoundField DataField="LoweredEmail" HeaderText="LoweredEmail" 
            SortExpression="LoweredEmail" />
        <asp:BoundField DataField="PasswordQuestion" HeaderText="PasswordQuestion" 
            SortExpression="PasswordQuestion" />
        <asp:BoundField DataField="PasswordAnswer" HeaderText="PasswordAnswer" 
            SortExpression="PasswordAnswer" />
        <asp:CheckBoxField DataField="IsApproved" HeaderText="IsApproved" 
            SortExpression="IsApproved" />
        <asp:CheckBoxField DataField="IsLockedOut" HeaderText="IsLockedOut" 
            SortExpression="IsLockedOut" />
        <asp:BoundField DataField="CreateDate" HeaderText="CreateDate" 
            SortExpression="CreateDate" />
        <asp:BoundField DataField="LastLoginDate" HeaderText="LastLoginDate" 
            SortExpression="LastLoginDate" />
        <asp:BoundField DataField="LastPasswordChangedDate" 
            HeaderText="LastPasswordChangedDate" SortExpression="LastPasswordChangedDate" />
        <asp:BoundField DataField="LastLockoutDate" HeaderText="LastLockoutDate" 
            SortExpression="LastLockoutDate" />
        <asp:BoundField DataField="FailedPasswordAttemptCount" 
            HeaderText="FailedPasswordAttemptCount" 
            SortExpression="FailedPasswordAttemptCount" />
        <asp:BoundField DataField="FailedPasswordAttemptWindowStart" 
            HeaderText="FailedPasswordAttemptWindowStart" 
            SortExpression="FailedPasswordAttemptWindowStart" />
        <asp:BoundField DataField="FailedPasswordAnswerAttemptCount" 
            HeaderText="FailedPasswordAnswerAttemptCount" 
            SortExpression="FailedPasswordAnswerAttemptCount" />
        <asp:BoundField DataField="FailedPasswordAnswerAttemptWindowStart" 
            HeaderText="FailedPasswordAnswerAttemptWindowStart" 
            SortExpression="FailedPasswordAnswerAttemptWindowStart" />
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

<asp:SqlDataSource ID="sdsSelectUsers" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    SelectCommand="SELECT aspnet_Users.UserName, aspnet_Roles.RoleName, aspnet_Membership.Password, aspnet_Membership.Email, aspnet_Membership.LoweredEmail, aspnet_Membership.PasswordQuestion, aspnet_Membership.PasswordAnswer, aspnet_Membership.IsApproved, aspnet_Membership.IsLockedOut, aspnet_Membership.CreateDate, aspnet_Membership.LastLoginDate, aspnet_Membership.LastPasswordChangedDate, aspnet_Membership.LastLockoutDate, aspnet_Membership.FailedPasswordAttemptCount, aspnet_Membership.FailedPasswordAttemptWindowStart, aspnet_Membership.FailedPasswordAnswerAttemptCount, aspnet_Membership.FailedPasswordAnswerAttemptWindowStart, aspnet_Membership.Comment, aspnet_Users.UserId, aspnet_UsersInRoles.RoleId FROM aspnet_Users INNER JOIN aspnet_UsersInRoles ON aspnet_Users.UserId = aspnet_UsersInRoles.UserId INNER JOIN aspnet_Roles ON aspnet_UsersInRoles.RoleId = aspnet_Roles.RoleId INNER JOIN aspnet_Membership ON aspnet_Users.UserId = aspnet_Membership.UserId" 
    
        
        UpdateCommand="UPDATE aspnet_Membership SET Email = @Email, PasswordQuestion = @PasswordQuestion, PasswordAnswer = @PasswordAnswer WHERE (UserId = @UserId)">
    <UpdateParameters>
        <asp:Parameter Name="Email" />
        <asp:Parameter Name="PasswordQuestion" />
        <asp:Parameter Name="PasswordAnswer" />
        <asp:Parameter Name="UserId" />
    </UpdateParameters>
</asp:SqlDataSource>
</asp:Content>
