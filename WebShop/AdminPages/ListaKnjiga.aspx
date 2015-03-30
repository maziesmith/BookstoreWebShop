<%@ Page Title="" Language="C#" MasterPageFile="~/BookStore.Master" AutoEventWireup="true" CodeBehind="ListaKnjiga.aspx.cs" Inherits="WebShop.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/listaKnjiga.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-page-wrapper">
                            <table style=" margin-top:20px;margin-left:auto; margin-right:auto;">
                <tr>
                    <td>
                        <asp:Button ID="dodajKnjiguBTN" CausesValidation="false" runat="server" Text="Dodaj Knjigu" OnClick="dodajKnjiguBTN_Click" />
                    </td>
                     <td>
                        <asp:Button ID="ListaKorisnikaBTN" runat="server" Text="Lista Korisnika" OnClick="ListaKorisnikaBTN_Click" />
                    </td>

                     <td>
                        <asp:Button ID="adminPanelBTN" CausesValidation="false" runat="server" Text="Admin Panel" OnClick="adminPanelBTN_Click" />
                    </td>
                     <td>
                        <asp:Button ID="pocetnBTN" CausesValidation="false" runat="server" Text="Podesavanja Pocetne" OnClick="pocetnBTN_Click" />
                    </td>
                </tr>
            </table>
        
            <h3 style="text-align:center">Lista knjiga</h3>
            <asp:GridView ID="GridView1" CssClass="grid" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" DataKeyNames="ID" ForeColor="Black" OnRowCommand="GridView1_RowCommand" Width="980px" AllowPaging="True" PageSize="16" CellSpacing="2" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" >
                    <HeaderStyle Width="10px" />
                    <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Ime" HeaderText="Naslov Knjige" SortExpression="Ime" >
                    <HeaderStyle Width="120px" />
                    <ItemStyle Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Autor" HeaderText="Autor" SortExpression="Autor" />
                    <asp:BoundField DataField="Izdavac" HeaderText="Izdavac" SortExpression="Izdavac" />
                    <asp:BoundField DataField="Cena" HeaderText="Cena" SortExpression="Cena" />
                    <asp:BoundField DataField="CenaSnizena" HeaderText="CenaSnizena" SortExpression="CenaSnizena" />
                    <asp:BoundField DataField="TipKnjige" HeaderText="TipKnjige" SortExpression="TipKnjige" />
                    <asp:BoundField DataField="Akcija" HeaderText="Akcija" SortExpression="Akcija" />
                    <asp:TemplateField HeaderText="Izmeni" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="Izmeni" Text="Izmeni"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Obrisi" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Obrisi" Text="Obrisi"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            

    </div>
</asp:Content>
