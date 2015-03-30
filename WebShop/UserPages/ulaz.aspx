<%@ Page Title=""  Language="C#" MasterPageFile="~/BookStore.Master" AutoEventWireup="true" CodeBehind="ulaz.aspx.cs" Inherits="WebShop.WebForm13" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/ulaz.css" rel="stylesheet" />
    <meta http-equiv="Cache-Control" content="no-store" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-page-wrapper">

        <div id="left-panel">
           <h3 style="text-align: center;">ULAZ ZA KORISNIKE</h3>
            <div style="width: 350px; height: auto; text-align: left; margin-left: auto; margin-right: auto;">
                Kako biste ušli na svoj nalog, upišite email adresu i lozinku koje ste koristili prilikom registracije, zatim pritisnite dugme ULAZ.
            </div>
            <br />
            <table style="width: 350px; height: auto; text-align: left; margin-left: auto; margin-right: auto;">
                <tr>
                    <td>
                        Vaš E-mail:
                    </td>
                    <td>
                        Vaša lozinka:
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="emailLoginTXT" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="lozinkaLoginTXT" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center">
                        <br />
                        <asp:Label CssClass="pogresno" ID="pogresnoLBL" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center">
                        <asp:Button ID="loginBTN" runat="server" Text="ULAZ" OnClick="loginBTN_Click" Width="100px" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="right-panel">
            <h3 style="margin-left:10px">NAJPRODAVANIJE KNJIGE</h3>
            <asp:Panel ID="rightPanel" runat="server"></asp:Panel>
        </div>
    </div>
</asp:Content>
