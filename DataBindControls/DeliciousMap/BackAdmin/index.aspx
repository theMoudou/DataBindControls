<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DeliciousMap.BackAdmin.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        目前登入者：<asp:Literal ID="ltlAccount" runat="server"></asp:Literal>
        <br />
        <asp:Button runat="server" ID="btnLogout" Text="登出" OnClick="btnLogout_Click" />
    </form>
</body>
</html>
