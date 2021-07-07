using EcommerceMusical.Web.Dados;
using EcommerceMusical.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceMusical.Web.Controllers
{
    public class VendaController : Controller
    {
        // Instanciando a classe Produto de Dados
        Venda acVenda = new Venda();
        modelVenda cad = new modelVenda();

        // método de listar um produto
        public ActionResult listarVenda(int? pagina)
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Session["tipoFuncionario"] == null && Session["tipoGerente"] == null)
                {
                    return RedirectToAction("semAcesso", "Login");
                }
                else
                {
                    return View(acVenda.listarVenda());
                }
            }
        }
    }
}