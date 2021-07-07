using EcommerceMusical.Web.Dados;
using EcommerceMusical.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceMusical.Web.Controllers
{
    public class ComentarioController : Controller
    {
        // Instanciando tanto a classe Comentario de Dados quanto a modeComentario de Models
        modelProduto cad = new modelProduto();
        Comentario acComentario = new Comentario();

        // método de cadastrar um produto
        public ActionResult cadastrarComentario()
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Session["tipoFuncionario"] != null || Session["tipoGerente"] != null)
                {
                    return RedirectToAction("semAcesso", "Login");
                }
                else
                {
                    ViewBag.cd_usuario = Session["codigo"];
                    return View();
                }
            }
        }

        // ações ao clicar no botão de confirmar um cadastro
        [HttpPost]
        public ActionResult cadastrarComentario(modelProduto model)
        {
            model.dt_comentario = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy");
            acComentario.inserirComentario(model);
            ViewBag.msg = "Comentário cadastrado com sucesso";
            return RedirectToAction("Detalhes", "Login");
        }

        // método de listar um comentario
        public ActionResult listarComentario()
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
                    ModelState.Clear();
                    return View(acComentario.listarComentario());
                }
            }
        }

        // método de excluir um comentario
        public ActionResult excluirComentario(int id)
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
                        if (acComentario.excluirComentario(id))
                        {
                            ViewBag.AlertMsg = "Comentário excluído com sucesso!!";
                        }
                        return RedirectToAction("listarComentario");
                    }
                    catch
                    {
                        return View();
                    }
                }
            }
        }
    }
}