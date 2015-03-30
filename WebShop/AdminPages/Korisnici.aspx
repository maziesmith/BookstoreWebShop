<%@ Page Title="" Language="C#" MasterPageFile="~/BookStore.Master" AutoEventWireup="true" CodeBehind="Korisnici.aspx.cs" Inherits="WebShop.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/Korisnici.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="content-page-wrapper">
                              <table style=" margin-top:20px;margin-left:auto; margin-right:auto;">
                <tr>
                    <td>
                        <asp:Button ID="dodajKnjiguBTN" CausesValidation="false" runat="server" Text="Dodaj Knjigu" OnClick="dodajKnjiguBTN_Click" />
                    </td>
                    <td>
                        <asp:Button ID="ListaKorisnikaBTN" Visible="false" CausesValidation="false" runat="server" Text="Lista Korisnika" OnClick="ListaKorisnikaBTN_Click" />
                    </td>
                    <td>
                        <asp:Button ID="ListaKnjigaBTN" CausesValidation="false" runat="server" Text="Lista Knjiga" OnClick="ListaKnjigaBTN_Click" />
                    </td>
                     <td>
                        <asp:Button ID="adminPanelBTN" CausesValidation="false" runat="server" Text="Admin Panel" OnClick="adminPanelBTN_Click" />
                    </td>
                     <td>
                        <asp:Button ID="pocetnBTN" CausesValidation="false" runat="server" Text="Podesavanja Pocetne" OnClick="pocetnBTN_Click" />
                    </td>
                </tr>
            </table>
          <h3 style="text-align:center">Lista Registrovanih Korisnika</h3>
          <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="ID" ForeColor="Black" Width="980px" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging1">
              <Columns>
                  <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                  <asp:BoundField DataField="Ime" HeaderText="Ime" SortExpression="Ime" />
                  <asp:BoundField DataField="Prezime" HeaderText="Prezime" SortExpression="Prezime" />
                  <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                  <asp:BoundField DataField="AdminPristup" HeaderText="Admin" SortExpression="AdminPristup" />
                  <asp:BoundField DataField="Verifikacija" HeaderText="Verifikacija" SortExpression="Verifikacija" />
                  <asp:BoundField DataField="Telefon" HeaderText="Telefon" SortExpression="Telefon" />
                  <asp:BoundField DataField="Grad" HeaderText="Grad" SortExpression="Grad" />
                  <asp:TemplateField HeaderText="AdminPristup" ShowHeader="False">
                      <ItemTemplate>
                          <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex%>' CommandName="Dodaj" Text="Dodaj"></asp:LinkButton>
                          <br />
                          <asp:LinkButton ID="LinkButton3" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex%>' CommandName="Oduzmi" runat="server">Oduzmi</asp:LinkButton>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Izbrisi" ShowHeader="False">
                      <ItemTemplate>
                          <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex%>' CommandName="Izbrisi" Text="Izbrisi"></asp:LinkButton>
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
