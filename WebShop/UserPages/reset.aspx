<%@ Page Title="" Language="C#" MasterPageFile="~/BookStore.Master" AutoEventWireup="true" CodeBehind="reset.aspx.cs" Inherits="WebShop.WebForm15" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/reset.css" rel="stylesheet" />
    <meta http-equiv="Cache-Control" content="no-store" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-page-wrapper">

        <div id="left-panel">
            <br />
            <h3 style="text-align: center;">ZABORAVLJENA LOZINKA</h3>
            <div style="width: 350px; height: auto; text-align: left; margin-left: auto; margin-right: auto;">
                Za promenu svoje lozinke, upišite email adresu i pritisnite dugme reset. Na unetu adresu biće Vam prosleđen e-mail sa linkom za promenu lozinke.
            </div>
            <br />

            <table style="width: 350px; height: auto; text-align: left; margin-left: auto; margin-right: auto;">
                <tr>
                    <td>
                        Vaš E-mail:
                    </td>
                    <td>
                       
                    </td>
                    
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="emailResetTXT" runat="server" Width="157px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Morate uneti email adresu!" ControlToValidate="emailResetTXT" ForeColor="#CC373E" Text="*" Display="Dynamic"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Pogresan format unosa email adrese!" ControlToValidate="emailResetTXT" ForeColor="#CC373E" Display="Dynamic" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$" Text="*"></asp:RegularExpressionValidator>
                    </td>
                    <td style="text-align:right;">
                        <asp:Button ID="resetBTN" runat="server" Text="Reset" style="margin-left: 0px" Width="74px" OnClick="resetBTN_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ForeColor="#CC373E" ID="pogresanLBL" runat="server" ></asp:Label>
                    </td>
                 </tr>
                <tr>
                    <td>
                        <asp:ValidationSummary ForeColor="#CC373E" ID="ValidationSummary1" runat="server" />
                    </td colspan="2">
                </tr>
            </table>
        </div>
    
    <div id="right-panel">
                    <h3 style="margin-left:10px">NAJPRODAVANIJE KNJIGE</h3>
            <asp:Panel ID="rightPanel" runat="server"></asp:Panel>
    </div>
        </div>
</asp:Content>
