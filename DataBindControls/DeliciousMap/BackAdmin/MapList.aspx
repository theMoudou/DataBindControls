<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="MapList.aspx.cs" Inherits="DeliciousMap.BackAdmin.MapList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button ID="btnDelete" runat="server" Text="刪除" OnClick="btnDelete_Click" />
    <asp:Button ID="btnCreate" runat="server" Text="新增" OnClick="btnCreate_Click" /><br />
       
    <asp:TextBox runat="server" ID="txtSearch"></asp:TextBox>
    <asp:Button runat="server" ID="btnSearch" Text="搜尋" OnClick="btnSearch_Click" /> <br />       

    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <a href="MapDetail.aspx?ID=<%# Eval("ID") %>" title="前往編輯：<%# Eval("Title") %>">
                <%# Eval("Title") %> 
            </a>
            <br />
        </ItemTemplate>
    </asp:Repeater>

    <asp:PlaceHolder runat="server" ID="plcEmpty" Visible="false">
        <p> 尚未有資料 </p>
    </asp:PlaceHolder>
</asp:Content>
