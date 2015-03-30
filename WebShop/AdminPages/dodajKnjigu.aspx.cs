using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Security;
using System.Data;

namespace WebShop
{
    public partial class WebForm3 : System.Web.UI.Page
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
                addSnizenaCenaTXT.Enabled = false;
                RequiredFieldValidator7.Enabled = false;
                addSnizenaCenaTXT.Text = "0.00";


            }
        }
        protected void pocetnBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPages/setuppocetna.aspx");
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
 
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {

                addSnizenaCenaTXT.Enabled = true;
                RequiredFieldValidator7.Enabled = true;
                addSnizenaCenaTXT.Text = "";

            }
            else
            {
                addSnizenaCenaTXT.Enabled = false;
                addSnizenaCenaTXT.Text = "0.00";
                RequiredFieldValidator7.Enabled = false;
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    KnjigaDB knjigaDB = new KnjigaDB();

                    addFileUpload.PostedFile.SaveAs(Server.MapPath("~/img/bookpic/" + addFileUpload.FileName));
                    int akcija = 0;
                    if (CheckBox1.Checked)
                    {
                        akcija = 1;
                    }

                    knjigaDB.InsertKnjiguDB(addNaslovTXT.Text, addAutorTXT.Text, addIzdavacTXT.Text, addIsbnTXT.Text, addOpisTXT.Text, Convert.ToDouble(addCenaTXT.Text), Convert.ToDouble(addSnizenaCenaTXT.Text), "~/img/bookpic/" + addFileUpload.FileName, addTipDDL.SelectedValue, akcija);
                    messageLBL.Text = "Uspešno ste dodali knjigu!";
                    addNaslovTXT.Text = "";
                    addAutorTXT.Text = "";
                    addIzdavacTXT.Text = "";
                    addIsbnTXT.Text = "";
                    addOpisTXT.Text = "";
                    addTipDDL.SelectedIndex = 0;
                    addCenaTXT.Text = "";
                    CheckBox1.Checked = false;
                    addSnizenaCenaTXT.Text = "0.00";
                    
                }
                catch
                {
                    messageLBL.Text = "Neuspešno dodavanje knjige. Molimo pokušajte kasnije!";
                }
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (addFileUpload.HasFile)
            {
                if (Path.GetExtension(addFileUpload.FileName) == ".jpg" || Path.GetExtension(addFileUpload.FileName) == ".gif" || Path.GetExtension(addFileUpload.FileName) == ".png")
                {


                    if (addFileUpload.FileBytes.Length > 2097152)
                    {
                        CustomValidator1.ErrorMessage = "Maximalna velicina fajle je 2 MB.";
                        args.IsValid = false;
                    }
                    else
                    {
                        args.IsValid = true;
                    }
                }
                else
                {
                    CustomValidator1.ErrorMessage = "Fajl mora biti u formatu .jpg .png .gif";
                    args.IsValid = false;
                }
            }
            else
            {
                CustomValidator1.ErrorMessage = "Morate izabrati sliku!";
                args.IsValid = false;
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (addTipDDL.SelectedValue == "-1")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}
