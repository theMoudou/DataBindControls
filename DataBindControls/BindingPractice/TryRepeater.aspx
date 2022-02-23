<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryRepeater.aspx.cs" Inherits="BindingPractice.TryRepeater" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .c1 { color: blue; }
        .c2 { color: green; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="c1">
                <%# Eval("ID") %>
                <%# Eval("Name") %>
                <%# Eval("Birthday", "{0:yyyy/MM/dd}") %>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div class="c2">
                <%# Eval("ID") %>
                <%# Eval("Name") %>
                </div>
            </AlternatingItemTemplate>
            <HeaderTemplate>
                <div> ID / Name / Birthday </div>
            </HeaderTemplate>
            <FooterTemplate>
                <div> [ID] / [Name] / Birthday </div>
            </FooterTemplate>
            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
