<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="MapDetail.aspx.cs" Inherits="DeliciousMap.BackAdmin.MapDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>打 * 號者為必填(或必選)</p>
    <table>
        <tr>
            <th> 標題 (*) </th>
            <td> <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox> </td>
        </tr>
        <tr>
            <th> 內文 (*) </th>
            <td> <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine"></asp:TextBox> </td>
        </tr>
        <tr>
            <th> 經度 (*) </th>
            <td> <asp:TextBox ID="txtLongitude" runat="server"></asp:TextBox> </td>
        </tr>
        <tr>
            <th> 緯度 (*) </th>
            <td> <asp:TextBox ID="txtLatitude" runat="server"></asp:TextBox> </td>
        </tr>
        <tr>
            <th> 封面圖 (*) </th>
            <td> 
                <asp:FileUpload ID="fuCoverImage" runat="server" />
                <asp:Image ID="imgCoverImage" runat="server" />
            </td>
        </tr>
        <tr>
            <th> 是否顯示 (*) </th>
            <td>
                <asp:CheckBox ID="ckbIsEnable" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label runat="server" ID="lblMsg"></asp:Label>
            </td>
        </tr>
    </table>

    <asp:Button runat="server" ID="btnSave" Text="儲存" OnClick="btnSave_Click" />
    <asp:Button runat="server" ID="btnCancel" Text="取消" OnClick="btnCancel_Click" />
</asp:Content>
