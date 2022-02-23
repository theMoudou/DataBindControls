<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TablePractice1.aspx.cs" Inherits="BindingPractice.TablePractice1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <style>
        th {
            color: black;
            font-family: Consolas SimHei;
            font-size: 24pt;
        }

        td {
            font-family: Consolas;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table border="1" cellspacing="0">
            <tr>
                <th>學號</th>
                <th>姓名</th>
                <th>電話</th>
            </tr>
            <asp:Literal ID="ltlTableBody" runat="server"></asp:Literal>
        </table>
    </form>
</body>
</html>
