using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SQLite;


namespace WebShop
{
    public partial class WebForm4 : System.Web.UI.Page
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
        
        private int akcija;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                    // sve sto se ucitava na strani ide ovde ako je zahtev od admina da se ucita

                    PosaljiUserName();
                    string _id = Request.QueryString["ID"];
                    if (Request.QueryString["ID"] == null)
                    {
                        Response.Redirect("~/ErrorPages/Warning.aspx");
                    }
                    else
                    {
                        izmeniSnizenaCenaTXT.Enabled = false;



                        DataSet dataSource = new DataSet();
                        KnjigaDB knjigaDB = new KnjigaDB();
                        dataSource = knjigaDB.GetKnjigeDB(_id);


                        //popunjavanje textbox-ova
                        izmeniNaslovTXT.Text = (dataSource.Tables[0].Rows[0].ItemArray[1]).ToString();
                        izmeniAutorTXT.Text = (dataSource.Tables[0].Rows[0].ItemArray[2]).ToString();
                        izmeniIzdavacTXT.Text = (dataSource.Tables[0].Rows[0].ItemArray[3]).ToString();
                        izmeniIsbnTXT.Text = (dataSource.Tables[0].Rows[0].ItemArray[4]).ToString();
                        izmeniOpisTXT.Text = (dataSource.Tables[0].Rows[0].ItemArray[6]).ToString();
                        izmeniCenaTXT.Text = (dataSource.Tables[0].Rows[0].ItemArray[7]).ToString();
                        izmeniSnizenaCenaTXT.Text = (dataSource.Tables[0].Rows[0].ItemArray[8]).ToString();

                        izmeniTipDDL.SelectedValue = (dataSource.Tables[0].Rows[0].ItemArray[10]).ToString();
                        //selektovanje checkboxa u zavisnosti od podatka iz baze 1 selektovan, 0 nije
                        akcija = Convert.ToInt32((dataSource.Tables[0].Rows[0].ItemArray[11]).ToString());
                        if (akcija == 0)
                        {
                            CheckBox1.Checked = false;
                            izmeniSnizenaCenaTXT.Enabled = false;
                        }
                        else
                        {
                            CheckBox1.Checked = true;
                            izmeniSnizenaCenaTXT.Enabled = true;
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
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {

                izmeniSnizenaCenaTXT.Enabled = true;
                RequiredFieldValidator7.Enabled = true;
                izmeniSnizenaCenaTXT.Text = "";

            }
            else
            {
                izmeniSnizenaCenaTXT.Enabled = false;
                izmeniSnizenaCenaTXT.Text = "0.00";
                RequiredFieldValidator7.Enabled = false;
            }
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {

            
            if (Page.IsValid)
            {
                string _id = Request.QueryString["ID"];

                DataSet dataSource = new DataSet();
                KnjigaDB knjigaDB = new KnjigaDB();
                dataSource = knjigaDB.GetKnjigeDB(_id);

                string picPath = dataSource.Tables[0].Rows[0].ItemArray[9].ToString();

                int akcija = Convert.ToInt32((dataSource.Tables[0].Rows[0].ItemArray[11]).ToString());
                if (izmeniFileUpload.HasFile)
                {
                 picPath = Server.MapPath("~/img/bookpic/") + izmeniFileUpload.FileName;

                 izmeniFileUpload.PostedFile.SaveAs(picPath);
                }


                knjigaDB.UpdateKnjigaDB(_id, izmeniNaslovTXT.Text, izmeniAutorTXT.Text, izmeniIzdavacTXT.Text, izmeniIsbnTXT.Text, izmeniOpisTXT.Text, Convert.ToDouble(izmeniCenaTXT.Text), Convert.ToDouble(izmeniSnizenaCenaTXT.Text), picPath, izmeniTipDDL.SelectedValue, akcija);

            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (izmeniFileUpload.HasFile)
            {
                if (Path.GetExtension(izmeniFileUpload.FileName) == ".jpg" || Path.GetExtension(izmeniFileUpload.FileName) == ".gif" || Path.GetExtension(izmeniFileUpload.FileName) == ".png")
                {


                    if (izmeniFileUpload.FileBytes.Length > 2097152)
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
            if (izmeniTipDDL.SelectedValue == "-1")
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
