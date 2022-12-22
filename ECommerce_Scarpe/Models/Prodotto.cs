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

        public static void EditSingleProdtto(Prodotto product)
        {
            SqlConnection connetcionDB = new SqlConnection();
            connetcionDB.ConnectionString = ConfigurationManager.ConnectionStrings["ECommerce_Scarpe"].ToString();
            connetcionDB.Open();

            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@IdProdotto", product.IdProdotto);
            command.Parameters.AddWithValue("@Nome", product.Nome);
            command.Parameters.AddWithValue("@Prezzo", product.Prezzo);
            command.Parameters.AddWithValue("@Descrizione", product.Descrizione);
            command.Parameters.AddWithValue("@ImgCopertina", product.ImgCopertina);
            command.Parameters.AddWithValue("@ImgDettaglio1", product.ImgDettaglio1);
            command.Parameters.AddWithValue("@ImgDettaglio2", product.ImgDettaglio2);
            command.Parameters.AddWithValue("@ControlloVendita", product.ControlloVendita);
            command.CommandText = "Update Prodotto Set Nome = @Nome, Prezzo = @Prezzo, Descrizione = @Descrizione, ImgCopertina = @ImgCopertina, ImgDettaglio1 = @ImgDettaglio1, ImgDettaglio2 = @ImgDettaglio2, ControlloVendita = @ControlloVendita where IdProdotto = @IdProdotto";
            command.Connection = connetcionDB;

           command.ExecuteNonQuery();


            connetcionDB.Close();
        }

        public static void AddSingleProdtto(Prodotto product)
        {
            SqlConnection connetcionDB = new SqlConnection();
            connetcionDB.ConnectionString = ConfigurationManager.ConnectionStrings["ECommerce_Scarpe"].ToString();
            connetcionDB.Open();

            SqlCommand command = new SqlCommand();
            //command.Parameters.AddWithValue("@IdProdotto", product.IdProdotto);
            command.Parameters.AddWithValue("@Nome", product.Nome);
            command.Parameters.AddWithValue("@Prezzo", product.Prezzo);
            command.Parameters.AddWithValue("@Descrizione", product.Descrizione);
            command.Parameters.AddWithValue("@ImgCopertina", product.ImgCopertina);
            command.Parameters.AddWithValue("@ImgDettaglio1", product.ImgDettaglio1);
            command.Parameters.AddWithValue("@ImgDettaglio2", product.ImgDettaglio2);
            command.Parameters.AddWithValue("@ControlloVendita", product.ControlloVendita);
            command.CommandText = "Insert Into Prodotto (Nome,  Prezzo, Descrizione, ImgCopertina, ImgDettaglio1, ImgDettaglio2, ControlloVendita) Values (@Nome,  @Prezzo, @Descrizione, @ImgCopertina, @ImgDettaglio1, @ImgDettaglio2, @ControlloVendita)";
            command.Connection = connetcionDB;

            command.ExecuteNonQuery();


            connetcionDB.Close();
        }
    }
}