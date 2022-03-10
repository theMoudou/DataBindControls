<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Temp.aspx.cs" Inherits="DeliciousMap.BackAdmin.Temp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:Button ID="btnDelete" runat="server" Text="刪除" OnClick="btnDelete_Click" />
        <asp:Button ID="btnCreate" runat="server" Text="新增" OnClick="btnCreate_Click" /><br />
        
        <asp:TextBox runat="server" ID="txtSearch"></asp:TextBox><asp:Button runat="server" ID="btnSearch" Text="搜尋" OnClick="btnSearch_Click" /> <br />

        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
            </ItemTemplate>
        </asp:Repeater>




    </form>
</body>
</html>
