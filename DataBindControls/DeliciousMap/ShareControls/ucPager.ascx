<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPager.ascx.cs" Inherits="DeliciousMap.ShareControls.ucPager" %>

<div class="Pager">
    <a runat="server" id="aLinkFirst" href="MapList.aspx?Index=1">第一頁 </a>
    <a runat="server" id="aLinkPrev" href="MapList.aspx?Index=1">上一頁 </a>
    <a runat="server" id="aLinkPage1" href="MapList.aspx?Index=1">1 </a>

    <a runat="server" id="aLinkPage2" href="">2</a>

    <a runat="server" id="aLinkPage3" href="MapList.aspx?Index=3">3</a>
    <a runat="server" id="aLinkPage4" href="MapList.aspx?Index=4">4</a>
    <a runat="server" id="aLinkPage5" href="MapList.aspx?Index=5">5</a>
    <a runat="server" id="aLinkNext" href="MapList.aspx?Index=3">下一頁 </a>
    <a runat="server" id="aLinkLast" href="MapList.aspx?Index=10">最未頁 </a>
</div>
