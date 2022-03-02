<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page4.aspx.cs" Inherits="TryTemplates.Page4" EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hfCount" Value="0" />
        請輸入要產生幾位學生: <asp:TextBox runat="server" ID="txtCtlNumber">5</asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" Text="加入控制項" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="送出" OnClick="Button2_Click" /><br />
        
        <asp:PlaceHolder runat="server" ID="plc"></asp:PlaceHolder>
    </form>
</body>
</html>
