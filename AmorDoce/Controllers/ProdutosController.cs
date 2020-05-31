using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AmorDoce.Models;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Configuration;

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

            string FileName = Path.GetFileNameWithoutExtension(p.imagem.FileName);

            string FileExtension = Path.GetExtension(p.imagem.FileName);

            FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + FileName.Trim() + FileExtension;

            string UploadPath = Server.MapPath("~/Imagens/");

            p.foto_caminho = UploadPath + FileName;
  
            p.imagem.SaveAs(p.foto_caminho);

            Produtos prod = new Produtos
            {
                nome_produto = p.nome_produto,
                descricao_produto = p.descricao_produto,
                preco_produto = p.preco_produto,
                validade_produto = p.validade_produto,
                foto_caminho = p.foto_caminho,
            };

            Bd.InsereProdutos(prod);

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

        [HttpPost]
        public ActionResult Editar(Produtos p)
        {
            Produtos prod = new Produtos
            {
                id_produto = p.id_produto,
                nome_produto = p.nome_produto,
                descricao_produto = p.descricao_produto,
                preco_produto = p.preco_produto,
                validade_produto = p.validade_produto,
            };

            Bd.EditaProdutos(prod);

            return RedirectToAction("Consultar");
        }


        public ActionResult Excluir(Produtos p)
        {
            Produtos prod = new Produtos
            {
                id_produto = p.id_produto,
            };

            Bd.ExcluirProdutos(prod);

            return RedirectToAction("Consultar");
        }
        
    }
}