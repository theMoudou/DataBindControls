<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="TryTemplates.Page1" %>

<%@ Register Src="~/ucText.ascx" TagPrefix="uc1" TagName="ucText" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> 測試 UC - Property </title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox runat="server" ID="txt"></asp:TextBox>
        <asp:Button runat="server" ID="btn" OnClick="btn_Click" Text="Submit" /><br />
        <uc1:ucText runat="server" id="ucText" Text="測試內容" />
    </form>
</body>
</html>
