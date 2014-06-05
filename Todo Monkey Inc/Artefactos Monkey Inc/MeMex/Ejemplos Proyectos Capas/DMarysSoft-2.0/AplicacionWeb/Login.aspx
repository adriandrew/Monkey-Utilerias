<%@ Page Title="" Language="C#" MasterPageFile="~/SiteWithoutMenu.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DMarysSoftWEB.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <asp:LoginView ID="LoginView" runat="server">
        <AnonymousTemplate>
            <asp:Login ID="Login" runat="server" BackColor="#F7F7DE" BorderColor="#0099FF" 
                BorderStyle="Solid" BorderWidth="3px" Font-Names="Verdana" 
                Font-Size="Large" Font-Bold="True" Height="238px" Orientation="Horizontal" 
                Width="953px" DestinationPageUrl="~/Default.aspx" 
                PasswordRecoveryText="Clic aqui si OLVIDASTE TU CONTRASENA!" 
                PasswordRecoveryUrl="~/RecuperarContrasena.aspx">
                <CheckBoxStyle Font-Bold="False" />
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <LoginButtonStyle BackColor="Lime" BorderColor="#C5BBAF" BorderStyle="Solid" 
                    BorderWidth="3px" Font-Names="Verdana" Font-Size="X-Large" 
                    ForeColor="#1C5E55" />
                <TextBoxStyle Font-Size="0.8em" />
                <TitleTextStyle BackColor="#1C5E55" Font-Bold="True" 
                    ForeColor="#FFFFFF" Font-Size="0.9em" />
            </asp:Login>
        </AnonymousTemplate>
    </asp:LoginView>

    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Image ID="ImageProhibido" runat="server" Height="285px" 
        ImageUrl="~/images/prohibido.jpg" Width="327px" 
        style="margin-bottom: 0px" />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButtonRegresar" runat="server" 
        PostBackUrl="~/Default.aspx" BackColor="Lime" BorderColor="#C5BBAF" 
        BorderWidth="3px" Font-Size="40px" Font-Underline="False" ForeColor="#1C5E55" 
        style="text-align: left">Clic para regresar a pagina principal</asp:LinkButton>
    
    <br />
    <br />
        
</asp:Content>

 
