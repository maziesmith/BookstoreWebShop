<%@ Page Title="" Language="C#" MasterPageFile="~/BookStore.Master" AutoEventWireup="true" CodeBehind="registracija.aspx.cs" Inherits="WebShop.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Cache-Control" content="no-store" />
    <link href="../css/registracija.css" rel="stylesheet" />
    <link href="../css/jquery-ui.min.css" rel="stylesheet" />
    <script src="../js/jquery-1.11.1.min.js"></script>
    <script src="../js/jquery-ui.min.js"></script>
    <script>
        $(function () {
            $('#<%= regDatumRodjenjaTXT.ClientID %>').datepicker();
        });
    </script>
    <style type="text/css">
        .auto-style2 {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-page-wrapper">
        <div id="left-panel">
            <br />
            <div style="width: 350px; height: auto; text-align: left; margin-left: auto; margin-right: auto;">
                <span style="color: #CC373E">REGISTRACIJA</span>
                <br />
                Informacije koje unesete u formular koristićemo isključivo u procesu naručivanja radi provere ispravnosti narudžbine.
                 Vaši podaci ni u kom slučaju neće biti prosleđivani trećim licima.

            </div>
            <br />
            <br />

            <div style="width: 350px; height: auto; text-align: left; margin-left: auto; margin-right: auto;">
                <span style="color: #CC373E">NAPOMENA:</span> Obavezna polja su označena sa <span style="color: #CC373E">*</span>
            </div>
            <br />
            <br />
            <table>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <b style="text-align: center">Osnovne Informacije</b>
                    </td>
                </tr>
                <tr>
                    <td>Ime:
                    </td>
                    <td>
                        <asp:TextBox ID="regImeTXT" runat="server" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" ForeColor="#CC373E" ControlToValidate="regImeTXT" runat="server" ErrorMessage="Morate uneti Ime!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Prezime:
                    </td>
                    <td>
                        <asp:TextBox ID="regPrezimeTXT" runat="server" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" ForeColor="#CC373E" ControlToValidate="regPrezimeTXT" runat="server" ErrorMessage="Morate uneti Prezime!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Datum Rođenja:
                    </td>
                    <td>
                        <asp:TextBox ID="regDatumRodjenjaTXT" runat="server" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" ForeColor="#CC373E" ControlToValidate="regDatumRodjenjaTXT" runat="server" ErrorMessage="Morate izabrati datum rodjenja!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Grad:
                    </td>
                    <td>
                        <asp:TextBox ID="regGradTXT" runat="server" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" ForeColor="#CC373E" ControlToValidate="regGradTXT" runat="server" ErrorMessage="Morate uneti Grad!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Adresa:
                    </td>
                    <td>
                        <asp:TextBox ID="regAdresaTXT" runat="server" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" ForeColor="#CC373E" ControlToValidate="regAdresaTXT" runat="server" ErrorMessage="Morate uneti Adresu!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Broj stana:
                    </td>
                    <td>
                        <asp:TextBox ID="regBrojStanaTXT" runat="server" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="*" ForeColor="#CC373E" ControlToValidate="regBrojStanaTXT" runat="server" ErrorMessage="Morate uneti broj stanovanja!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Poštanski broj:
                    </td>
                    <td>
                        <asp:TextBox ID="regPostanskiBrojTXT" runat="server" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7" Text="*" ForeColor="#CC373E" ControlToValidate="regPostanskiBrojTXT" Display="Dynamic" runat="server" ErrorMessage="Morate uneti postanski broj!"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1" ControlToValidate="regPostanskiBrojTXT" Type="Integer" Text="*" Display="Dynamic" runat="server" Operator="DataTypeCheck" ForeColor="#CC373E" ErrorMessage="Pogresan format unosa postanskog broja. Unesite broj!"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <b>Kontakt Informacije</b>
                    </td>
                </tr>
                <tr>
                    <td>Kontakt Telefon:
                    </td>
                    <td>
                        <asp:TextBox ID="regKontaktTelefonTXT" runat="server" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8" Text="*" ForeColor="#CC373E" ControlToValidate="regKontaktTelefonTXT" Display="Dynamic" runat="server" ErrorMessage="Morate uneti kontakt telefon!"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator2" ControlToValidate="regKontaktTelefonTXT" Type="Integer" Text="*" Display="Dynamic" runat="server" Operator="DataTypeCheck" ForeColor="#CC373E" ErrorMessage="Pogresan format unosa telefonskog broja. Unesite broj bez razmaka i specijalnih karaktera!"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>Email Adresa:
                    </td>
                    <td>
                        <asp:TextBox ID="regEmailTXT" runat="server" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Morate uneti email adresu!" ControlToValidate="regEmailTXT" ForeColor="#CC373E" Text="*" Display="Dynamic"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Pogresan format unosa email adrese!" ControlToValidate="regEmailTXT" ForeColor="#CC373E" Display="Dynamic" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$" Text="*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Potvrdite Email Adresu:
                    </td>
                    <td>
                        <asp:TextBox ID="regEmailPotvrdaTXT12" runat="server" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator10" ForeColor="#CC373E" Display="Dynamic" Text="*" ControlToValidate="regEmailPotvrdaTXT12" runat="server" ErrorMessage="Morate potvrditi email adresu!"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator3" ForeColor="#CC373E" Display="Dynamic" Text="*" ControlToValidate="regEmailPotvrdaTXT12" ControlToCompare="regEmailTXT" runat="server" ErrorMessage="Email adrese se ne podudaraju!"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <b>Izaberite lozinku</b>
                    </td>
                </tr>
                <tr>
                    <td>Lozinka:
                    </td>
                    <td>
                        <asp:TextBox ID="regLozinkaTXT12" runat="server" Width="150px" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator11" Text="*" ForeColor="#CC373E" Display="Dynamic" runat="server" ControlToValidate="regLozinkaTXT12" ErrorMessage="Morate uneti lozinku!"></asp:RequiredFieldValidator><asp:CustomValidator ID="CustomValidator1" runat="server" Text="*" ForeColor="#CC373E" Display="Dynamic" runat="server" ControlToValidate="regLozinkaTXT12" Enabled="true" ValidateEmptyText="true" OnServerValidate="CustomValidator1_ServerValidate" ErrorMessage="Broj karaktera za lozinku mora biti izmedju 8 i 16!"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Potvrdite Lozinku:
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="regLozinkaPotvrdaTXT" runat="server" Width="150px" TextMode="Password"></asp:TextBox><asp:CompareValidator ID="CompareValidator4" runat="server" ControlToCompare="regLozinkaTXT12" ControlToValidate="regLozinkaPotvrdaTXT" Text="*" ForeColor="#CC373E" Display="Dynamic" ErrorMessage="Lozinke se ne poklapaju! Unesite ponovo!"></asp:CompareValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="regLozinkaPotvrdaTXT" Text="*" ForeColor="#CC373E" Display="Dynamic" ErrorMessage="Morate uneti ponovo lozinku!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ValidationSummary CssClass="reg-validator" ID="ValidationSummary1" ForeColor="#CC373E" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label  Visible="false"  ID="porukaLBL" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="Button1" runat="server" Text="Registruj se" OnClick="Button1_Click" />
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
