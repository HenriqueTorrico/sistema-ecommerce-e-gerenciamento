using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceMusical.Web.Models
{
    public class modelFornecedor
    {
        [Display(Name = "Código")]
        [Key]
        public string cd_fornecedor { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string nm_fornecedor { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string tel_fornecedor { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string cnpj_fornecedor { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string cep_fornecedor { get; set; }

        [Display(Name = "Logradouro")]
        public string log_fornecedor { get; set; }

        [Display(Name = "Bairro")]
        public string bar_fornecedor { get; set; }

        [Display(Name = "Cidade")]
        public string cid_fornecedor { get; set; }

        [Display(Name = "UF")]
        public string uf_fornecedor { get; set; }
    }
}