<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryHttpError.aspx.cs" Inherits="BindingPractice.TryHttpError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1> 現在是正常的網頁 </h1>
        <asp:Button runat="server" OnClick="Unnamed_Click" Text="GoToError" />
    </form>
</body>
</html>
