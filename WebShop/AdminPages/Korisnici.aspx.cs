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
    public partial class WebForm7 : System.Web.UI.Page
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

                    PosaljiUserName();
                    PopuniGridview();

            }
        }

        private void PopuniGridview()
        {
            ConnDB conn = new ConnDB();
            DataSet ds = new DataSet();
            string queryString = "SELECT [ID], [Ime], [Prezime], [Email], [AdminPristup], [Verifikacija], [Telefon], [Grad] FROM [tblKorisnik]";
            ds = conn.GetDataFromDB(queryString);

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void pocetnBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPages/setuppocetna.aspx");
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
        protected void adminPanelBTN_Click(object sender, EventArgs e)
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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Dodaj")
            {

                string rowID = GridView1.DataKeys[index].Value.ToString();

                    ConnDB connDB = new ConnDB();

                    connDB.UpdateDataFromDB("update tblKorisnik set AdminPristup="+1+" where ID="+rowID+"");

                Response.Redirect("Korisnici.aspx");
            }
            else if (e.CommandName == "Izbrisi")
            {
                KorisnikDB korisnikDB = new KorisnikDB();

                string rowID = GridView1.DataKeys[index].Value.ToString();
                    korisnikDB.DeleteKorisnikDB(rowID);
                
                Response.Redirect("Korisnici.aspx");
            }
            else if (e.CommandName == "Oduzmi")
            {
    
                   string rowID = GridView1.DataKeys[index].Value.ToString();

                    ConnDB connDB = new ConnDB();

                    connDB.UpdateDataFromDB("update tblKorisnik set AdminPristup=" + 0 + " where ID=" + rowID + "");
    
                Response.Redirect("Korisnici.aspx");
            }
        }

        protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            PopuniGridview();
        }
    }
}