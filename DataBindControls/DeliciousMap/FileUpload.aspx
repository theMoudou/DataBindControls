<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="DeliciousMap.FileUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        請輸入存檔路徑 <asp:TextBox runat="server"></asp:TextBox>
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" /><asp:Label runat="server" ID="lblMsg" ForeColor="Red" />
        <br />
        <asp:FileUpload ID="FileUpload2" runat="server" /><asp:Label runat="server" ID="lblMsg2" ForeColor="Red" />
        <br />
        <asp:FileUpload ID="FileUpload3" runat="server" /><asp:Label runat="server" ID="lblMsg3" ForeColor="Red" />
        <br />
        <asp:FileUpload ID="FileUpload4" runat="server" /><asp:Label runat="server" ID="lblMsg4" ForeColor="Red" />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        
    </form>
</body>
</html>
