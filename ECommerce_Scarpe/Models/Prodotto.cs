using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace ECommerce_Scarpe.Models
{
    public class Prodotto
    {
        public int IdProdotto { get; set; }
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }
        public string Descrizione { get; set; }
        public string ImgCopertina { get; set; }
        public string ImgDettaglio1 { get; set; }
        public string ImgDettaglio2 { get; set; }
        public bool ControlloVendita { get; set; }
        public bool ControlloInProduzione { get; set; }

        public static List<Prodotto> ListaProdotti = new List<Prodotto>();

        public static List<Prodotto> SelectAllProdotti()
        {
            SqlConnection connetcionDB = new SqlConnection();
            connetcionDB.ConnectionString = ConfigurationManager.ConnectionStrings["ECommerce_Scarpe"].ToString();
            connetcionDB.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = "Select * from Prodotto";
            command.Connection = connetcionDB;

            SqlDataReader reader = command.ExecuteReader();

            Prodotto.ListaProdotti.Clear();

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    Prodotto product = new Prodotto();
                    product.IdProdotto = Convert.ToInt32(reader["IdProdotto"]);
                    product.Nome = reader["Nome"].ToString();
                    product.Prezzo = Convert.ToDecimal(reader["Prezzo"]);
                    product.Descrizione = reader["Descrizione"].ToString();
                    product.ImgCopertina = reader["ImgCopertina"].ToString();
                    product.ImgDettaglio1 = reader["ImgDettaglio1"].ToString();
                    product.ImgDettaglio2 = reader["ImgDettaglio2"].ToString();
                    product.ControlloVendita = Convert.ToBoolean(reader["ControlloVendita"]);
                    //product.ControlloInProduzione = Convert.ToBoolean(reader["ControlloInProduzione"]);
                    Prodotto.ListaProdotti.Add(product);
                }
            }

            connetcionDB.Close();
            return Prodotto.ListaProdotti;
        }

        public static Prodotto SelectSingleProdotto(int id)
        {
            SqlConnection connetcionDB = new SqlConnection();
            connetcionDB.ConnectionString = ConfigurationManager.ConnectionStrings["ECommerce_Scarpe"].ToString();
            connetcionDB.Open();

            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@IdProdotto", id);
            command.CommandText = "Select * from Prodotto Where IdProdotto = @IdProdotto";
            command.Connection = connetcionDB;

            SqlDataReader reader = command.ExecuteReader();
            Prodotto product = new Prodotto();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    product.IdProdotto = Convert.ToInt32(reader["IdProdotto"]);
                    product.Nome = reader["Nome"].ToString();
                    product.Prezzo = Convert.ToDecimal(reader["Prezzo"]);
                    product.Descrizione = reader["Descrizione"].ToString();
                    product.ImgCopertina = reader["ImgCopertina"].ToString();
                    product.ImgDettaglio1 = reader["ImgDettaglio1"].ToString();
                    product.ImgDettaglio2 = reader["ImgDettaglio2"].ToString();
                    product.ControlloVendita = Convert.ToBoolean(reader["ControlloVendita"]);
                    //product.ControlloInProduzione = Convert.ToBoolean(reader["ControlloInProduzione"]);                   
                }
            }

            connetcionDB.Close();
            return product;
        }
    }
}