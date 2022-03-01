<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TryMasterPage.aspx.cs" Inherits="BindingPractice.TryMasterPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><asp:Literal runat="server" ID="ltlTitle"></asp:Literal></h1>
    <div>
        <asp:Literal runat="server" ID="ltlContent"></asp:Literal>
    </div>
</asp:Content>
