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
    public partial class WebForm12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PosaljiUserName();
                HttpCookie authCookie = Request.Cookies[".ASPXAUTH"];
                if (authCookie != null)
                {

                    if (Request.QueryString["poruciID"] != null)
                    {
                        ConnDB conn = new ConnDB(); // upisujemo da je knjiga porucena
                        string queryString = "Update tblKorpa set Poruceno=1 where KorisnikID=" + Request.QueryString["poruciID"].ToString() + "";
                        conn.InsertDataToDB(queryString);
                        Label1.Text = "Uspešno ste poručili artikle!";
                    }

                    if (Request.QueryString["izbrisi"] != null)
                    {
                        KorpaDB korpa = new KorpaDB();
                        korpa.DeleteKorpaPoKnjiziDB(Convert.ToInt32(Request.QueryString["izbrisi"]));
                        

                    }
                    if (Request.QueryString["stranaID"] != null)
                    {

                        PopuniStranuKorpa();
                        PopuniKasu();


                    }
                    else if (Request.QueryString["stranaID"] == null)
                    {
                        Response.Redirect("~/UserPages/korpa.aspx?stranaID=1");
                    }

                    if (Request.QueryString["stranaID"] != null)
                    {

                        DodajFuter();

                    }
                }
                else
                {
                    Response.Redirect("~/ErrorPages/Warning.aspx");
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
        private void PopuniStranuKorpa()
        {

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

                KorpaDB korpaDB = new KorpaDB();
                DataSet source = new DataSet();
                string pocetni = Convert.ToString((Convert.ToInt32(Request.QueryString["stranaID"]) * 5) - 5);

                source = korpaDB.GetKorpaPoKorisnikuOFFSETDB(korisnikID, pocetni); // dodati korisnicki id kad se za to stvore uslovi
                if (source != null)
                {
                    foreach (DataTable table in source.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            DataSet ds = new DataSet();
                            KnjigaDB knjiga = new KnjigaDB();
                            ds = knjiga.GetKnjigeDB(row.ItemArray[2].ToString());


                            Panel panel = new Panel();
                            ImageButton img = new ImageButton();
                            LinkButton naslov = new LinkButton();
                            Label text = new Label();
                            Label cena = new Label();



                            panel.CssClass = "panel";
                            img.CssClass = "slika";
                            naslov.CssClass = "naslov";
                            text.CssClass = "text";
                            cena.CssClass = "cena";

                            img.ImageUrl = ds.Tables[0].Rows[0].ItemArray[9].ToString();
                            img.PostBackUrl = "~/UserPages/knjiga.aspx?ID=" + ds.Tables[0].Rows[0].ItemArray[0].ToString();
                            naslov.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString().ToUpper();
                            naslov.PostBackUrl = "~/UserPages/knjiga.aspx?ID=" + ds.Tables[0].Rows[0].ItemArray[0].ToString();
                            text.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString().Substring(0, 170) + "...";
                            if (ds.Tables[0].Rows[0].ItemArray[11].ToString() == "1")
                            {
                                cena.Text = "Cena: " + ds.Tables[0].Rows[0].ItemArray[8].ToString() + " din";
                            }
                            else
                            {
                                cena.Text = "Cena: " + ds.Tables[0].Rows[0].ItemArray[8].ToString() + " din";
                            }


                            panel.Controls.Add(img);
                            panel.Controls.Add(new Literal { Text = "<div id='right-wrapper'>" });
                            panel.Controls.Add(new Literal { Text = "<div id='naslov'>" });
                            panel.Controls.Add(naslov);
                            panel.Controls.Add(new Literal { Text = "</div>" });
                            panel.Controls.Add(new Literal { Text = "<div id='text'>" });
                            panel.Controls.Add(text);
                            panel.Controls.Add(new Literal { Text = "</div>" });
                            panel.Controls.Add(new Literal { Text = "<div id='cena'>" });
                            panel.Controls.Add(cena);
                            panel.Controls.Add(new Literal { Text = "</div>" });
                            panel.Controls.Add(new Literal { Text = "<div id='obrisi'>" });
                            panel.Controls.Add(new Literal { Text = "<a id='obrisi-link' href='korpa.aspx?stranaID=" + Request.QueryString["stranaID"].ToString() + "&izbrisi=" + ds.Tables[0].Rows[0].ItemArray[0].ToString() + "'>Obriši iz korpe</a>" });                           
                            panel.Controls.Add(new Literal { Text = "</div>" });
                            panel.Controls.Add(new Literal { Text = "</div>" });

                            panelKorpa.Controls.Add(panel);
                        }
                    }
                }
                else { warninglabel.Text = "Korpa je prazna"; }
            }
        }

        #region funkcija_za_dodavanje_futera
        private void DodajFuter() //metoda broji koliko ima elemenata odredjenog tipa knjige i dodaje u futer panel brojeve stranica. 5 panela knjiga po stranici i onda se kreira nova
        {
            

            HttpCookie authCookie = Request.Cookies[".ASPXAUTH"];
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


            KorpaDB korpaDB = new KorpaDB();
            DataSet source = new DataSet();

            source = korpaDB.GetKorpaPoKorisnikuDB(korisnikID); // dodati korisnicki id kad se za to stvore uslovi
            if (source != null)
            {
                int i = 0;
                foreach (DataTable table in source.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {

                        i++; //brojimo koliko ima redova pod tom pretragom

                    }
                }
                


                int brojPo5 = Convert.ToInt32(i / 5); // oduzimamo decimalni zapis i dobijamo koliko ima stranica uzimajuci u obzir da na 5 treba sledeca
                double brojPo5Double = Convert.ToDouble(i) / 5.00;
                
                if (brojPo5Double > 1.00) // ako je razlicit od nule treba dodati panel zato sto ce imati 2 stranice 
                {

                    for (int k = 1; k <= brojPo5; k++) //prolazimo kroz sve elemeente i dodajemo po jednu link stranicu
                    {


                        futerpanel.Controls.Add(new Literal { Text = "<a id='link-strane' href=korpa.aspx?stranaID=" + k.ToString() + ">&nbsp" + k.ToString() + "</a>" });
                    }

                }
                if (i % 5 > 0) //ako je ostatak pri deljenju veci od nule to znaci da ima jos elemenata van k*5 pa se mora dodati jos jedna strana
                {
                    int dodatakViska = brojPo5 + 1;

                    futerpanel.Controls.Add(new Literal { Text = "<a id='link-strane' href=korpa.aspx?stranaID=" + dodatakViska.ToString() + ">&nbsp" + dodatakViska.ToString() + "</a>" });
                }

            }
        }
        #endregion

        private void PopuniKasu()
        {
            HttpCookie authCookie = Request.Cookies[".ASPXAUTH"];
            if (authCookie != null)
            {
                KorpaDB korpaDB = new KorpaDB();
                DataSet source = new DataSet();

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


                source = korpaDB.GetKorpaPoKorisnikuDB(korisnikID);
                double cena = 0.00;
                double cenaBezSnizenja = 0.00;
                int brojArtikala = 0;
                if (source != null)
                {
                    foreach (DataTable table in source.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            double cenaPoKnjizi = 0.00;
                            DataSet ds = new DataSet();
                            KnjigaDB knjiga = new KnjigaDB();
                            ds = knjiga.GetKnjigeDB(row.ItemArray[2].ToString());

                            if (Convert.ToString(ds.Tables[0].Rows[0].ItemArray[11]) == "0")
                            {
                                cenaPoKnjizi = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[7]);
                            }
                            else
                            {
                                cenaPoKnjizi = Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[8]);
                            }
                            cenaBezSnizenja = cenaBezSnizenja + Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[7]);
                            cena = cena + cenaPoKnjizi;
                            brojArtikala = brojArtikala + 1;

                        }
                    }
                    if (brojArtikala != 0)
                    {
                        brojArtikalaLBL.Text = brojArtikala.ToString();
                        ukupnaCenaLBL.Text = cena + " din";
                        ustedaLBL.Text = cenaBezSnizenja - cena + " din";
                    }
                    else
                    {
                        brojArtikalaLBL.Text = "0";
                        ukupnaCenaLBL.Text = "0.00 din";
                        ustedaLBL.Text = "0.00 din";
                        warninglabel.Text = "Nemate artikala u korpi";
                    }


                }
            }
            else
            {
                brojArtikalaLBL.Text = "0";
                ukupnaCenaLBL.Text = "0.00 din";
                ustedaLBL.Text = "0.00 din";
                warninglabel.Text = "Nemate artikala u korpi";
            }
        }

        protected void poruci_Click(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[".ASPXAUTH"];
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




            Response.Redirect("~/UserPages/korpa.aspx?stranaID=1&poruciID=" + korisnikID + "");


        }

    }


}