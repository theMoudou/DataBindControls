<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryHttpItem.aspx.cs" Inherits="BindingPractice.TryHttpItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Http Item</h1>
        <div>
            <asp:Button ID="Button1" runat="server" Text="寫入並讀取 (存在)" OnClick="Button1_Click" />
        </div>
        <div>
            <asp:Button ID="Button3" runat="server" Text="寫入並讀取 (不存在)" OnClick="Button3_Click" />
        </div>
        <div>
            <asp:Literal runat="server" ID="ltl"></asp:Literal>
        </div>
    </form>
</body>
</html>
