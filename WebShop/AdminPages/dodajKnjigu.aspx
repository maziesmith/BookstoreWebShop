<%@ Page Title="" Language="C#" MasterPageFile="~/BookStore.Master" AutoEventWireup="true" CodeBehind="dodajKnjigu.aspx.cs" Inherits="WebShop.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/dodavanjeKnjiga.css" rel="stylesheet" />
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-page-wrapper">
                    <table style=" margin-top:20px;margin-left:auto; margin-right:auto;">
                <tr>
                    <td>
                        <asp:Button ID="ListaKorisnikaBTN" CausesValidation="false" runat="server" Text="Lista Korisnika" OnClick="ListaKorisnikaBTN_Click" />
                    </td>
                    <td>
                        <asp:Button ID="ListaKnjigaBTN" CausesValidation="false" runat="server" Text="Lista Knjiga" OnClick="ListaKnjigaBTN_Click" />
                    </td>
                     <td>
                        <asp:Button ID="adminPanelBTN" CausesValidation="false" runat="server" Text="Admin Panel" OnClick="adminPanelBTN_Click" />
                    </td>
                                        <td>
                        <asp:Button ID="pocetnBTN" runat="server" CausesValidation="false"  Text="Podesavanja Pocetne" OnClick="pocetnBTN_Click" />
                    </td>
                </tr>
            </table>
        <div id="left-panel">
            <br />

            <table>
                <tr>
                    <td colspan="2" style="text-align:center">
                        <b>
                            Dodavanje novih knjiga
                        </b>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <br />

                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        Naslov Knjige:
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="addNaslovTXT" runat="server" Width="170px"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="addNaslovTXT" ForeColor="#CC373E" Text="*" runat="server" ErrorMessage="Morate uneti naslov knjige!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td class="auto-style2">
                        Autor:
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="addAutorTXT" runat="server" Width="170px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="addAutorTXT" ForeColor="#CC373E" Text="*" runat="server" ErrorMessage="Morate uneti ime autora!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                                <tr>
                    <td class="auto-style2">
                        Izdavac:
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="addIzdavacTXT" runat="server" Width="170px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="addIzdavacTXT" ForeColor="#CC373E" Text="*" runat="server" ErrorMessage="Morate uneti ime izdavaca!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                                <tr>
                    <td class="auto-style2">
                        ISBN broj:
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="addIsbnTXT" runat="server" Width="170px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="addIsbnTXT" ForeColor="#CC373E" Text="*" runat="server" ErrorMessage="Morate uneti ISBN broj knjige!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                                <tr>
                    <td class="auto-style2">
                        Opis:
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="addOpisTXT" runat="server" Height="80px" MaxLength="300" Rows="10" TextMode="MultiLine" Width="170px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="addOpisTXT" ForeColor="#CC373E" Text="*" runat="server" ErrorMessage="Morate uneti opis knjige!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                                <tr>
                    <td class="auto-style2">
                        Slika:
                    </td>
                    <td class="auto-style3">
                        <asp:FileUpload ID="addFileUpload" runat="server" /><asp:CustomValidator ID="CustomValidator1" ControlToValidate="addFileUpload" runat="server" ForeColor="#CC373E" OnServerValidate="CustomValidator1_ServerValidate" Text="*" ></asp:CustomValidator>
                    </td>
                </tr>
                                <tr>
                    <td class="auto-style2">
                        Tip Knjige:
                    </td>
                    <td>
                        <asp:DropDownList ID="addTipDDL" runat="server" Width="170px">
                            <asp:ListItem Value="-1" Text="Izaberite Tip"></asp:ListItem>
                            <asp:ListItem Value="domaca" Text="Domaca Knjiga"></asp:ListItem>
                            <asp:ListItem Value="strana" Text="Strana Knjiga"></asp:ListItem>
                        </asp:DropDownList><asp:CustomValidator ID="CustomValidator2" ControlToValidate="addTipDDL" OnServerValidate="CustomValidator2_ServerValidate" runat="server" ErrorMessage="Morate izabrati Tip Knjige!"></asp:CustomValidator>
                    </td>
                </tr>
                                <tr>
                    <td class="auto-style2">
                        Cena:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="addCenaTXT" runat="server" Width="170px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" ControlToValidate="addCenaTXT" ForeColor="#CC373E" Text="*" runat="server" ErrorMessage="Morate uneti cenu!"></asp:RequiredFieldValidator><asp:CompareValidator ControlToValidate="addCenaTXT" Display="Dynamic" ForeColor="#CC373E" Text="*" Type="Double" Operator="DataTypeCheck" ID="CompareValidator1" runat="server" ErrorMessage="Cena mora biti broj. Npr: 10.00"></asp:CompareValidator>
                    </td>
                </tr>
                                <tr>
                    <td class="auto-style2">
                        Akcija:
                    </td>
                    <td class="auto-style3">
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                    </td>
                </tr>
                      <tr>
                    <td class="auto-style2">
                        Snizena cena:&nbsp;&nbsp;
                    </td>
                    <td class="auto-style3">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="addSnizenaCenaTXT" runat="server" Width="170px"></asp:TextBox><asp:RequiredFieldValidator  Display="Dynamic" ID="RequiredFieldValidator7" ControlToValidate="addSnizenaCenaTXT" ForeColor="#CC373E" Text="*" runat="server" ErrorMessage="Morate uneti snizenu cenu!"></asp:RequiredFieldValidator><asp:CompareValidator Display="Dynamic" ControlToValidate="addSnizenaCenaTXT" ForeColor="#CC373E" Text="*" Type="Double" Operator="DataTypeCheck" ID="CompareValidator2" runat="server" ErrorMessage="Snizena cena mora biti broj. Npr: 10.00"></asp:CompareValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ValidationSummary ForeColor="Red" ID="ValidationSummary1" runat="server" />
                    </td>
                    
                </tr>
                 <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="messageLBL" ForeColor="Red" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="Button1" runat="server" Text="Dodaj knjigu" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="right-panel">

        </div>
    </div>
</asp:Content>
