using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AmorDoce.Models;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace AmorDoce.Controllers
{

    public class ProdutosController : Controller
    {

        Bd Bd = new Bd();


        public ActionResult Index()
        {
            //Criar comandos para chamar procedure

            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Cadastro(Produtos p)
        {
            Produtos prod = new Produtos
            {
                nome_produto = p.nome_produto,
                descricao_produto = p.descricao_produto,
                preco_produto = p.preco_produto,
                validade_produto = p.validade_produto,
            };

            Bd.InsereProdtuos(prod);

            return View();
        }

        public ActionResult Consultar()
        {
            var listaProdutos = new Bd();
            var todosProdutos = listaProdutos.BuscaProdutos();
            return View(todosProdutos);
        }

        public ActionResult Editar()
        {
            return View();
        }

        public ActionResult Excluir()
        {
            return View();
        }
        
    }
}