<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Target.aspx.cs" Inherits="BindingPractice.Target" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Q1: <asp:Literal runat="server" ID="ltl1"></asp:Literal><br />
        Q2: <asp:Literal runat="server" ID="ltl2"></asp:Literal><br />

        RequestInfo: <asp:Literal runat="server" ID="ltlRequestInfo"></asp:Literal><br />

        <asp:TextBox runat="server" ID="txt1">Test Value</asp:TextBox><br />
        <asp:Button runat="server" ID="btn1" Text="POST" OnClick="btn1_Click" />
    </form>
</body>
</html>
