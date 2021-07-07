using EcommerceMusical.Web.Dados;
using EcommerceMusical.Web.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceMusical.Web.Controllers
{
    public class HomeController : Controller
    {
        // Instanciando tanto a classe Produto de Dados
        Produto acProduto = new Produto();
        Comentario acComentario = new Comentario();
        Estatistica acEstatistica = new Estatistica();

        // Página Index do site
        public ActionResult Index()
        {
            ViewBag.destaques = acProduto.listarProdutoDestaque();
            ViewBag.lancamento = acProduto.listarProdutoLancamento();
            ViewBag.ofertas = acProduto.listarProdutoOfertas();
            ViewBag.premium = acProduto.listarProdutoPremium();
            ViewBag.comentarios = acComentario.listarComentario();

            return View();
        }

        // Página Sobre do site
        public ActionResult Sobre()
        {
            return View();
        }

        // Página Contato do site
        public ActionResult Contato()
        {
            return View();
        }

        // Página do painel de controle do sistema
        public ActionResult Painel_de_Controle()
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Session["tipoFuncionario"] == null && (Session["tipoGerente"] == null))
                {
                    return RedirectToAction("semAcesso", "Login");
                }
                else
                {
                    ViewBag.vendasTotais = acEstatistica.listarVendasTotais();
                    ViewBag.usuariosTotais = acEstatistica.listarUsuariosTotais();
                    ViewBag.funcionariosTotais = acEstatistica.listarFuncionariosTotais();
                    ViewBag.valorTotalVenda = acEstatistica.listarValorVendas();
                    ViewBag.estoque = acEstatistica.listarEstoque();
                    return View();
                }
            }
        }
    }
}