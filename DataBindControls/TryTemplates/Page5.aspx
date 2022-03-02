<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page5.aspx.cs" Inherits="TryTemplates.Page5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        請輸入要產生幾位學生: <asp:TextBox runat="server" ID="txtCtlNumber">5</asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" Text="加入控制項" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="送出" OnClick="Button2_Click" /><br />
        
    </form>
</body>
</html>
