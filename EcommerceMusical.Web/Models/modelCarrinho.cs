using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceMusical.Web.Models
{
    public class modelCarrinho
    {
        [Key]
        [Display(Name = "Código")]
        public Guid cd_carrinho { get; set; }

        [Display(Name = "Produto")]
        public string cd_produto { get; set; }

        [Display(Name = "Produto")]
        public string nm_produto { get; set; }

        [Display(Name = "Código da Veda")]
        public string cd_venda { get; set; }

        [Display(Name = "Valor Unitário")]
        public double vl_unitario { get; set; }

        [Display(Name = "Valor Total")]
        public double vl_parcial { get; set; }

        [Display(Name = "Quantidade")]
        public int qt_produto { get; set; }

        [Display(Name = "Imagem do Produo")]
        public string img_produto { get; set; }
    }
}