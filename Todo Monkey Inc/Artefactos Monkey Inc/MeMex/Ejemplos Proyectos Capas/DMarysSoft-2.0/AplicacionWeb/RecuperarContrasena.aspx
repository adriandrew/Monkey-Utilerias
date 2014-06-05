<%@ Page Title="" Language="C#" MasterPageFile="~/SiteWithoutMenu.Master" AutoEventWireup="true" CodeBehind="RecuperarContrasena.aspx.cs" Inherits="DMarysSoftWEB.Account.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:PasswordRecovery ID="PasswordRecovery" runat="server" BackColor="#E3EAEB" 
        BorderColor="#0099FF" BorderPadding="4" BorderStyle="Solid" BorderWidth="3px" 
        Font-Names="Verdana" Font-Size="0.8em" Height="186px" 
        style="font-size: xx-large" Width="945px" 
        onsendingmail="PasswordRecovery_SendingMail">
        <SubmitButtonStyle BackColor="Lime" BorderColor="#C5BBAF" BorderStyle="Solid" 
            BorderWidth="3px" Font-Names="Verdana" Font-Size="X-Large" 
            ForeColor="#1C5E55" />
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <MailDefinition BodyFileName="~/Email.txt" 
            From="adriandrew@hotmail.com" Subject="Recuperar Contrasena" 
            Priority="High">
        </MailDefinition>
        <SuccessTemplate>
            <table cellpadding="4" cellspacing="0" style="border-collapse:collapse;">
                <tr>
                    <td>
                        <table cellpadding="0" style="height:186px;width:945px;">
                            <tr>
                                <td style="color:#1C5E55;font-weight:bold;">
                                    Se le ha enviado la contraseña.<br />   
                                    <asp:LinkButton ID="LinkButtonContinuar" runat="server" BackColor="Lime" 
                                        BorderColor="Gray" BorderWidth="3px" Font-Size="XX-Large" ForeColor="Black" 
                                        PostBackUrl="~/Login.aspx">Continuar</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </SuccessTemplate>
        <SuccessTextStyle Font-Bold="True" ForeColor="#1C5E55" />
        <TextBoxStyle Font-Size="0.8em" />
        <TitleTextStyle BackColor="#1C5E55" Font-Bold="True" Font-Size="0.9em" 
            ForeColor="White" />
    </asp:PasswordRecovery>
</asp:Content>
