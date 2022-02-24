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
        <asp:TextBox runat="server" ID="date" TextMode="Date" Text="2022-02-22" />

        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnPreRender="Repeater1_PreRender" OnItemCommand="Repeater1_ItemCommand">
            <ItemTemplate>
                <div class="c1">
                <asp:Literal runat="server" ID="ltl1"></asp:Literal>
                    &nbsp;
                    &nbsp;
                    &nbsp;
                <asp:Literal runat="server" ID="ltlID" Text='<%#Eval("ID") %>'></asp:Literal>
                    <asp:TextBox runat="server" ID="txtName" Text='<%# Eval("Name") %>'></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtMobile" Text='<%# Eval("Mobile") %>'></asp:TextBox>
                    <asp:TextBox runat="server" ID="txtImagePath" Text='<%# Eval("ImagePath") %>'></asp:TextBox>


                    <%# Eval("Birthday", "{0:yyyy/MM/dd}") %>

                    <asp:Literal runat="server" ID="ltlMobile" />
                    <asp:Button runat="server" Text="刪除" CommandName="DeleteButton" CommandArgument='<%# Eval("ID") %>' />
                    <asp:Button runat="server" Text="編輯" CommandName="EditButton" CommandArgument='<%# Eval("ID") %>' />
                </div>
            </ItemTemplate>
            
            <HeaderTemplate>
                <div> ID / Name / Birthday </div>
            </HeaderTemplate>
        </asp:Repeater>

        <br />
        <asp:Label runat="server" ID="lbl"></asp:Label>
    </form>
</body>
</html>
