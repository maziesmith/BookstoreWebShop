using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;



namespace WebShop
{
    public class KorisnikDB // operacije nad korisnikom (drugi lejer)
    {
        ConnDB connDB = new ConnDB();
        public DataSet GetKorisnikDB(string parametar,string searchType) // prvi parametar predstavlja string koji trazimo u bazi. Drugi predstavlja tip pretrage odnosno kolonu, da li je id,mejl i td.
        {
            string queryString = "SELECT FROM tblKorisnik WHERE " + searchType + " LIKE '%" + parametar + "%'";

            return connDB.GetDataFromDB(queryString);
        }
        public DataSet GetKorisnikLOGINDB(string email,string password) 
        {
            string queryString = "SELECT * FROM tblKorisnik WHERE Email='" + email + "' AND Password='" + password + "'";

            return connDB.GetDataFromDB(queryString);
        }
        public DataSet GetKorisnikPoEmailuDB(string email)
        {
            string queryString = "SELECT * FROM tblKorisnik WHERE Email='"+email+"'";

            return connDB.GetDataFromDB(queryString);
        }
        public void InsertKorisnikDB(string ime,string prezime,string datumRodjenja,string grad,string adresa,string brojStana,int postanskiBroj,int telefon,string email,string password)
        {
            //(datetime('now', 'localtime'))

            string queryStringParametri = "INSERT INTO tblKorisnik (Ime,Prezime,DatumRodjenja,Grad,Adresa,BrojStana,PostanskiBroj,Telefon,Email,Password,DatumKreiranja,Verifikacija,AdminPristup) ";
            string queryStringVrednosti = "VALUES('" + ime + "','" + prezime + "','" + datumRodjenja + "','" + grad + "','" + adresa + "','" + brojStana + "'," + postanskiBroj + "," + telefon + ",'" + email + "','" + password + "',(datetime('now', 'localtime')),0,0)";
            string queryString = queryStringParametri + queryStringVrednosti;


            
            connDB.InsertDataToDB(queryString);

        }

        public void UpdateKorisnikDB(int id,string ime,string prezime,string datumRodjenja,string grad,string adresa,string brojStana,int postanskiBroj,int telefon,string email,string password)
        {
            string queryString = "UPDATE tblKorisnik SET Ime='"+ime+"',Prezime='"+prezime+"',DatumRodjenja='"+datumRodjenja+"',Grad='"+grad+"',Adresa='"+adresa+"',BrojStana='"+adresa+"',PostanskiBroj="+postanskiBroj+",Telefon="+telefon+",Email='"+email+"',Password='"+password+"' WHERE ID="+id+"";
            
            connDB.UpdateDataFromDB(queryString);
        }

        public void DeleteKorisnikDB(string id)
        {
            string queryString = "DELETE FROM tblKorisnik WHERE ID='"+id+"'";
            connDB.DeleteDataFromDB(queryString);
        }
    }
}