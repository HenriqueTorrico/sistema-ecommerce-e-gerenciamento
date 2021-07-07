using Correios.CEP;
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
    public class UsuarioController : Controller
    {
        // Instanciando tanto a classe Usuario de Dados quanto a modelUsuario de Models
        modelUsuario cad = new modelUsuario();
        Usuario acUsuario = new Usuario();

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

        // método de cadastrar um usuario
        public ActionResult cadastrarUsuario()
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
                    carregaGenero();
                    return View();
                }
            }
        }

        // ações ao clicar no botão de confirmar um cadastro
        [HttpPost]
        public ActionResult cadastrarUsuario(modelUsuario model, HttpPostedFileBase file)
        {
            carregaGenero();
            model.cd_genero = Request["genero"];
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    string arquivo = Path.GetFileName(file.FileName);
                    string file2 = "/ImagensUsuario/" + Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/ImagensUsuario"), arquivo);
                    file.SaveAs(_path);
                    model.img_usuario = file2;
                    acUsuario.inserirUsuario(model);
                    ViewBag.confCadastro = "Usuário cadastrado com sucesso";
                    return RedirectToAction("listarUsuario");
                }
                catch
                {
                    ViewBag.msg = "Não foi possivel cadastrar";
                    return View();
                }               
            }
            else
            {
                ViewBag.msg = "Para continuar adicione uma imagem";
                return View();
            }
        }

        // método de listar um usuario
        public ActionResult listarUsuario()
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
                    return View(acUsuario.listarUsuario());
                }
            }
        }

        // método de excluir um usuario
        public ActionResult excluirUsuario(int id)
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
                        if (acUsuario.excluirUsuario(id))
                        {
                            ViewBag.AlertMsg = "Usuário excluído com sucesso!!";
                        }
                        return RedirectToAction("listarUsuario");
                    }
                    catch
                    {
                        return View();
                    }
                }
            }
        }

        // método de atualizar um usuario
        public ActionResult atualizarUsuario(string id)
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
                    return View(acUsuario.listarUsuario().Find(model => model.cd_usuario == id));
                }
            }
        }

        // ações ao clicar no botão de confirmar uma atualização
        [HttpPost]
        public ActionResult atualizarUsuario(modelUsuario model, HttpPostedFileBase file)
        {
            string arquivo = Path.GetFileName(file.FileName);
            string file2 = "/ImagensUsuario/" + Path.GetFileName(file.FileName);
            string _path = Path.Combine(Server.MapPath("~/ImagensUsuario"), arquivo);
            file.SaveAs(_path);
            model.img_usuario = file2;

            carregaGenero();
            model.cd_genero = Request["genero"];

            acUsuario.atualizarUsuario(model);
            return RedirectToAction("listarUsuario");
        }
    }
}