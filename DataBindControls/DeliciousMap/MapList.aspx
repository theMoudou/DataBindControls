<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MapList.aspx.cs" Inherits="DeliciousMap.MapList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .Pager > a {
        margin: 5px;
    }
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

    <%--目前在第二頁--%>
    <div class="Pager">
    <a runat="server" id="aLinkFirst" href="MapList.aspx?Index=1"> 第一頁 </a>
    <a runat="server" id="aLinkPrev"  href="MapList.aspx?Index=1"> 上一頁 </a>
    <a runat="server" id="aLinkPage1" href="MapList.aspx?Index=1"> 1 </a>
    
    <a runat="server" id="aLinkPage2" href="">2</a>

    <a runat="server" id="aLinkPage3" href="MapList.aspx?Index=3">3</a>
    <a runat="server" id="aLinkPage4" href="MapList.aspx?Index=4">4</a>
    <a runat="server" id="aLinkPage5" href="MapList.aspx?Index=5">5</a>
    <a runat="server" id="aLinkNext"  href="MapList.aspx?Index=3"> 下一頁 </a>
    <a runat="server" id="aLinkLast"  href="MapList.aspx?Index=10"> 最未頁 </a>
    </div>

</asp:Content>
