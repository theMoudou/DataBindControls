<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryCache.aspx.cs" Inherits="BindingPractice.TryCache" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" Text="寫入" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="清除" OnClick="Button2_Click" />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </form>
</body>
</html>
