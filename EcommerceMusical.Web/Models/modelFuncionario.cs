using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceMusical.Web.Models
{
    public class modelFuncionario
    {
        [Display(Name = "Código")]
        [Key]
        public string cd_funcionario { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string nm_funcionario { get; set; }

        [Display(Name = "Idade")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string ida_funcionario { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string cpf_funcionario { get; set; }

        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string cd_genero { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string cel_funcionario { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string eml_funcionario { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string sh_funcionario { get; set; }

        [Display(Name = "Imagem")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string img_funcionario { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string cep_funcionario { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string tp_funcionario { get; set; }

        [Display(Name = "Gênero")]
        public string nm_genero { get; set; }
    }
}