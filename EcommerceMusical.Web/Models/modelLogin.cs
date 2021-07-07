using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceMusical.Web.Models
{
	public class modelLogin
	{
        // login do cliente

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

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string tp_usuario { get; set; }

        // login do funcionario

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string eml_funcionario { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string sh_funcionario { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string tp_funcionario { get; set; }
    }
}