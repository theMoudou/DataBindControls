<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Source.aspx.cs" Inherits="BindingPractice.Source" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Q1: <asp:TextBox ID="txtQ1" runat="server"></asp:TextBox><br />
        Q2: <asp:TextBox ID="txtQ2" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnSend" runat="server" Text="Button" OnClick="btnSend_Click" />
    </form>
</body>
</html>
