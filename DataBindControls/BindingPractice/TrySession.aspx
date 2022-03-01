<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrySession.aspx.cs" Inherits="BindingPractice.TrySession" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Session</h1>
        <div>
            <asp:TextBox runat="server" ID="txt"> Will.Lark.Cheng </asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="寫入" OnClick="Button1_Click" />
        </div>
        <div>
            <asp:Button ID="Button3" runat="server" Text="清除" OnClick="Button3_Click" />
        </div>
        <div>
            <asp:Button ID="Button2" runat="server" Text="讀取" OnClick="Button2_Click" /><br />
            Session:
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
