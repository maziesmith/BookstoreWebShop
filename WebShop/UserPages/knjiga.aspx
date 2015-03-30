<%@ Page Title="" Language="C#" MasterPageFile="~/BookStore.Master" AutoEventWireup="true" CodeBehind="knjiga.aspx.cs" Inherits="WebShop.WebForm11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/knjiga.css" rel="stylesheet" />
    <meta http-equiv="Cache-Control" content="no-store" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-page-wrapper">

        <div id="left-panel">
            
            <asp:Panel ID="panelKnjiga" runat="server"></asp:Panel>
            
        </div>
        <div id="right-panel">

            <h3 style="margin-left:10px">NAJPRODAVANIJE KNJIGE</h3>
            <asp:Panel ID="rightPanel" runat="server"></asp:Panel>
        </div>
    </div>
</asp:Content>
