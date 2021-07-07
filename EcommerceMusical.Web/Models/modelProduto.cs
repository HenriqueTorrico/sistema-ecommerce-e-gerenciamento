using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceMusical.Web.Models
{
    public class modelProduto
    {
        [Display(Name = "Código")]
        [Key]
        public string cd_produto { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string nm_produto { get; set; }

        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string cd_fornecedor { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string cd_categoria { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string mar_produto { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string qt_produto { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string vl_produto { get; set; }

        [Display(Name = "Imagem")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string img_produto { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(3000)]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string ds_produto { get; set; }

        [Display(Name = "Características")]
        [StringLength(2000)]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string car_produto { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "O campo é obrigatório!!")]
        public string cd_status { get; set; }


        [Display(Name = "Fornecedor")]
        public string nm_fornecedor { get; set; }

        [Display(Name = "Categoria")]
        public string nm_categoria { get; set; }

        [Display(Name = "Status")]
        public string nm_status { get; set; }







        [Display(Name = "Código")]
        [Key]
        public string cd_comentario { get; set; }

        [Display(Name = "Descrição")]
        public string ds_comentario { get; set; }

        [Display(Name = "Data")]
        public string dt_comentario { get; set; }

        [Display(Name = "Nome do Cliente")]
        public string cd_usuario { get; set; }

        [Display(Name = "Nome do Cliente")]
        public string nm_usuario { get; set; }

        [Display(Name = "Imagem")]
        public string img_usuario { get; set; }
    }
}