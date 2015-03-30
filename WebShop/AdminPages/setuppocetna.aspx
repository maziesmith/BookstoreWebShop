<%@ Page Title="" Language="C#" MasterPageFile="~/BookStore.Master" AutoEventWireup="true" CodeBehind="setuppocetna.aspx.cs" Inherits="WebShop.WebForm18" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/AdminPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-page-wrapper">
        <table style="margin-top: 20px; margin-left: auto; margin-right: auto;">
            <tr>
                <td>
                    <asp:Button ID="dodajKnjiguBTN" runat="server" Text="Dodaj Knjigu" OnClick="dodajKnjiguBTN_Click" />
                </td>
                <td>
                    <asp:Button ID="ListaKorisnikaBTN" runat="server" Text="Lista Korisnika" OnClick="ListaKorisnikaBTN_Click" />
                </td>
                <td>
                    <asp:Button ID="ListaKnjigaBTN" runat="server" Text="Lista Knjiga" OnClick="ListaKnjigaBTN_Click" />
                </td>
                <td>
                    <asp:Button ID="adminPanelBTN1" CausesValidation="false" runat="server" Text="Admin Panel" OnClick="adminPanelBTN1_Click" />
                </td>
            </tr>
        </table>
        
        <table style="margin-top: 20px; margin-left: auto; margin-right: auto;">
            <tr>
                <td style="text-align: center" colspan="3">UNESITE ID KNJIGE NA ŽELJENO MESTO
                </td>
            </tr>
            <tr>
                <td style="text-align: center" colspan="3">SLAJDER
                </td>
            </tr>
            <tr>
                <td>Slajd 1:
                </td>
                <td>
                    <asp:TextBox ID="slajd1TXT" runat="server"></asp:TextBox>
                </td>
                <td>
                   
                </td>
            </tr>
            <tr>
                <td>Slajd 2:
                </td>
                <td>
                    <asp:TextBox ID="slajd2TXT" runat="server"></asp:TextBox>
                </td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td>Slajd 3:
                </td>
                <td>
                    <asp:TextBox ID="slajd3TXT" runat="server"></asp:TextBox>
                </td>
                <td>
                   
                </td>
            </tr>
            <tr>
                <td>Slajd 4:
                </td>
                <td>
                    <asp:TextBox ID="slajd4TXT" runat="server"></asp:TextBox>
                </td>
                <td>
                  
                </td>
            </tr>
            <tr>
                <td>Slajd 5:
                </td>
                <td>
                    <asp:TextBox ID="slajd5TXT" runat="server"></asp:TextBox>
                </td>
                <td>
                  
                </td>
            </tr>
            <tr>
                <td style="text-align: center" colspan="3">SADRZAJ
                </td>
            </tr>
            <tr>
                <td>Polje 1:
                </td>
                <td>
                    <asp:TextBox ID="polje1TXT" runat="server"></asp:TextBox>
                </td>
                <td>
                  
                </td>
            </tr>
            <tr>
                <td>Polje 2:
                </td>
                <td>
                    <asp:TextBox ID="polje2TXT" runat="server"></asp:TextBox>
                </td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td>Polje 3:
                </td>
                <td>
                    <asp:TextBox ID="polje3TXT" runat="server"></asp:TextBox>
                </td>
                <td>
                   
                </td>
            </tr>
            <tr>
                <td>Polje 4:
                </td>
                <td>
                    <asp:TextBox ID="polje4TXT" runat="server"></asp:TextBox>
                </td>
                <td>
                   
                </td>
            </tr>
            <tr>
                <td>Polje 5:
                </td>
                <td>
                    <asp:TextBox ID="polje5TXT" runat="server"></asp:TextBox>
                </td>
                <td>
                  
                </td>
            </tr>
            <tr>
                <td>Polje 6:
                </td>
                <td>
                    <asp:TextBox ID="polje6TXT" runat="server"></asp:TextBox>
                </td>
                <td>
                   
                </td>
            </tr>
                         <tr>
                <td style="text-align:center" colspan="3">

                    <asp:Label ID="Label1" ForeColor="Red" runat="server" ></asp:Label>
                </td>
            </tr>
             <tr>
                <td style="text-align:center" colspan="3">

                    <asp:Button ID="Button1" runat="server" Text="Sacuvaj" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
