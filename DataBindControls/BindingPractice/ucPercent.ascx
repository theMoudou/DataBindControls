<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPercent.ascx.cs" Inherits="BindingPractice.ucPercent" %>


<div>
    <asp:TextBox runat="server" ID="txt" TextMode="Number">60</asp:TextBox>
    <asp:Button runat="server" ID="btn" Text="修改" OnClick="btn_Click" />
</div>

<div style="width: 100%; border: 1px solid black;">
    <div style="width: <%= this.ltlPercent.Text %>%; border: 1px solid red; background-color: red; color: white; font-weight: 700;">
        <asp:Literal runat="server" ID="ltlPercent">60</asp:Literal> %
    </div>
</div>

<!--另一個方式-->
<div style="width: 100%; border: 1px solid black;">
    <div runat="server" id="div1" style="border: 1px solid red; background-color: red; color: white; font-weight: 700;">
        <asp:Literal runat="server" ID="ltlPercent2">60</asp:Literal> %
    </div>
</div>