<%@ Page Title="" Language="C#" MasterPageFile="~/BookStore.Master" AutoEventWireup="true" CodeBehind="kontakt.aspx.cs" Inherits="WebShop.WebForm17" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/kontakt.css" rel="stylesheet" />
    <meta http-equiv="Cache-Control" content="no-store" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-page-wrapper">

        <div id="left-panel">
          

            <h3 style="text-align: center;">KONTAKTIRAJTE NAS!</h3>
            <br />
            <table style="width: 350px; height: auto; text-align: left; margin-left: auto; margin-right: auto;">
                <tr>
                    <td>
                        Vaše Ime:
                    </td>
                    <td>
                        <asp:TextBox ID="imeTXT" runat="server" Width="150px"></asp:TextBox><asp:RequiredFieldValidator  ForeColor="#CC373E" Text="*" ID="RequiredFieldValidator1" ControlToValidate="imeTXT" runat="server" ErrorMessage="Morate uneti Ime!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Vaš Email:
                    </td>
                    <td>
                        <asp:TextBox ID="emailTXT" runat="server" Width="150px"></asp:TextBox><asp:RequiredFieldValidator  ForeColor="#CC373E" Text="*" Display="Dynamic" ID="RequiredFieldValidator2" ControlToValidate="imeTXT" runat="server" ErrorMessage="Morate uneti Email aresu!"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="#CC373E" Text="*" Display="Dynamic" ControlToValidate="emailTXT" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$" runat="server" ErrorMessage="Pogresan format adrese!"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Text poruke:
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="messageTXT" runat="server" TextMode="MultiLine" Height="146px" Width="335px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">

                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    <asp:ValidationSummary ForeColor="#CC373E" ID="ValidationSummary1" runat="server" />
                        </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center">
                        <asp:Label ID="messageLBL" ForeColor="#CC373E" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center">
                        <asp:Button ID="Button1" runat="server"  Text="Pošalji" Width="71px" OnClick="Button1_Click" />
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
