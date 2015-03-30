<%@ Page Title="" Language="C#" MasterPageFile="~/BookStore.Master" AutoEventWireup="true" CodeBehind="resetemail.aspx.cs" Inherits="WebShop.WebForm16" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"
    <meta http-equiv="Cache-Control" content="no-store" />>
    <link href="../css/resetemail.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-page-wrapper">

        <div id="left-panel">
            <br />
            <h3 style="text-align: center;">NOVA LOZINKA</h3>
            <div style="width: 350px; height: auto; text-align: left; margin-left: auto; margin-right: auto;">
                Upišite svoju novu lozinku i potvrdite je!
            </div>
            <br />
            <table style="width: 350px; height: auto; text-align: left; margin-left: auto; margin-right: auto;">
                <tr>
                    <td>Novu lozinku:</td>
                    <td>
                        <asp:TextBox ID="novaLozinkaTXT" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" ForeColor="#CC373E" ControlToValidate="novaLozinkaTXT" Display="Dynamic" runat="server" ErrorMessage="Niste uneli lozinku!"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" ControlToValidate="novaLozinkaTXT" MinimumValue="8" MaximumValue="16" Text="*" ForeColor="#CC373E" Type="String" runat="server" Display="Dynamic" ErrorMessage="Morate uneti izmedju 8 i 16 karaktera za lozinku!"></asp:RangeValidator>
                    </td>

                </tr>
                <tr>
                    <td>Ponovite novu lozinku:</td>
                    <td>
                        <asp:TextBox ID="novaLozinkaPotvrdaTXT" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" Display="Dynamic" ForeColor="#CC373E" ControlToValidate="novaLozinkaTXT" runat="server" ErrorMessage="Niste uneli novu lozinku!"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator2" ControlToValidate="novaLozinkaTXT" MinimumValue="8" MaximumValue="16" Type="String" Text="*" ForeColor="#CC373E" Display="Dynamic" runat="server" ErrorMessage="Morate uneti izmedju 8 i 16 karaktera za lozinku!"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ValidationSummary ForeColor="#CC373E" ID="ValidationSummary1" runat="server" />
                        
                    </td>

                </tr>
                <tr>
                    <td colspan="2" style="text-align:center">
                        <asp:Button ID="Button1" runat="server" Text="Promeni lozinku" OnClick="Button1_Click" />
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
