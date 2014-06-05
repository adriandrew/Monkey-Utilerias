<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarUsuarios.aspx.cs" Inherits="DMarysSoftWEB.user.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2 style="text-align: center">Agregar Usuarios</h2>
    <asp:CreateUserWizard ID="CreateUserWizard" runat="server" BackColor="#E3EAEB" 
        BorderColor="#0099FF" BorderStyle="Solid" BorderWidth="3px" Font-Names="Verdana" 
        Font-Size="0.8em" Height="159px" style="font-size: x-large" Width="770px" 
        DisplayCancelButton="True" 
    oncreateduser="CreateUserWizard_CreatedUser" 
    ContinueDestinationPageUrl="~/Default.aspx">
        <ContinueButtonStyle BackColor="Lime" BorderColor="#C5BBAF" BorderStyle="Solid" 
            BorderWidth="3px" Font-Names="Verdana" Font-Size="X-Large" 
            ForeColor="#1C5E55" />
        <CreateUserButtonStyle BackColor="Lime" BorderColor="#C5BBAF" 
            BorderStyle="Solid" BorderWidth="3px" Font-Names="Verdana" Font-Size="X-Large" 
            ForeColor="#1C5E55" />
        <TitleTextStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" >
                <CustomNavigationTemplate>
                    <table border="0" cellspacing="5" style="width:100%;height:100%;">
                        <tr align="right">
                            <td align="right" colspan="0">
                                <asp:Button ID="StepNextButton" runat="server" BackColor="Lime" 
                                    BorderColor="#C5BBAF" BorderStyle="Solid" BorderWidth="3px" 
                                    CommandName="MoveNext" Font-Names="Verdana" Font-Size="X-Large" 
                                    ForeColor="#1C5E55" Text="Crear usuario" ValidationGroup="CreateUserWizard" />
                            </td>
                            <td align="left" colspan="0">
                                <asp:Button ID="CancelButton" runat="server" BackColor="White" 
                                    BorderColor="#C5BBAF" BorderStyle="Solid" BorderWidth="1px" 
                                    CausesValidation="False" CommandName="Cancel" Font-Names="Verdana" 
                                    ForeColor="#1C5E55" Text="Cancelar" ValidationGroup="CreateUserWizard" />
                            </td>
                        </tr>
                    </table>
                </CustomNavigationTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep runat="server" />
        </WizardSteps>
        <HeaderStyle BackColor="#666666" BorderColor="#E6E2D8" BorderStyle="Solid" 
            BorderWidth="2px" Font-Bold="True" Font-Size="0.9em" ForeColor="White" 
            HorizontalAlign="Center" />
        <NavigationButtonStyle BackColor="White" BorderColor="#C5BBAF" 
            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
            ForeColor="#1C5E55" />
        <SideBarButtonStyle ForeColor="White" />
        <SideBarStyle BackColor="#1C5E55" Font-Size="0.9em" VerticalAlign="Top" />
        <StepStyle BorderWidth="0px" />
    </asp:CreateUserWizard>
</asp:Content>
