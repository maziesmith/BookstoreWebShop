<%@ Page Title="" Language="C#" MasterPageFile="~/BookStore.Master" AutoEventWireup="true" CodeBehind="korpa.aspx.cs" Inherits="WebShop.WebForm12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/korpa.css" rel="stylesheet" />
    <meta http-equiv="Cache-Control" content="no-store" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-page-wrapper">

        <div id="left-panel">
            <h3 style="text-align: center;">KNJIGE U KORPI</h3>
            <div style="text-align:center">
                 <asp:Label ID="warninglabel" runat="server" CssClass="warning-label" Font-Size="X-Large"></asp:Label>
            </div>
           

            <asp:Panel ID="panelKorpa" runat="server"></asp:Panel>
            <asp:Panel ID="futerpanel" Height="25px" HorizontalAlign="Center" Width="590px" runat="server"></asp:Panel>
        </div>
        <div id="right-panel">
            <h3 style="text-align: center; margin-right: 30px; color: #808080">VAŠA KORPA</h3>
            <div id="right-wrapper1">
                <div>
                    <table style="float: right">
                        <tr>
                            <td colspan="2" style="text-align: right; text-decoration: double; color: #808080"><b>BROJ ARTIKALA</b>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: right;">
                                <asp:Label CssClass="korpa-lbl" ID="brojArtikalaLBL" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="float: right; color: #808080"><b>CENA UKUPNO</b>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: right;">
                                <asp:Label CssClass="korpa-lbl" ID="ukupnaCenaLBL" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: right; color: #808080"><b>UŠTEDA</b>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;" colspan="2">
                                <asp:Label CssClass="korpa-lbl" ID="ustedaLBL" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <div style="text-align: center;">
                <br />
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <br />
                <asp:LinkButton ID="poruci" CssClass="poruci" CausesValidation="false" runat="server" OnClick="poruci_Click">Poruči artikle</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
