using EcommerceMusical.Web.Dados;
using EcommerceMusical.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceMusical.Web.Controllers
{
    public class FornecedorController : Controller
    {
        // Instanciando tanto a classe Fornecedor de Dados quanto a modelFornecedor de Models
        modelFornecedor cad = new modelFornecedor();
        Fornecedor acFornecedor = new Fornecedor();

        // método de cadastrar um fornecedor
        public ActionResult cadastrarFornecedor()
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
        public ActionResult cadastrarFornecedor(modelFornecedor model)
        {
            try
            {
                acFornecedor.inserirFornecedor(model);

                ViewBag.confCadastro = "Fornecedor cadastrado com sucesso";
                return RedirectToAction("listarFornecedor");
            }
            catch
            {
                return View();
            }
        }

        // método de listar um fornecedor
        public ActionResult listarFornecedor()
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
                    Fornecedor dbhandle = new Fornecedor();
                    ModelState.Clear();
                    return View(dbhandle.listarFornecedor());
                }
            }
        }

        // método de excluir um fornecedor
        public ActionResult excluirFornecedor(int id)
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
                        Fornecedor sdb = new Fornecedor();
                        if (sdb.excluirFornecedor(id))
                        {
                            ViewBag.AlertMsg = "Fornecedor excluído com sucesso!!";
                        }
                        return RedirectToAction("listarFornecedor");
                    }
                    catch
                    {
                        return View();
                    }
                }
            }
        }

        // método de atualizar um fornecedor
        public ActionResult atualizarFornecedor(string id)
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
                    Fornecedor sdb = new Fornecedor();
                    return View(sdb.listarFornecedor().Find(model => model.cd_fornecedor == id));
                }
            }
        }

        // ações ao clicar no botão de confirmar uma atualização
        [HttpPost]
        public ActionResult atualizarFornecedor(int id, modelFornecedor model)
        {
            try
            {
                Fornecedor sdb = new Fornecedor();
                sdb.atualizarFornecedor(model);
                return RedirectToAction("listarFornecedor");
            }
            catch
            {
                return View();
            }
        }
    }
}