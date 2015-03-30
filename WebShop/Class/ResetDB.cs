using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebShop.Class
{
    public class ResetDB
    {
        ConnDB connDB = new ConnDB();
        public void InsertResetDB(int korisnikID)
        {
            string queryString = "insert into tblReset (KorisnikID) values (" + korisnikID + ")";
            connDB.InsertDataToDB(queryString);
        }
        public DataSet GetResetDB(int korisnikID)
        {
            string queryString = "select * from tblReset (KorisnikID) values (" + korisnikID + ")";
             return connDB.GetDataFromDB(queryString);
        }
        public void DeleteResetDB(int korisnikID)
        {
            string queryString = "delete from tblReset where KorisnikID=" + korisnikID + ")";
            connDB.InsertDataToDB(queryString);
        }
    }
}