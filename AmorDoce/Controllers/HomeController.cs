using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AmorDoce.Models;

namespace AmorDoce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Produtos p)
        {

            var listaProdutos = new Bd();
            var todosProdutos = listaProdutos.ProdutosIndex();

            var totalProdutos = todosProdutos.Count();

            if (totalProdutos == 0)
            {
                ViewBag.SemProdutos = "Os produtos cadastrados serão exibidos aqui";
                return View();
            }
            else
            {
                ViewBag.SemProdutos = "";
                return View(todosProdutos);
            }           
        }

    }
}