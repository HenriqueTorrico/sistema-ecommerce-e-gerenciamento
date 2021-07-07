using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceMusical.Web.Models
{
    public class modelVenda
    {
        [Display(Name = "Código da Venda")]
        [Key]
        public string cd_venda { get; set; }

        [Display(Name = "Cliente")]
        public string cd_usuario { get; set; }

        [Display(Name = "Data")]
        public string dt_venda { get; set; }

        [Display(Name = "Hora")]
        public string hr_venda { get; set; }

        [Display(Name = "Valor Total")]
        public double vl_venda { get; set; }

        public List<modelCarrinho> ItensPedido = new List<modelCarrinho>();

        [Display(Name = "Cliente")]
        public string nm_usuario { get; set; }

        [Display(Name = "CPF")]
        public string cpf_usuario { get; set; }

        [Display(Name = "Imagem do Produto")]
        public string img_produto { get; set; }
    }
}