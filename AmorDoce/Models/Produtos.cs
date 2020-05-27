using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmorDoce.Models
{
    public class Produtos
    {

        public int id_produto { get; set; }

        public string nome_produto { get; set; }

        public string descricao_produto { get; set; }

        public double preco_produto { get; set; }

        public DateTime validade_produto { get; set; }

    }
}