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
        [DisplayName("Tipo de Doce")]
        [Required(ErrorMessage = "Insira um nome para o doce")]
        public string nome_produto { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Insira uma descrição para o doce")]
        public string descricao_produto { get; set; }

        [DisplayName("Preço")]
        [Required(ErrorMessage = "Insira um preço para o doce")]
        public double preco_produto { get; set; }

        [DisplayName("Validade")]
        [Required(ErrorMessage = "Insira a validade para consumo do doce")]
        public DateTime validade_produto { get; set; }
        public string foto_caminho { get; set; }

        [DisplayName("Imagem do Doce")]
        [Required(ErrorMessage = "Insira uma imagem do doce")]
        public HttpPostedFileBase imagem { get;set;}

    }
}