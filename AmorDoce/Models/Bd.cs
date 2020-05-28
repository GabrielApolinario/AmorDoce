using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace AmorDoce.Models
{
    public class Bd
    {

        private readonly MySqlConnection con;

        public Bd()
        {
            con = new MySqlConnection(ConfigurationManager.ConnectionStrings["BdConexao"].ConnectionString);
        }

        public void InsereProdtuos(Produtos p)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("Insert_produto", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("nome_produto", p.nome_produto);
            cmd.Parameters.AddWithValue("descricao_produto", p.descricao_produto);
            cmd.Parameters.AddWithValue("preco_produto", p.preco_produto);
            cmd.Parameters.AddWithValue("data_validade", p.validade_produto);

            cmd.ExecuteNonQuery();
            con.Close();

        }

        public MySqlDataReader RetornaComando(string query)
        {
            var comando = new MySqlCommand(query, con);
            comando.CommandType = CommandType.StoredProcedure;
            return comando.ExecuteReader();

        }
        public List<Produtos> BuscaProdutos()
        {

            con.Open();
            var query = "Select_Produto";
            var retorno = RetornaComando(query);
            return ListaProdutos(retorno);



        }

        public List<Produtos> ListaProdutos(MySqlDataReader retorno)
        {
            var prod = new List<Produtos>();

            while (retorno.Read())
            {
                var tempProd = new Produtos()
                {
                    nome_produto = retorno["nome_produto"].ToString(),
                };
            prod.Add(tempProd);
            }

            retorno.Close();
            return prod;
        }

        public void Dispose()
        {
            con.Close();
        }

    }
}