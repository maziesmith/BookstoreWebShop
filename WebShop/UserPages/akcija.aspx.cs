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
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PosaljiUserName();
                PopuniRightPanel();

                if (Request.QueryString["stranaID"] == null)
                {
                    Response.Redirect("~/UserPages/akcija.aspx?stranaID=1");

                }
                if (Request.QueryString["stranaID"] != null)
                {

                    PopuniStranu(Request.QueryString["stranaID"]);


                }
                if (Request.QueryString["knjigaID"] != null)
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
                        korpaDB.InsertKorpaDB(korisnikID, Request.QueryString["knjigaID"].ToString());
                    }

                }
                if (Request.QueryString["stranaID"] != null)
                {

                    DodajFuter();

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
    

        private void DodajFuter() //klasa broji koliko ima elemenata odredjenog tipa knjige i dodaje u futer panel brojeve stranica. 10 panela knjiga po stranici i onda se kreira nova
        {
            DataSet listaKnjiga = new DataSet();
            KnjigaDB knjigaDB = new KnjigaDB();
            listaKnjiga = knjigaDB.GetKnjigeAkcijaDB();
            if (listaKnjiga != null)
            {
                int i = 1;
                foreach (DataTable table in listaKnjiga.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {

                        i++; //brojimo koliko ima redova pod tom pretragom

                    }
                }



                int brojPo10 = Convert.ToInt32(i / 10); // oduzimamo decimalni zapis i dobijamo koliko ima stranica uzimajuci u obzir da na 10 trea sledeca

                if (brojPo10 != 0) // ako je razlicit od nule treba dodati panel zato sto ce imati 2 stranice ako nije onda se ne dodaje
                {

                    for (int k = 1; k <= brojPo10; k++) //prolazimo kroz sve elemeente i dodajemo po jednu link stranicu
                    {


                        futerpanel.Controls.Add(new Literal { Text = "<a class='link-strane' href=akcija.aspx?stranaID=" + k.ToString() + ">&nbsp" + k.ToString() + "</a>" });
                    }

                    if (Convert.ToDouble(i) / 10 > brojPo10) // ako je podeljen broj veci od od broja po 10 dodaje se jos jedna stranica za ostatak
                    {
                        int dodatakViska = brojPo10 + 1;

                        futerpanel.Controls.Add(new Literal { Text = "<a class='link-strane' href=akcija.aspx?stranaID=" + dodatakViska.ToString() + ">&nbsp" + dodatakViska.ToString() + "</a>" });
                    }

                }

            }
        }




        private void PopuniStranu(string pageID)
        {
            DataSet listaKnjiga = new DataSet();
            KnjigaDB knjigaDB = new KnjigaDB();
            string pocetni = Convert.ToString((Convert.ToInt32(Request.QueryString["stranaID"]) * 10) - 11); // dobijamo koliko elemenata iz baze treba da uzimamo manje 10 i to je pocetni
            listaKnjiga = knjigaDB.GetKnjigeOFFSEakcijaTDB(pocetni, "10", "1");                          //-11 zato sto ne ukljucuje taj koji je naveden kao pocetni

            if (listaKnjiga != null)
            {
                foreach (DataTable table in listaKnjiga.Tables)
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
                        
                        panelKnjiga.Controls.Add(new Literal { Text = "<a class='ubaciukorpu-button' href='akcija.aspx?stranaID="+Request.QueryString["stranaID"]+"&knjigaID="+row.ItemArray[0].ToString()+"'>Ubaci u korpu</a>"});
                        panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
                        panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
                        panelKnjiga.Controls.Add(new Literal { Text = "</div>" });

                        //dodavanje u veliki panel
                        domaceKnjigePanel.Controls.Add(panelKnjiga);


                    }
                }
            }
            else
            {
                warninglabel.Text = "Nema knjiga u bazi.";

            }

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
                        panelKnjiga.Controls.Add(new Literal { Text = "<a class='ubaciukorpu-button' href='domaceKnjige.aspx?stranaID=" + Request.QueryString["stranaID"] + "&knjigaID=" + row.ItemArray[0].ToString() + "'>Ubaci u korpu</a>" });
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