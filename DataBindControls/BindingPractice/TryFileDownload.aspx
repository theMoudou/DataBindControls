<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryFileDownload.aspx.cs" Inherits="BindingPractice.TryFileDownload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        目前使用者積分：<asp:TextBox ID="txtScore" runat="server">500</asp:TextBox> 分
        <asp:Button runat="server" ID="btn1" Text="下載 (扣除 10 分)" OnClick="btn1_Click" />
        <asp:Literal runat="server" ID="ltlMsg"></asp:Literal>
    </form>
</body>
</html>
