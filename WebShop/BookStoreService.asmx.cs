using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SQLite;

namespace WebShop
{
    /// <summary>
    /// Summary description for BookStoreService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class BookStoreService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetKnjigeAutor(string upit)
        {   

            List<string> lista=new List<string>();
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            string sqlCommand = "select distinct Ime,Autor from tblKnjige where (Ime Like '%" + upit + "%') OR (Autor Like '%" + upit + "%') group by Autor,Ime LIMIT 15"; //SELECT * FROM COMPANY WHERE AGE  LIKE '2%'

            using (SQLiteConnection conn = new SQLiteConnection(CS))
            {
                SQLiteCommand cmd = new SQLiteCommand(sqlCommand, conn);
                conn.Open();
                SQLiteDataReader rdr=cmd.ExecuteReader();
                while(rdr.Read()){
                    lista.Add(rdr["Ime"].ToString());
                    lista.Add(rdr["Autor"].ToString());
                }

            }

            return lista.Distinct().ToList(); // preciscava listu od duplikata
        }
    }
}
