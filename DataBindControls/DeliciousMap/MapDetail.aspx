<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MapDetail.aspx.cs" Inherits="DeliciousMap.MapDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table border="1" cellpadding="0">
        <tr>
            <th>CreateDate</th>
            <td>
                <asp:Literal runat="server" ID="ltlCreateDate"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th>Title </th>
            <td>
                <asp:Literal runat="server" ID="ltlTitle"></asp:Literal></td>
        </tr>
        <tr>
            <th>Longitude  Latitude</th>
            <td>
                <asp:Literal runat="server" ID="ltlLongitude"></asp:Literal>
                <asp:Literal runat="server" ID="ltlLatitude"></asp:Literal>
            </td>
        </tr>
        <tr>
            <th>CoverImage</th>
            <td>
                <a runat="server" id="aLinkPic" title="點我觀看原圖 (另開新視窗)" target="_blank">
                    <img runat="server" id="imgCoverImage" width="450" height="300" />
                </a>
            </td>
        </tr>
        <tr>
            <th>Body</th>
            <td>
                <asp:Literal runat="server" ID="ltlBody"></asp:Literal></td>
        </tr>
    </table>

    <a href="MapList.aspx"> 回前頁 </a>
</asp:Content>
