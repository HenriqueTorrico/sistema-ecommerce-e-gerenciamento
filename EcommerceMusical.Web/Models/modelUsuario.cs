using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceMusical.Web.Models
{
    public class modelUsuario
    {
        [Display(Name = "Código")]
        [Key]
        public string cd_usuario { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string nm_usuario { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string cpf_usuario { get; set; }

        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string cd_genero { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string cel_usuario { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string eml_usuario { get; set; }

        [Display(Name = "Imagem")]
        public string img_usuario { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string cep_usuario { get; set; }

        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string log_usuario { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string bar_usuario { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string cid_usuario { get; set; }

        [Display(Name = "UF")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string uf_usuario { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string sh_usuario { get; set; }


        [Display(Name = "Gênero")]
        public string nm_genero { get; set; }

        [Display(Name = "Produto")]
        public string nm_produto { get; set; }

        [Display(Name = "Valor do Produto")]
        public string vl_produto { get; set; }

        [Display(Name = "Quantidade")]
        public string qt_produto { get; set; }

        [Display(Name = "Valor total")]
        public string vl_venda { get; set; }

        [Display(Name = "Data")]
        public string dt_venda { get; set; }

        [Display(Name = "Hora")]
        public string hr_venda { get; set; }

        [Display(Name = "Imagem")]
        public string img_produto { get; set; }

        [Display(Name = "Código da venda")]
        public string cd_venda { get; set; }
    }
}