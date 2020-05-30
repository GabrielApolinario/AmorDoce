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

        public void InsereProdutos(Produtos p)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("Insert_produto", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("nome_produto", p.nome_produto);
            cmd.Parameters.AddWithValue("descricao_produto", p.descricao_produto);
            cmd.Parameters.AddWithValue("preco_produto", p.preco_produto);
            cmd.Parameters.AddWithValue("data_validade", p.validade_produto);
            cmd.Parameters.AddWithValue("foto_caminho", p.foto_caminho);


            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void ExcluirProdutos(Produtos p)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("Delete_produto", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("id_produto", p.id_produto);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void EditaProdutos(Produtos p)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("Update_produto", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("proc_id_produto", p.id_produto);
            cmd.Parameters.AddWithValue("novo_nome_produto", p.nome_produto);
            cmd.Parameters.AddWithValue("novo_descricao_produto", p.descricao_produto);
            cmd.Parameters.AddWithValue("novo_preco_produto", p.preco_produto);
            cmd.Parameters.AddWithValue("novo_data_validade", p.validade_produto);
            

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
                    id_produto = Convert.ToInt32(retorno["id_produto"]),
                    nome_produto = retorno["nome_produto"].ToString(),
                    descricao_produto = retorno["descricao_produto"].ToString(),
                    validade_produto = Convert.ToDateTime(retorno["data_validade"].ToString()),
                    preco_produto = Convert.ToDouble(retorno["preco_produto"]),

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