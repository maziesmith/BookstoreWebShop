<%@ Page Title="" Language="C#" MasterPageFile="~/BookStore.Master"  AutoEventWireup="true" CodeBehind="IzmeniKnjigu.aspx.cs" Inherits="WebShop.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/izmenaKnjige.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-page-wrapper">
        <div id="left-panel">
            <br />

            <table>
                <tr>
                    <td colspan="2" style="text-align:center">
                        <b>
                            Izmena postojecih knjiga
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
                        <asp:TextBox ID="izmeniNaslovTXT" runat="server" Width="170px"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="izmeniNaslovTXT" ForeColor="#CC373E" Text="*" runat="server" ErrorMessage="Morate uneti naslov knjige!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td class="auto-style2">
                        Autor:
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="izmeniAutorTXT" runat="server" Width="170px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="izmeniAutorTXT" ForeColor="#CC373E" Text="*" runat="server" ErrorMessage="Morate uneti ime autora!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                                <tr>
                    <td class="auto-style2">
                        Izdavac:
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="izmeniIzdavacTXT" runat="server" Width="170px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="izmeniIzdavacTXT" ForeColor="#CC373E" Text="*" runat="server" ErrorMessage="Morate uneti ime izdavaca!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                                <tr>
                    <td class="auto-style2">
                        ISBN broj:
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="izmeniIsbnTXT" runat="server" Width="170px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="izmeniIsbnTXT" ForeColor="#CC373E" Text="*" runat="server" ErrorMessage="Morate uneti ISBN broj knjige!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                                <tr>
                    <td class="auto-style2">
                        Opis:
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="izmeniOpisTXT" runat="server" Height="80px" MaxLength="300" Rows="10" TextMode="MultiLine" Width="170px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="izmeniOpisTXT" ForeColor="#CC373E" Text="*" runat="server" ErrorMessage="Morate uneti opis knjige!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                                <tr>
                    <td class="auto-style2">
                        Slika:
                    </td>
                    <td class="auto-style3">
                        <asp:FileUpload ID="izmeniFileUpload" runat="server" /><asp:CustomValidator ID="CustomValidator1" ControlToValidate="izmeniFileUpload" runat="server" ForeColor="#CC373E" OnServerValidate="CustomValidator1_ServerValidate" Text="*" ></asp:CustomValidator>
                    </td>
                </tr>
                                <tr>
                    <td class="auto-style2">
                        Tip Knjige:
                    </td>
                    <td>
                        <asp:DropDownList ID="izmeniTipDDL" runat="server" Width="170px">
                            <asp:ListItem Value="-1" Text="Izaberite Tip"></asp:ListItem>
                            <asp:ListItem Value="domaca" Text="Domaca Knjiga"></asp:ListItem>
                            <asp:ListItem Value="strana" Text="Strana Knjiga"></asp:ListItem>
                        </asp:DropDownList><asp:CustomValidator ID="CustomValidator2" ControlToValidate="izmeniTipDDL" OnServerValidate="CustomValidator2_ServerValidate" Text="*" runat="server" ErrorMessage="Morate izabrati Tip Knjige!"></asp:CustomValidator>
                    </td>
                </tr>
                                <tr>
                    <td class="auto-style2">
                        Cena:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="izmeniCenaTXT" runat="server" Width="170px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" ControlToValidate="izmeniCenaTXT" ForeColor="#CC373E" Text="*" runat="server" ErrorMessage="Morate uneti cenu!"></asp:RequiredFieldValidator><asp:CompareValidator ControlToValidate="izmeniCenaTXT" Display="Dynamic" ForeColor="#CC373E" Text="*" Type="Double" Operator="DataTypeCheck" ID="CompareValidator1" runat="server" ErrorMessage="Cena mora biti broj. Npr: 10.00"></asp:CompareValidator>
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
                                <asp:TextBox ID="izmeniSnizenaCenaTXT" runat="server" Width="170px"></asp:TextBox><asp:RequiredFieldValidator  Display="Dynamic" ID="RequiredFieldValidator7" ControlToValidate="izmeniSnizenaCenaTXT" ForeColor="#CC373E" Text="*" runat="server" ErrorMessage="Morate uneti snizenu cenu!"></asp:RequiredFieldValidator><asp:CompareValidator Display="Dynamic" ControlToValidate="izmeniSnizenaCenaTXT" ForeColor="#CC373E" Text="*" Type="Double" Operator="DataTypeCheck" ID="CompareValidator2" runat="server" ErrorMessage="Snizena cena mora biti broj. Npr: 10.00"></asp:CompareValidator>
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
                        <asp:Button ID="Button1" runat="server" Text="Izmeni" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="right-panel">

        </div>
    </div>
</asp:Content>
