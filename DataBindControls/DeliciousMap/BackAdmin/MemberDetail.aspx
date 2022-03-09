﻿<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="MemberDetail.aspx.cs" Inherits="DeliciousMap.BackAdmin.MemberDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table border="1">
        <tr>
            <th>會員代碼</th>
            <td>
                <asp:Literal ID="ltlID" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th>帳號</th>
            <td>
                <asp:Literal ID="ltlAccount" runat="server"></asp:Literal>
                <asp:TextBox runat="server" ID="txtAccount"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>密碼</th>
            <td>
                <asp:TextBox runat="server" ID="txtPassword"></asp:TextBox>
            </td>
        </tr>
    </table>

    <asp:Label runat="server" ID="lblMsg" ForeColor="Red"></asp:Label>

    <asp:Button runat="server" ID="btnSave" Text="儲存" OnClick="btnSave_Click" />
    <asp:Button runat="server" ID="btnCancel" Text="取消" OnClick="btnCancel_Click" />
</asp:Content>
