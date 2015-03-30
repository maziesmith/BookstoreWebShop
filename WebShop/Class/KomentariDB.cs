using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop
{
    public class KomentariDB
    {
        ConnDB connDB = new ConnDB();

        public void InsertKomentarDB(int knjigaId, string ime, string komentar)
        {
            //(datetime('now', 'localtime'))

            string queryStringParametri = "INSERT INTO tblKomentari (KnjigaID,Ime,Komentar,Datum) ";
            string queryStringVrednosti = "VALUES('" + knjigaId + "','" + ime + "','" + komentar + "',(datetime('now', 'localtime')))";
            string queryString = queryStringParametri + queryStringVrednosti;

            connDB.InsertDataToDB(queryString);

        }

        public void DeleteKomentarDB(int id) // brisanje itema iz korpe
        {
            string queryString = "DELETE FROM tblKomentari WHERE ID=" + id + "";
            connDB.DeleteDataFromDB(queryString);
        }
    }

}