<%@ Page Title="" Language="C#" MasterPageFile="~/BookStore.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="WebShop.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/AdminPage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
        <div class="content-page-wrapper">
            <table style=" margin-top:20px;margin-left:auto; margin-right:auto;">
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
                        <asp:Button ID="pocetnBTN" runat="server" Text="Podesavanja Pocetne" OnClick="pocetnBTN_Click" />
                    </td>
                </tr>
            </table>
            <h3 style="margin-left:auto; margin-right:auto; text-align:center;">PORUČENE KNJIGE</h3>
            <br />
            <div style="text-align:center">
            <asp:Label ID="warninglabel" runat="server" CssClass="warning-label" Font-Size="X-Large"></asp:Label>
                </div>
            <asp:GridView CssClass="gridview" AllowPaging="True" HorizontalAlign="Center" ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnRowCommand="GridView1_RowCommand" DataKeyNames="ID" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ReadOnly="True" />
                    <asp:BoundField DataField="KorisnikID" HeaderText="KorisnikID" SortExpression="KorisnikID" />
                    <asp:BoundField DataField="KnjigaID" HeaderText="KnjigaID" SortExpression="KnjigaID" />
                    <asp:BoundField DataField="Kupljena" HeaderText="Kupljena" SortExpression="Kupljena" />
                    <asp:BoundField DataField="AdminID" HeaderText="AdminID" SortExpression="AdminID" />
                    <asp:BoundField DataField="Poruceno" HeaderText="Poruceno" SortExpression="Poruceno" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#((GridViewRow)Container).RowIndex%>' CommandName="Isporuci" CausesValidation="false" Text="Isporuci"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="Gray" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>

        </div>
    
</asp:Content>
