using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AmorDoce.BancoDeDados;

namespace AmorDoce.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos
        public ActionResult Index()
        {
            //Criar comandos para chamar procedure

            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }
    }
}