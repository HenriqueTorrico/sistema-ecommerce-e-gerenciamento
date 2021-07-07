using EcommerceMusical.Web.Dados;
using EcommerceMusical.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceMusical.Web.Controllers
{
    public class CategoriaController : Controller
    {
        // Instanciando tanto a classe Categoria de Dados quanto a modelCategoria de Models
        modelCategoria cad = new modelCategoria();
        Categoria acCategoria = new Categoria();

        // método de cadastrar uma categoria
        public ActionResult cadastrarCategoria()
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Session["tipoGerente"] == null)
                {
                    return RedirectToAction("semAcesso", "Login");
                }
                else
                {
                    return View();
                }
            }
        }

        // ações ao clicar no botão de confirmar um cadastro
        [HttpPost]
        public ActionResult cadastrarCategoria(modelCategoria model)
        {
            acCategoria.inserirCategoria(model);

            ViewBag.confCadastro = "Categoria cadastrada com sucesso";
            return RedirectToAction("listarCategoria");
        }

        // método de listar uma categoria
        public ActionResult listarCategoria()
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
                    return View(acCategoria.listarCategoria());
                }
            }
        }

        // método de excluir uma categoria
        public ActionResult excluirCategoria(int id)
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Session["tipoGerente"] == null)
                {
                    return RedirectToAction("semAcesso", "Login");
                }
                else
                {
                    try
                    {
                        if (acCategoria.excluirCategoria(id))
                        {
                            ViewBag.AlertMsg = "Categoria excluída com sucesso!!";
                        }
                        return RedirectToAction("listarCategoria");
                    }
                    catch
                    {
                        return View();
                    }
                }
            }
        }

        // método de atualizar uma categoria
        public ActionResult atualizarCategoria(string id)
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Session["tipoGerente"] == null)
                {
                    return RedirectToAction("semAcesso", "Login");
                }
                else
                {
                    return View(acCategoria.listarCategoria().Find(model => model.cd_categoria == id));
                }
            }
        }

        // ações ao clicar no botão de confirmar uma atualização
        [HttpPost]
        public ActionResult atualizarCategoria(modelCategoria model)
        {
            try
            {
                acCategoria.atualizarCategoria(model);
                return RedirectToAction("listarCategoria");
            }
            catch
            {
                return View();
            }
        }
    }
}