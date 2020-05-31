using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AmorDoce.Models
{
    public class Produtos
    {
        [DisplayName("Produto")]
        public int id_produto { get; set; }
        [DisplayName("Nome do Bolo")]
        public string nome_produto { get; set; }
        [DisplayName("Descrição")]
        public string descricao_produto { get; set; }
        [DisplayName("Preço")]
        public double preco_produto { get; set; }

        [DisplayName("Validade")]

        public DateTime validade_produto { get; set; }
        public string foto_caminho { get; set; }

        [DisplayName("Imagem do bolo")]
        public HttpPostedFileBase imagem { get;set;}

    }
}