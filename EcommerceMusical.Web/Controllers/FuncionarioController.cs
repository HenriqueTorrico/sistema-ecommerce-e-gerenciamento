using EcommerceMusical.Web.Dados;
using EcommerceMusical.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceMusical.Web.Controllers
{
    public class FuncionarioController : Controller
    {
        // Instanciando tanto a classe Funcionario de Dados quanto a modelFuncionario de Models
        modelFuncionario cad = new modelFuncionario();
        Funcionario acFuncionario = new Funcionario();

        // método de listar os gêneros
        public void carregaGenero()
        {
            List<SelectListItem> genero = new List<SelectListItem>();
            using (MySqlConnection con = new MySqlConnection("Server = localhost; DataBase = db_lojaEcommerce; User = root; pwd= Clashroyale12"))
            {
                // Abrindo a conexao com o banco de dados
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbl_genero", con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    genero.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }
            ViewBag.genero = new SelectList(genero, "Value", "Text");
        }

        // método de cadastrar um funcionario
        public ActionResult cadastrarFuncionario()
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
                    carregaGenero();
                    return View();
                }
            }
        }

        // ações ao clicar no botão de confirmar um cadastro
        [HttpPost]
        public ActionResult cadastrarFuncionario(modelFuncionario model, HttpPostedFileBase file)
        {
            string arquivo = Path.GetFileName(file.FileName);
            string file2 = "/ImagensFuncionario/" + Path.GetFileName(file.FileName);
            string _path = Path.Combine(Server.MapPath("~/ImagensFuncionario"), arquivo);
            file.SaveAs(_path);
            model.img_funcionario = file2;

            carregaGenero();
            model.cd_genero = Request["genero"];

            acFuncionario.inserirFuncionario(model);

            ViewBag.confCadastro = "Funcionário cadastrado com sucesso";
            return RedirectToAction("listarFuncionario");
        }

        // método de listar um funcionario
        public ActionResult listarFuncionario()
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
                    Funcionario dbhandle = new Funcionario();
                    ModelState.Clear();
                    return View(dbhandle.listarFuncionario());
                }
            }
        }

        // método de excluir um funcionario
        public ActionResult excluirFuncionario(int id)
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
                        Funcionario sdb = new Funcionario();
                        if (sdb.excluirFuncionario(id))
                        {
                            ViewBag.AlertMsg = "Funcionário excluído com sucesso!!";
                        }
                        return RedirectToAction("listarFuncionario");
                    }
                    catch
                    {
                        return View();
                    }
                }
            }
        }

        // método de atualizar um funcionario
        public ActionResult atualizarFuncionario(string id)
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
                    carregaGenero();
                    return View(acFuncionario.listarFuncionario().Find(model => model.cd_funcionario == id));
                }
            }
        }

        // ações ao clicar no botão de confirmar uma atualização
        [HttpPost]
        public ActionResult atualizarFuncionario(modelFuncionario model, HttpPostedFileBase file)
        {
            string arquivo = Path.GetFileName(file.FileName);
            string file2 = "/ImagensFuncionario/" + Path.GetFileName(file.FileName);
            string _path = Path.Combine(Server.MapPath("~/ImagensFuncionario"), arquivo);
            file.SaveAs(_path);
            model.img_funcionario = file2;

            carregaGenero();
            model.cd_genero = Request["genero"];

            acFuncionario.atualizarFuncionario(model);
            return RedirectToAction("listarFuncionario");
        }
    }
}