<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="TryTemplates.Page2" %>

<%@ Register Src="~/ucText.ascx" TagPrefix="uc1" TagName="ucText" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> 測試頁面 2 </h1>
    <uc1:ucText runat="server" ID="ucText" />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
</asp:Content>
