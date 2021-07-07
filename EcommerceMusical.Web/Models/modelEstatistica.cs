using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceMusical.Web.Models
{
    public class modelEstatistica
    {
        [Display(Name = "Valor total")]
        public string vl_venda { get; set; }

        [Display(Name = "Usuarios")]
        public string cd_usuario { get; set; }

        [Display(Name = "Funcionarios")]
        public string cd_funcionario { get; set; }

        [Display(Name = "Vendas")]
        public string cd_venda { get; set; }

        [Display(Name = "Quantidade")]
        public string qt_produto { get; set; }

        [Display(Name = "Código")]
        public string cd_produto { get; set; }

        [Display(Name = "Imagem")]
        public string img_produto { get; set; }

        [Display(Name = "Nome do produto")]
        public string nm_produto { get; set; }
    }
}