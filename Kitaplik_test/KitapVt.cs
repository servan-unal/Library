using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Kitaplik_test
{
    class KitapVt
    {
        OleDbConnection baglanti = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\savaş\Desktop\Kitaplik.accdb");
        public List<Kitap> Liste()
        {
            List<Kitap> ktp = new List<Kitap>();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * From Kitaplar", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Kitap k = new Kitap();
                k.ID = Convert.ToInt16(dr[0].ToString());
                k.ADI = dr[1].ToString();
                k.YAZARI = dr[2].ToString();

                ktp.Add(k);
            }
            baglanti.Close();
            return ktp;
        }
        public void KitapEkle(Kitap kt)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into Kitaplar (KitapAd, Yazar) values (@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1", kt.ADI);
            komut.Parameters.AddWithValue("@p2", kt.YAZARI);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}

