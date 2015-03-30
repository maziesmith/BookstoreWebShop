using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;



namespace WebShop
{
    public class KnjigaDB // operacije nad knjigama (drugi lejer)
    {
        ConnDB connDB = new ConnDB();
        public DataSet GetKnjigeLikeDB(string parametar, string searchType) // prvi parametar predstavlja string koji trazimo u bazi. Drugi predstavlja tip pretrage odnosno kolonu, da li je id,mejl i td.
        {
            string queryString = "SELECT * FROM tblKnjige WHERE " + searchType + " LIKE '%" + parametar + "%'";

            return connDB.GetDataFromDB(queryString);
        }
        public DataSet GetKnjigeDB(string id) //po id
        {
            string queryString = "SELECT * FROM tblKnjige WHERE ID=" + id;

            return connDB.GetDataFromDB(queryString);
        }
        public DataSet GetKnjigeOFFSETDB(string pocetni,string koliko,string tip) 
        {
            // funkcija koja iz baze redove koji imaju tip knjige iz parametara i sa pocetnim elementom i zavrsnim
            string queryString = "SELECT * FROM tblKnjige where TipKnjige='"+tip+"' LIMIT " + pocetni + ",10";

            return connDB.GetDataFromDB(queryString);
        }

        public DataSet GetKnjigeOFFSEakcijaTDB(string pocetni, string koliko, string tip)
        {
            // funkcija koja iz baze redove koji imaju tip knjige iz parametara i sa pocetnim elementom i zavrsnim
            string queryString = "SELECT * FROM tblKnjige where Akcija='" + tip + "' LIMIT " + pocetni + ",10";

            return connDB.GetDataFromDB(queryString);
        }
        public DataSet GetKnjigePoTipuDB(string tip) //po tipu domaca ili sta
        {
            string queryString = "SELECT * FROM tblKnjige WHERE TipKnjige='" + tip+"'";

            return connDB.GetDataFromDB(queryString);
        }
        public DataSet GetKnjigeAkcijaDB() //po tipu domaca ili sta
        {
            string queryString = "SELECT * FROM tblKnjige WHERE Akcija=1";

            return connDB.GetDataFromDB(queryString);
        }

        public void InsertKnjiguDB(string ime, string autor, string izdavac, string isbn, string opis, double cena, double cenaSnizena, string slika, string tipKnjige,int akcija)
        {
            //(datetime('now', 'localtime'))

            string queryStringParametri = "INSERT INTO tblKnjige (Ime,Autor,Izdavac,ISBN,DatumPostavljanja,Opis,Cena,CenaSnizena,Slika,TipKnjige,Akcija,NovaKnjiga) ";
            string queryStringVrednosti = "VALUES('" + ime + "','" + autor + "','" + izdavac + "','" + isbn + "',(datetime('now', 'localtime')),'" + opis + "'," + cena + "," + cenaSnizena + ",'" + slika + "','" + tipKnjige + "'," + akcija + ",0)";
            string queryString = queryStringParametri + queryStringVrednosti;



            connDB.InsertDataToDB(queryString);

        }

        public void UpdateKnjigaDB(string id, string ime, string autor, string izdavac, string isbn, string opis, double cena, double cenaSnizena, string slika, string tipKnjige, int akcija)
        {
            string queryString12 = "UPDATE tblKnjige SET Ime='" + ime + "',Autor='" + autor + "',Izdavac='" + izdavac + "',ISBN='" + isbn + "',Opis='" + opis + "',Cena=" + cena + ",CenaSnizena=" + cenaSnizena + ",Slika='" + slika + "',TipKnjige='" +tipKnjige+ "',Akcija=" + akcija + " WHERE ID="+id+"";

            connDB.UpdateDataFromDB(queryString12);
            queryString1 = queryString12;
        }

        public void DeleteKnjiguDB(string id)
        {
            string queryString = "DELETE FROM tblKnjige WHERE ID=" + id + "";
            connDB.DeleteDataFromDB(queryString);
        }
        public string queryString1
        {
            get;
            set;
        }
    }
}