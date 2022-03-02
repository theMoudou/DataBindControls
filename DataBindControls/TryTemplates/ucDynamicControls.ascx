<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDynamicControls.ascx.cs" Inherits="TryTemplates.ucDynamicControls" %>

<asp:PlaceHolder runat="server" ID="PlaceHolder1">

    <asp:Literal runat="server" ID="Literal1"></asp:Literal>
    
    <asp:PlaceHolder runat="server" ID="PlaceHolder2">
        <asp:Button runat="server" ID="Button1" Text="Button" />
        <asp:Label runat="server" ID="Label1" />
    </asp:PlaceHolder>

    <asp:Image runat="server" ID="Image1" />

</asp:PlaceHolder>