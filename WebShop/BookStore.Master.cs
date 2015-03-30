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
    public partial class BookStore : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopuniHederKorpu();
                LoginPopunjavanje();
            }

        }
        public string UserName // cuva username odnosno mejl iz kolacica forms authentication
        {
            get;
            set;
        }

        private void LoginPopunjavanje() // popunjava login deo hedera sa imenom i prezimenom ako je logovan user ako nije onda pise "Zaboravili ste lozinku"
                                            // takodje menja tekst battona za Ulaz/izlaz
        {
            
            if (UserName!="123")
            {

                KorisnikDB korisnik = new KorisnikDB();
                DataSet source = new DataSet();
                source = korisnik.GetKorisnikPoEmailuDB(UserName);
                
                string imePrezime="";
                string isAdmin = "0";
                foreach (DataTable table in source.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        imePrezime = row.ItemArray[1].ToString() + " " + row.ItemArray[2].ToString(); // upisujemo ime korisnika
                        isAdmin = row.ItemArray[13].ToString();

                    }
                }
                loginLBL.Text = "IZLAZ";
                imeZaboravljenLBL.Text = imePrezime;

                if (isAdmin == "1")
                {
                    adminLBL.Visible = true;
                }
                else
                {
                    adminLBL.Visible = false;
                }


            }
            else
            {
                imeZaboravljenLBL.Text = "Zaboravili ste lozinku?";
                loginLBL.Text = "ULAZ";

            }
        }

        private void PopuniHederKorpu() // metoda popunjava korpu u hederu sa cenama. bira da li je na snizenju ili ne i sabira
        {

            if (UserName != "123")
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
                            brojArtikalaLBL.Text = "artikala " + brojArtikala.ToString();
                            cenaKorpe.Text = "(" + cena + " din)";
                        }
                        else
                        {
                            brojArtikalaLBL.Text = "artikala 0";
                            cenaKorpe.Text = "(Nemate artikala u korpi)";
                        }

                    }


                }
            }
            else
            {
                brojArtikalaLBL.Text = "artikala 0";
                cenaKorpe.Text = "(Nemate artikala u korpi)";
            }
        }

        protected void ulazIzlazLB_Click(object sender, EventArgs e)
        {
            if (loginLBL.Text == "ULAZ")
            {
 


                    Response.Redirect("~/UserPages/ulaz.aspx");
                
                
                
            }
            else
            {
                FormsAuthentication.SignOut(); // odjavi se ali ne unisti kolacic pa mora kroz kod
                HttpCookie authCookie = Request.Cookies[".ASPXAUTH"];
                authCookie.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(authCookie);
                Response.Redirect("~/default.aspx");
                loginLBL.Text = "ULAZ";
            }
        }

        protected void searchBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserPages/search.aspx?stranaID=1&upit="+searchTXT1.Text+"");
        }

        protected void zaboravljenaLozinkaImeIPrezimeLB_Click(object sender, EventArgs e)
        {
            if (imeZaboravljenLBL.Text == "Zaboravili ste lozinku?")
            {
                Response.Redirect("~/UserPages/reset.aspx");
            }
            else
            {
                Response.Redirect("~/UserPages/userprofile.aspx");
            }
        }


    }
}