<%@ Page Title="" Language="C#" MasterPageFile="~/BookStore.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebShop.WebForm14" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Cache-Control" content="no-store" />
    <link href="/css/index.css" rel="stylesheet" />
    <script src="/js/jquery-1.11.1.min.js"></script>
    <script src="/js/jquery-ui.min.js"></script>
    <script src="/js/cyclePlugin.js"></script>
    <script src="/js/slajder.js"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-page-wrapper">

        <div id="left-panel">
            <div id="slajder-wrapper">
                <div id="slajder">
                    <div class="itemi">
                        <asp:Panel ID="Panel1" Width="600px" Height="360px" runat="server">
                        </asp:Panel>
                    </div>
                    <div class="itemi">
                        <asp:Panel ID="Panel2" Width="600px" Height="360px" runat="server">
                        </asp:Panel>
                    </div>
                    <div class="itemi">
                        <asp:Panel ID="Panel3" Width="600px" Height="360px" runat="server">
                        </asp:Panel>
                    </div>
                    <div class="itemi">
                        <asp:Panel ID="Panel4" Width="600px" Height="360px" runat="server">
                        </asp:Panel>
                    </div>
                    <div class="itemi">
                        <asp:Panel ID="Panel5" Width="600px" Height="360px" runat="server">
                        </asp:Panel>
                    </div>
                </div>
                <!--Kraj--Itema-->
                <div style="margin-left:150px;" id="pager"></div>
            </div>
            <div id="sadrzaj">
                <asp:Panel ID="panelSadrzaj" runat="server"></asp:Panel>
            </div>
        </div>
        <div id="right-panel">
            <h3 style="margin-left: 10px">NAJPRODAVANIJE KNJIGE</h3>
            <asp:Panel ID="rightPanel" runat="server"></asp:Panel>
        </div>
    </div>
</asp:Content>
