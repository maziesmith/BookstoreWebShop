﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

namespace WebShop
{
    public partial class WebForm20 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopuniTextBoxove();
                PosaljiUserName();
                PopuniRightPanel();
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

                                //popunjavanje textboxova

                            }
                        }
                        korpaDB.InsertKorpaDB(korisnikID, Request.QueryString["knjigaID"].ToString());

                        
                    }

                }
            }
        }
        private void PopuniTextBoxove()
        {

            HttpCookie authCookie = Request.Cookies[".ASPXAUTH"];
            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                KorisnikDB korisnik = new KorisnikDB();
                DataSet korisnikDS = new DataSet();
                korisnikDS = korisnik.GetKorisnikPoEmailuDB(ticket.Name);

                foreach (DataTable table in korisnikDS.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                       

                        //popunjavanje textboxova
                        regImeTXT1.Text = row.ItemArray[1].ToString();
                        regPrezimeTXT1.Text = row.ItemArray[2].ToString();
                        regDatumRodjenjaTXT1.Text = row.ItemArray[3].ToString();
                        regGradTXT1.Text = row.ItemArray[4].ToString();
                        regAdresaTXT1.Text = row.ItemArray[5].ToString();
                        regBrojStanaTXT1.Text = row.ItemArray[6].ToString();
                        regPostanskiBrojTXT1.Text = row.ItemArray[7].ToString();
                        regKontaktTelefonTXT1.Text = row.ItemArray[8].ToString();
                        regEmailTXT1.Text = row.ItemArray[9].ToString();
                        regEmailPotvrdaTXT1.Text = row.ItemArray[9].ToString();
                        regLozinkaTXT1.Text = row.ItemArray[10].ToString();
                        regLozinkaPotvrdaTXT1.Text = row.ItemArray[10].ToString();
                    }
                }
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
                        panelKnjiga.Controls.Add(new Literal { Text = "<a class='ubaciukorpu-button' href='userprofile.aspx?knjigaID=" + row.ItemArray[0].ToString() + "'>Ubaci u korpu</a>" });
                        panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
                        panelKnjiga.Controls.Add(new Literal { Text = "</div>" });
                        panelKnjiga.Controls.Add(new Literal { Text = "</div>" });

                        //dodavanje u veliki panel
                        rightPanel.Controls.Add(panelKnjiga);


                    }
                }
            }


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
            HttpCookie authCookie = Request.Cookies[".ASPXAUTH"];
            if (authCookie != null)
            {
                try
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                    KorisnikDB korisnik = new KorisnikDB();
                    DataSet korisnikDS = new DataSet();
                    korisnikDS = korisnik.GetKorisnikPoEmailuDB(ticket.Name);

                    string passwordEncr = FormsAuthentication.HashPasswordForStoringInConfigFile(regLozinkaTXT1.Text, "SHA1");
                    KorisnikDB noviKorisnik = new KorisnikDB();

                    int korisnikID = Convert.ToInt32(korisnikDS.Tables[0].Rows[0].ItemArray[0].ToString());

                    noviKorisnik.UpdateKorisnikDB(korisnikID, regImeTXT1.Text, regPrezimeTXT1.Text, regDatumRodjenjaTXT1.Text, regGradTXT1.Text, regAdresaTXT1.Text, regBrojStanaTXT1.Text, Convert.ToInt32(regPostanskiBrojTXT1.Text), Convert.ToInt32(regKontaktTelefonTXT1.Text), regEmailTXT1.Text, passwordEncr);
                    porukaLBL.Text="Uspešno ste izmenili vaš profil!";
                }
                catch
                {
                    porukaLBL.Text = "Došlo je do greške. Molimo pokušajte kasnije.";
                }
            }
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ((args.Value).Length >= 8 && (args.Value).Length <= 16)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
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

    }
}