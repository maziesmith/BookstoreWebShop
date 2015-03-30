using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;


namespace WebShop
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {

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

                PopuniGridview();

                    
                    PosaljiUserName();
                    if (GridView1.Rows.Count == 0)
                    {
                        warninglabel.Text = "Nema poručenih knjiga!";

                    }


            }
            
        }

        private void PopuniGridview()
        {
            ConnDB conn = new ConnDB();
            DataSet ds = new DataSet();
            string queryString="SELECT ID, KorisnikID, KnjigaID, Kupljena, AdminID, Poruceno FROM tblKorpa WHERE (Poruceno = 1) AND (Kupljena = 0)";
            ds = conn.GetDataFromDB(queryString);

            GridView1.DataSource = ds;
            GridView1.DataBind();
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Isporuci") //upisujemo u bazu da je knjiga kupljena 
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

                ConnDB conn = new ConnDB();

                string sqlCommand = "update tblKorpa set Kupljena=1,AdminID="+korisnikID+" where ID=" + GridView1.DataKeys[index].Value.ToString() +"";
                conn.UpdateDataFromDB(sqlCommand);
                Response.Redirect("~/AdminPages/AdminPage.aspx");
            }
        }

        protected void pocetnBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPages/setuppocetna.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            PopuniGridview();
        }
    }
}