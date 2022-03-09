<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="DeliciousMap.BackAdmin.MemberList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button ID="btnCreate" runat="server" Text="新增" OnClick="btnCreate_Click" />
    <asp:Button ID="btnDelete" runat="server" Text="刪除" />

    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="代碼" />
            <asp:BoundField DataField="Account" HeaderText="帳號" />
            <asp:BoundField DataField="CreateDate" HeaderText="建立日期" />
        </Columns>
    </asp:GridView>

</asp:Content>
