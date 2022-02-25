<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapContentEditor.aspx.cs" Inherits="DeliciousMap.BackAdmin.MapContentEditor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <span>經度值為 -180~180 ，精度至小數 6 位</span>
        <span>緯度值為  -90~ 90 ，精度至小數 6 位</span>
        <asp:HiddenField runat="server" ID="hfID" />
        <table>
            <tr> 
                <th> 標題 (*) </th> 
                <td> <asp:TextBox runat="server" ID="txtTitle" /> </td>
            </tr>
            <tr> 
                <th> 內文 (*) </th> 
                <td> <asp:TextBox runat="server" ID="txtBody" TextMode="MultiLine" /> </td>
            </tr>
            <tr> 
                <th> 緯度 </th> 
                <td> <asp:TextBox runat="server" ID="txtLatitude" /> </td>
            </tr>
            <tr> 
                <th> 經度 </th> 
                <td> <asp:TextBox runat="server" ID="txtLongitude" /> </td>
            </tr>
        </table>
        <asp:Button runat="server" ID="btnSave" Text="儲存" OnClick="btnSave_Click" /><br />
        <asp:Literal runat="server" ID="ltlMessage"></asp:Literal>
    </form>
</body>
</html>
