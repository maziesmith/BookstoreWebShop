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
    public partial class WebForm18 : System.Web.UI.Page
    {
        string Slajd1;
        string Slajd2;
        string Slajd3;
        string Slajd4;
        string Slajd5;
        string Sadrzaj1;
        string Sadrzaj2;
        string Sadrzaj3;
        string Sadrzaj4;
        string Sadrzaj5;
        string Sadrzaj6;
        protected void Page_Init(object sender, EventArgs e)
        {
            
            PopuniTextBoxove();
            HttpCookie authCookie = Request.Cookies[".ASPXAUTH"]; // citanje kolacica 

            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                KorisnikDB korisnik = new KorisnikDB();
                DataSet source = new DataSet();
                source = korisnik.GetKorisnikPoEmailuDB(ticket.Name);


                string adminStatus = "";
                foreach (DataTable table in source.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {

                        adminStatus = row.ItemArray[13].ToString();

                    }
                }
                if (adminStatus != "1")
                {
                    Response.Redirect("~/ErrorPages/Warning.aspx");

                }


            }
            else
            {
                Response.Redirect("~/ErrorPages/Warning.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PosaljiUserName();
            }
        }

        private void PopuniTextBoxove()
        {
            ConnDB conn = new ConnDB();

            //prepopunjavanje textbox-ova koji se odnose na slajder sa vrednostima iz baze za svaki slajd
            DataSet ds1 = new DataSet();
            string queryString1 = "Select * from tblKnjige where Slajder=1";
            ds1 = conn.GetDataFromDB(queryString1);

            DataSet ds2 = new DataSet();
            string queryString2 = "Select * from tblKnjige where Slajder=2";
            ds2 = conn.GetDataFromDB(queryString2);

            DataSet ds3 = new DataSet();
            string queryString3 = "Select * from tblKnjige where Slajder=3";
            ds3 = conn.GetDataFromDB(queryString3);

            DataSet ds4 = new DataSet();
            string queryString4 = "Select * from tblKnjige where Slajder=4";
            ds4 = conn.GetDataFromDB(queryString4);

            DataSet ds5 = new DataSet();
            string queryString5 = "Select * from tblKnjige where Slajder=5";
            ds5 = conn.GetDataFromDB(queryString5);

            slajd1TXT.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
            slajd2TXT.Text = ds2.Tables[0].Rows[0].ItemArray[0].ToString();
            slajd3TXT.Text = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
            slajd4TXT.Text = ds4.Tables[0].Rows[0].ItemArray[0].ToString();
            slajd5TXT.Text = ds5.Tables[0].Rows[0].ItemArray[0].ToString();

            //cuvanje u property vrednosti 
            Slajd1 = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
            Slajd2 = ds2.Tables[0].Rows[0].ItemArray[0].ToString();
            Slajd3 = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
            Slajd4 = ds4.Tables[0].Rows[0].ItemArray[0].ToString();
            Slajd5 = ds5.Tables[0].Rows[0].ItemArray[0].ToString();


            //popunjavanje textboxova koji se odnose na sadrzaj ispod slajdera

            DataSet s1 = new DataSet();
            string queryS1 = "Select * from tblKnjige where Sadrzaj=1";
            s1 = conn.GetDataFromDB(queryS1);

            DataSet s2 = new DataSet();
            string queryS2 = "Select * from tblKnjige where Sadrzaj=2";
            s2 = conn.GetDataFromDB(queryS2);

            DataSet s3 = new DataSet();
            string queryS3 = "Select * from tblKnjige where Sadrzaj=3";
            s3 = conn.GetDataFromDB(queryS3);

            DataSet s4 = new DataSet();
            string queryS4 = "Select * from tblKnjige where Sadrzaj=4";
            s4 = conn.GetDataFromDB(queryS4);

            DataSet s5 = new DataSet();
            string queryS5 = "Select * from tblKnjige where Sadrzaj=5";
            s5 = conn.GetDataFromDB(queryS5);

            DataSet s6 = new DataSet();
            string queryS6 = "Select * from tblKnjige where Sadrzaj=6";
            s6 = conn.GetDataFromDB(queryS6);

            polje1TXT.Text = s1.Tables[0].Rows[0].ItemArray[0].ToString();
            polje2TXT.Text = s2.Tables[0].Rows[0].ItemArray[0].ToString();
            polje3TXT.Text = s3.Tables[0].Rows[0].ItemArray[0].ToString();
            polje4TXT.Text = s4.Tables[0].Rows[0].ItemArray[0].ToString();
            polje5TXT.Text = s5.Tables[0].Rows[0].ItemArray[0].ToString();
            polje6TXT.Text = s6.Tables[0].Rows[0].ItemArray[0].ToString();

            //cuvanje u property vrednosti 
            Sadrzaj1 = s1.Tables[0].Rows[0].ItemArray[0].ToString();
            Sadrzaj2 = s2.Tables[0].Rows[0].ItemArray[0].ToString();
            Sadrzaj3 = s3.Tables[0].Rows[0].ItemArray[0].ToString();
            Sadrzaj4 = s4.Tables[0].Rows[0].ItemArray[0].ToString();
            Sadrzaj5 = s5.Tables[0].Rows[0].ItemArray[0].ToString();
            Sadrzaj6 = s6.Tables[0].Rows[0].ItemArray[0].ToString();
        }


        protected void dodajKnjiguBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPages/dodajKnjigu.aspx");
        }

        protected void ListaKorisnikaBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPages/Korisnici.aspx");
        }

        protected void ListaKnjigaBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPages/ListaKnjiga.aspx");
        }

  

        protected void adminPanelBTN1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPages/AdminPage.aspx");
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            ConnDB conn = new ConnDB();
            try
            {
                //upisivanje 0 na mesto na prethodno izabrane knjige za slajder 

                string queryString1 = "Update tblKnjige set Slajder=0 where ID=" + Slajd1 + "";
                conn.UpdateDataFromDB(queryString1);
                string queryString2 = "Update tblKnjige set Slajder=0 where ID=" + Slajd2 + "";
                conn.UpdateDataFromDB(queryString2);
                string queryString3 = "Update tblKnjige set Slajder=0 where ID=" + Slajd3 + "";
                conn.UpdateDataFromDB(queryString3);
                string queryString4 = "Update tblKnjige set Slajder=0 where ID=" + Slajd4 + "";
                conn.UpdateDataFromDB(queryString4);
                string queryString5 = "Update tblKnjige set Slajder=0 where ID=" + Slajd5 + "";
                conn.UpdateDataFromDB(queryString5);

                //upisivanje 0 na prethodno izabrane knjige za Sadrzaj

                string queryS1 = "Update tblKnjige set Sadrzaj=0 where ID=" + Sadrzaj1 + "";
                conn.UpdateDataFromDB(queryS1);
                string queryS2 = "Update tblKnjige set Sadrzaj=0 where ID=" + Sadrzaj2 + "";
                conn.UpdateDataFromDB(queryS2);
                string queryS3 = "Update tblKnjige set Sadrzaj=0 where ID=" + Sadrzaj3 + "";
                conn.UpdateDataFromDB(queryS3);
                string queryS4 = "Update tblKnjige set Sadrzaj=0 where ID=" + Sadrzaj4 + "";
                conn.UpdateDataFromDB(queryS4);
                string queryS5 = "Update tblKnjige set Sadrzaj=0 where ID=" + Sadrzaj5 + "";
                conn.UpdateDataFromDB(queryS5);
                string queryS6 = "Update tblKnjige set Sadrzaj=0 where ID=" + Sadrzaj6 + "";
                conn.UpdateDataFromDB(queryS6);
                //------------------------------------------------------------------------------------
                //upisivanje novih vrednosti za slajder

                string queryString11 = "Update tblKnjige set Slajder=1 where ID=" + slajd1TXT.Text + "";
                conn.UpdateDataFromDB(queryString11);
                string queryString22 = "Update tblKnjige set Slajder=2 where ID=" + slajd2TXT.Text + "";
                conn.UpdateDataFromDB(queryString22);
                string queryString33 = "Update tblKnjige set Slajder=3 where ID=" + slajd3TXT.Text + "";
                conn.UpdateDataFromDB(queryString33);
                string queryString44 = "Update tblKnjige set Slajder=4 where ID=" + slajd4TXT.Text + "";
                conn.UpdateDataFromDB(queryString44);
                string queryString55 = "Update tblKnjige set Slajder=5 where ID=" + slajd5TXT.Text + "";
                conn.UpdateDataFromDB(queryString55);

                //upisivanje noih vrednosti za sadrzaj

                string queryS11 = "Update tblKnjige set Sadrzaj=1 where ID=" + polje1TXT.Text + "";
                conn.UpdateDataFromDB(queryS11);
                string queryS22 = "Update tblKnjige set Sadrzaj=2 where ID=" + polje2TXT.Text + "";
                conn.UpdateDataFromDB(queryS22);
                string queryS33 = "Update tblKnjige set Sadrzaj=3 where ID=" + polje3TXT.Text + "";
                conn.UpdateDataFromDB(queryS33);
                string queryS44 = "Update tblKnjige set Sadrzaj=4 where ID=" + polje4TXT.Text + "";
                conn.UpdateDataFromDB(queryS44);
                string queryS55 = "Update tblKnjige set Sadrzaj=5 where ID=" + polje5TXT.Text + "";
                conn.UpdateDataFromDB(queryS55);
                string queryS66 = "Update tblKnjige set Sadrzaj=6 where ID=" + polje6TXT.Text + "";
                conn.UpdateDataFromDB(queryS66);

                Label1.Text = "Uspesno ste sacuvali!";
            }
            catch
            {
                Label1.Text = "Promena nije sacuvana. Molimo pokusajte kasnije";
            }
        }
    }
}
