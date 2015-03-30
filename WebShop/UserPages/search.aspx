<%@ Page Title="" Language="C#" MasterPageFile="~/BookStore.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="WebShop.WebForm19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/search.css" rel="stylesheet" />
    <meta http-equiv="Cache-Control" content="no-store" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="content-page-wrapper">

        <div id="left-panel">
                        <h3 style="text-align: center;">PRETRAGA KNJIGA</h3>
            <div style="text-align:center">
            <asp:Label ID="warninglabel" runat="server" CssClass="warning-label" Font-Size="X-Large"></asp:Label>
                </div>
            <asp:Panel ID="domaceKnjigePanel" runat="server"></asp:Panel>
            <asp:Panel ID="futerpanel" runat="server" Height="25px" HorizontalAlign="Center" Width="590px"></asp:Panel>
            </div>       
        <div id="right-panel">
                        <h3 style="margin-left:10px">NAJPRODAVANIJE KNJIGE</h3>
            <asp:Panel ID="rightPanel" runat="server"></asp:Panel>
        </div>
            </div>
</asp:Content>
