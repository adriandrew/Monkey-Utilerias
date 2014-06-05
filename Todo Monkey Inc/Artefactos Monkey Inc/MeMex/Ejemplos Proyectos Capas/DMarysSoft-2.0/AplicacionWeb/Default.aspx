<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DMarysSoftWEB.Formulario_web13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            text-align: center;
            font-size: xx-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<h2 class="style2">Bienvenido!</br> Usted esta en la pagina de Inicio</h2>

    <asp:Image ID="Image1" runat="server" Height="350px" 
        ImageUrl="~/images/zapateria.jpg" Width="764px" />
    <br />
&nbsp;
</asp:Content>
