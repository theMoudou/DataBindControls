<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TryMasterPage2.aspx.cs" Inherits="BindingPractice.TryMasterPage2" %>


<%@ Register Src="~/ucPercent.ascx" TagPrefix="uc1" TagName="ucPercent" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>TryMasterPage2.aspx</h1>

    <uc1:ucPercent runat="server" id="ucPercent1" />
    <uc1:ucPercent runat="server" id="ucPercent2" />
    <uc1:ucPercent runat="server" id="ucPercent3" />

</asp:Content>
