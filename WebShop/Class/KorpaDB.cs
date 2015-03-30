using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebShop
{
    public class KorpaDB
    {
        ConnDB connDB = new ConnDB();
        public DataSet GetKorpaDB(string parametar, string searchType) // prvi parametar predstavlja string koji trazimo u bazi. Drugi predstavlja tip pretrage odnosno kolonu, da li je id,mejl i td.
        {
            string queryString = "SELECT * FROM tblKorpa WHERE " + searchType + " LIKE '%" + parametar + "%'";

            return connDB.GetDataFromDB(queryString);
        }
        public DataSet GetKorpaPoKorisnikuDB(string id) ///id korisnika koji je ubacio u korpu
        {
            string queryString = "SELECT * FROM tblKorpa WHERE Poruceno=0 AND KorisnikID="+id+"";

            return connDB.GetDataFromDB(queryString);
        }
        public DataSet GetKorpaPoKorisnikuOFFSETDB(string id,string pocetni) ///id korisnika koji je ubacio u korpu
        {
            string queryString = "SELECT * FROM tblKorpa where KorisnikID='" + id + "' AND Poruceno=0 LIMIT " + pocetni + ",5";

            return connDB.GetDataFromDB(queryString);
        }

        public void InsertKorpaDB(string korisnikId, string knjigaId)
        {
            //(datetime('now', 'localtime'))

            string queryStringParametri = "INSERT INTO tblKorpa (KorisnikID,KnjigaID,DatumNarucivanja,Kupljena) ";
            string queryStringVrednosti = "VALUES('" + korisnikId + "','" + knjigaId + "',(datetime('now', 'localtime')),0)";
            string queryString = queryStringParametri + queryStringVrednosti;



            connDB.InsertDataToDB(queryString);

        }

        public void DeleteKorpaPoKnjiziDB(int id) // brisanje itema iz korpe
        {
            string queryString = "DELETE FROM tblKorpa WHERE KnjigaID=" + id.ToString() + "";
            connDB.DeleteDataFromDB(queryString);
        }
    }
    }
