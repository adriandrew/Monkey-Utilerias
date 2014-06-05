<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="Controls/ucMultiFileUpload.ascx" TagName="ucMultiFileUpload" TagPrefix="uc1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        multiple files Upload web user control</h2>
    <uc1:ucMultiFileUpload ID="ucMultiFileUpload1" runat="server" />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Subir imágenes" />
    <div>
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Mostrar las imágenes subidas</asp:LinkButton>
        <asp:Panel runat="server" ID="pnlImagenes" />
    </div>
</asp:Content>
