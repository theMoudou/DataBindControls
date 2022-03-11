<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MapList.aspx.cs" Inherits="DeliciousMap.MapList" %>

<%@ Register Src="~/ShareControls/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .Pager > a {
            margin: 5px;
        }

        .SearchPanel {
            border: 1px solid black;
        }

        .SearchPanel > label {
            font-size: large;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="SearchPanel">
        <label for="<% = this.txtKeyword.ClientID %>">
            關鍵字 
        </label>
        <asp:TextBox runat="server" ID="txtKeyword"></asp:TextBox>
        
        <br />
        <asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="btnSearch_Click" /><br />
    </div>

    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <div class="CardList">
                <p>
                    <a href="MapDetail.aspx?ID=<%# Eval("ID") %>" title="前往內容：<%# Eval("Title") %>">
                        <%# Eval("Title") %> 
                    </a>
                </p>
                <asp:PlaceHolder runat="server" Visible='<%# 
                    !string.IsNullOrWhiteSpace(Eval("CoverImage") as string) 
                %>'>
                    <p>
                        <a href="MapDetail.aspx?ID=<%# Eval("ID") %>" title="前往內容：<%# Eval("Title") %>">
                            <img src="<%# Eval("CoverImage") %>" width="200" height="160" />
                        </a>
                    </p>
                </asp:PlaceHolder>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:PlaceHolder runat="server" ID="plcEmpty" Visible="false">
        <p>尚未有資料 </p>
    </asp:PlaceHolder>

    <%--<div class="Pager">
        <a runat="server" id="aLinkFirst" href="MapList.aspx?Index=1">第一頁 </a>
        <a runat="server" id="aLinkPrev" href="MapList.aspx?Index=1">上一頁 </a>
        <a runat="server" id="aLinkPage1" href="MapList.aspx?Index=1">1 </a>

        <a runat="server" id="aLinkPage2" href="">2</a>

        <a runat="server" id="aLinkPage3" href="MapList.aspx?Index=3">3</a>
        <a runat="server" id="aLinkPage4" href="MapList.aspx?Index=4">4</a>
        <a runat="server" id="aLinkPage5" href="MapList.aspx?Index=5">5</a>
        <a runat="server" id="aLinkNext" href="MapList.aspx?Index=3">下一頁 </a>
        <a runat="server" id="aLinkLast" href="MapList.aspx?Index=10">最未頁 </a>
    </div>--%>

    <uc1:ucPager runat="server" id="ucPager" PageSize="2" />

    <script>
        var initObj = {
            txtSearchID: "<%= this.txtKeyword.ClientID %>",
            btnSearchID: "<%= this.btnSearch.ClientID %>"
        };
    </script>
    <script src="JavaScript/Modules/MapList.js"></script>
</asp:Content>
