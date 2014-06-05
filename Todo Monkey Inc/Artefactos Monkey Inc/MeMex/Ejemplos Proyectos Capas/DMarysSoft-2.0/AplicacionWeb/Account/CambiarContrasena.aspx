<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambiarContrasena.aspx.cs" Inherits="DMarysSoftWEB.Account.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            width: 577px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2 style="text-align: center">Cambiar Contrasena</h2>
    <asp:ChangePassword ID="ChangePassword" runat="server" BackColor="#E3EAEB" 
        BorderColor="#0099FF" BorderPadding="4" BorderStyle="Solid" BorderWidth="3px" 
        Font-Names="Verdana" Font-Size="0.8em" Height="302px" 
        style="font-size: xx-large; text-align: left" Width="760px" 
    ContinueDestinationPageUrl="~/Default.aspx" DisplayUserName="True">
        <CancelButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid" 
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#1C5E55" />
        <ChangePasswordButtonStyle BackColor="Lime" BorderColor="#C5BBAF" 
            BorderStyle="Solid" BorderWidth="3px" Font-Names="Verdana" Font-Size="X-Large" 
            ForeColor="#1C5E55" />
        <ContinueButtonStyle BackColor="Lime" BorderColor="#C5BBAF" 
            BorderStyle="Solid" BorderWidth="3px" Font-Names="Verdana" Font-Size="X-Large" 
            ForeColor="#1C5E55" />
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <PasswordHintStyle Font-Italic="True" ForeColor="#1C5E55" />
        <TextBoxStyle Font-Size="0.8em" />
        <TitleTextStyle BackColor="#1C5E55" Font-Bold="True" Font-Size="0.9em" 
            ForeColor="White" />
    </asp:ChangePassword>
</asp:Content>
