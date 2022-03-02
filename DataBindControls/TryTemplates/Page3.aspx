<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page3.aspx.cs" Inherits="TryTemplates.Page3" %>

<%@ Register Src="~/ucDynamicControls.ascx" TagPrefix="uc1" TagName="ucDynamicControls" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>動態控制項</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:ucDynamicControls runat="server" id="ucDynamicControls" />
    </form>
</body>
</html>
