<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page6.aspx.cs" Inherits="TryTemplates.Page6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            請輸入數字：<input type="number" name="txt1" />
            請輸入數字：<input type="number" name="txt1" />
            <asp:Button runat="server" Text="btn" /><br />
            <asp:Label runat="server" ID="lbl"></asp:Label>
        </div>
    </form>
</body>
</html>
