using EcommerceMusical.Web.Dados;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceMusical.Web.Controllers
{
    public class EstatisticaController : Controller
    {
        Estatistica acEstatistica = new Estatistica();

        public ActionResult Estoque(int? pagina)
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
                    int tamanhoPagina = 9;
                    int numeroPagina = pagina ?? 1;
                    return View(acEstatistica.listarProdutosEstoque().ToPagedList(numeroPagina, tamanhoPagina));
                }
            }
        }
    }
}