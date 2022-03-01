<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSideBar.ascx.cs" Inherits="BindingPractice.ucSideBar" %>

<div class="box-body block-body">
    <div class="bar blockheader">
        <h3 class="t">
            <%--<asp:Literal runat="server" ID="ltlTitle"></asp:Literal>--%>
            <asp:Label runat="server" ID="ltlTitle"></asp:Label>
        </h3>
    </div>
    <div class="box blockcontent">
        <div class="box-body blockcontent-body">

            <asp:Literal runat="server" ID="ltlContent"></asp:Literal>

            <div class="cleared"></div>
        </div>
    </div>
    <div class="cleared"></div>
</div>
