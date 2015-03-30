using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

namespace WebShop
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PosaljiUserName();
                PopuniRightPanel();
                
                if (Request.QueryString["ID"]!=null)
                {
                    popuniStranuKnjiga(Convert.ToInt32(Request.QueryString["ID"]));
                }
                else
                {
                    Response.Redirect("~/ErrorPages/warning.aspx");
                }
                if (Request.QueryString["dodajID"] != null)
                {
                    KorpaDB korpaDB = new KorpaDB();
                    HttpCookie authCookie = Request.Cookies[".ASPXAUTH"];
                    if (authCookie != null)
                    {
                        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                        KorisnikDB korisnik = new KorisnikDB();
                        DataSet korisnikDS = new DataSet();
                        korisnikDS = korisnik.GetKorisnikPoEmailuDB(ticket.Name);

                        string korisnikID = "0";

                        foreach (DataTable table in korisnikDS.Tables)
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                korisnikID = row.ItemArray[0].ToString();


                            }
                        }
                        korpaDB.InsertKorpaDB(korisnikID, Request.QueryString["dodajID"].ToString());
                    }

                }
            }
        }
        private void PosaljiUserName()
        {
            HttpCookie authCookie = Request.Cookies[".ASPXAUTH"]; // citanje kolacica 
            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                ((BookStore)Master).UserName = ticket.Name; // slanje detalja o kolacicu na master page formu
            }
            else
            {
                ((BookStore)Master).UserName = "123";
            }

        }
        private void popuniStranuKnjiga(int id)
        {
            DropDownList kolicina = new DropDownList();
            kolicina.ID = "kolicina";
             for (int i = 1; i <=10; i++)
        {
            ListItem li = new ListItem();
            li.Text = i.ToString();
            li.Value = i.ToString();
            kolicina.Items.Add(li);
        }
             KnjigaDB knjigaDB = new KnjigaDB();
            DataSet source=new DataSet();
            source = knjigaDB.GetKnjigeDB(id.ToString());

            Label opis = new Label();
            opis.CssClass = "opis";
            opis.Text = source.Tables[0].Rows[0].ItemArray[6].ToString();
            Label naslov = new Label();
            naslov.CssClass = "naslov";
            naslov.Text = source.Tables[0].Rows[0].ItemArray[1].ToString().ToUpper();
            Label autor = new Label();
            autor.CssClass = "autor";
            autor.Text ="Autor: "+ source.Tables[0].Rows[0].ItemArray[2].ToString().ToUpper();

            Label izdavac = new Label();
            izdavac.CssClass = "izdavac";
            izdavac.Text = "Izdavač: " + source.Tables[0].Rows[0].ItemArray[3].ToString().ToUpper();

            Label isbn = new Label();
            isbn.CssClass = "isbn";
            isbn.Text = "ISBN Broj: " + source.Tables[0].Rows[0].ItemArray[4].ToString().ToUpper();

            Label snizenaCena = new Label();
            snizenaCena.CssClass = "snizena-cena";
            snizenaCena.Text = "Snizena cena: " + source.Tables[0].Rows[0].ItemArray[8].ToString().ToUpper()+" din";
              Label Cena = new Label();
            Cena.CssClass = "snizena-cena";
            Cena.Text = "Cena: " + source.Tables[0].Rows[0].ItemArray[8].ToString().ToUpper() + " din";
            Image slika = new Image();
            slika.CssClass = "slika";
            slika.ImageUrl = source.Tables[0].Rows[0].ItemArray[9].ToString();


            panelKnjiga.Controls.Add(new Literal { Text = "<div id='wrapper-div'>" });//1
            panelKnjiga.Controls.Add(slika);
            panelKnjiga.Controls.Add(new Literal { Text = "<div id='wrapper-div-right'>" });
           panelKnjiga.Controls.Add(new Literal { Text = "<div id='naslov'>" });
            panelKnjiga.Controls.Add(naslov);
            panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
            panelKnjiga.Controls.Add(new Literal { Text = "<br/>" });
            panelKnjiga.Controls.Add(new Literal { Text = "<div id='autor'>" });
            panelKnjiga.Controls.Add(autor);
            panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
           
            panelKnjiga.Controls.Add(new Literal { Text = "<div id='izdavac'>" });
            panelKnjiga.Controls.Add(izdavac);
            panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
            
            panelKnjiga.Controls.Add(new Literal { Text = "<div id='broj'>" });
            panelKnjiga.Controls.Add(isbn);
            panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
            panelKnjiga.Controls.Add(new Literal { Text = "<br/>" });

            if (source.Tables[0].Rows[0].ItemArray[11].ToString() == "1")
            {
                panelKnjiga.Controls.Add(new Literal { Text = "<div style='text-decoration: line-through;' id='cena'>" });
                panelKnjiga.Controls.Add(Cena);
                panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
            }
            else
            {
                panelKnjiga.Controls.Add(new Literal { Text = "<div id='cena'>" });
                panelKnjiga.Controls.Add(Cena);
                panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
            }
           
            if (source.Tables[0].Rows[0].ItemArray[11].ToString() == "1")
            {
                panelKnjiga.Controls.Add(new Literal { Text = "<div style='color:#CC373E' id='snizena-cena'>" });
                panelKnjiga.Controls.Add(snizenaCena);
                panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
            }
            panelKnjiga.Controls.Add(new Literal { Text = "<br/>" });
            panelKnjiga.Controls.Add(new Literal { Text = "<div id='dodaj'>" });
            panelKnjiga.Controls.Add(new Literal { Text = "<a id='dodaj-link' href='knjiga.aspx?ID="+Request.QueryString["ID"]+"&dodajID=" + Request.QueryString["ID"] + "'>Dodaj u korpu</a>" });
            panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
            panelKnjiga.Controls.Add(new Literal { Text = "</div>" });

            panelKnjiga.Controls.Add(new Literal { Text = "</div>" });//1

            panelKnjiga.Controls.Add(new Literal { Text = "<div id='opis'>" });
            panelKnjiga.Controls.Add(opis);
            panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
        }
        private void PopuniRightPanel() //NA OSNOVU NAJPRODAVANIJIH KNJIGA PRAVI LISTU TOP 5 I POPUNJAVA DESNI PANEL
        {
            DataSet listaKnjiga = new DataSet();
            ConnDB conn = new ConnDB();
            string queryString1 = "SELECT * from tblKorpa where Kupljena=1";
            listaKnjiga = conn.GetDataFromDB(queryString1);

            List<int> listaBrojeva = new List<int>();

            foreach (DataTable table in listaKnjiga.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    listaBrojeva.Add(Convert.ToInt32(row.ItemArray[2]));
                }
            }


            Dictionary<int, int> Brojevi = new Dictionary<int, int>();
            foreach (int broj in listaBrojeva)
            {
                if (Brojevi.ContainsKey(broj))
                    Brojevi[broj]++;
                else
                    Brojevi[broj] = 1;
            }
            var sortedDict = from entry in Brojevi orderby entry.Value descending select entry; // sortiramo dictionary po value

            int[] prvih5 = new int[5];
            int i = 0;
            foreach (KeyValuePair<int, int> x in sortedDict) // pravimo niz od prvih 5 elemenata
            {
                if (i < 5)
                {
                    prvih5[i] = x.Key;
                    i++;
                }
            }



            DataSet prvih5knjiga = new DataSet();
            string queryString5 = "select * from tblKnjige where ID=" + prvih5[0] + " OR ID=" + prvih5[1] + " OR ID=" + prvih5[2] + " OR ID=" + prvih5[3] + " OR ID=" + prvih5[4] + "";
            prvih5knjiga = conn.GetDataFromDB(queryString5);

            if (prvih5knjiga != null)
            {
                foreach (DataTable table in prvih5knjiga.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {

                        //kreiranje kontrola
                        Panel panelKnjiga = new Panel();
                        ImageButton slika = new ImageButton();
                        LinkButton naslov = new LinkButton();
                        Label autor = new Label();
                        Label izdavac = new Label();
                        Label snizenaCena = new Label();
                        Label cena = new Label();


                        //definisanje parametara kontrola
                        slika.ImageUrl = row.ItemArray[9].ToString();
                        slika.PostBackUrl = "~/UserPages/knjiga.aspx?ID=" + row.ItemArray[0];
                        slika.CssClass = "slika-knjige";

                        naslov.Text = (row.ItemArray[1]).ToString().ToUpper();
                        naslov.CssClass = "naslov-knjige";
                        naslov.PostBackUrl = "~/UserPages/knjiga.aspx?ID=" + row.ItemArray[0];

                        autor.Text = row.ItemArray[2].ToString();
                        autor.CssClass = "autor-knjige";

                        izdavac.Text = row.ItemArray[3].ToString();
                        izdavac.CssClass = "izdavac-knjige";

                        snizenaCena.Text = "Snižena cena: " + row.ItemArray[8].ToString() + " din."; ;
                        snizenaCena.CssClass = "snizenacena-knjige";

                        cena.Text = "Cena: " + row.ItemArray[7].ToString() + " din.";
                        cena.CssClass = "cena-knjige";


                        //dodavanje u panel
                        panelKnjiga.Controls.Add(new Literal { Text = "<div id='panelknjiga-wrapper'>" });
                        panelKnjiga.Controls.Add(new Literal { Text = "<div id='knjiga-left'>" });
                        panelKnjiga.Controls.Add(slika);
                        panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
                        panelKnjiga.Controls.Add(new Literal { Text = "<div id='knjiga-right'>" });
                        panelKnjiga.Controls.Add(new Literal { Text = "<div id='naslov'>" });
                        panelKnjiga.Controls.Add(naslov);
                        panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
                        panelKnjiga.Controls.Add(new Literal { Text = "<div id='autor'>Autor: " });
                        panelKnjiga.Controls.Add(autor);
                        panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
                        panelKnjiga.Controls.Add(new Literal { Text = "<div id='izdavac'>Izdavač: " });
                        panelKnjiga.Controls.Add(izdavac);
                        panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
                        panelKnjiga.Controls.Add(new Literal { Text = "<div id='snizena-cena'>" });
                        if (Convert.ToInt32(row.ItemArray[11]) == 1)// ako je knjiga na akciji dodaje se ovo
                        {

                            panelKnjiga.Controls.Add(snizenaCena);

                        }
                        panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
                        if (Convert.ToInt32(row.ItemArray[11]) == 1)
                        {
                            panelKnjiga.Controls.Add(new Literal { Text = "<div style='text-decoration: line-through;' id='cena'>" });
                            panelKnjiga.Controls.Add(cena);
                            panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
                        }
                        else
                        {
                            panelKnjiga.Controls.Add(new Literal { Text = "<div id='cena'>" });
                            panelKnjiga.Controls.Add(cena);
                            panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
                        }
                        panelKnjiga.Controls.Add(new Literal { Text = "<div id='ubaci-u-korpu'>" });
                        panelKnjiga.Controls.Add(new Literal { Text = "<a class='ubaciukorpu-button' href='knjiga.aspx?ID=" + Request.QueryString["ID"] + "&dodajID=" + row.ItemArray[0].ToString() + "'>Ubaci u korpu</a>" });
                        panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
                        panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
                        panelKnjiga.Controls.Add(new Literal { Text = "</div>" });

                        //dodavanje u veliki panel
                        rightPanel.Controls.Add(panelKnjiga);


                    }
                }
            }


        }
    }


}