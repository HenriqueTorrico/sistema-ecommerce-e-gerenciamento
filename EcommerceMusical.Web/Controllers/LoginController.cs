using EcommerceMusical.Web.Dados;
using EcommerceMusical.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EcommerceMusical.Web.Controllers
{
    public class LoginController : Controller
    {
        // instanciando tanto a classe Login de Dados quanto a modelLogin de Models
        modelLogin cad = new modelLogin();
        Login acLogin = new Login();
        Usuario acUsuario = new Usuario();
        Carrinho acCarrinho = new Carrinho();

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

        // método de login do Cliente
        public ActionResult Login()
        {
            return View();
        }

        // ações ao clicar no botão de confirmar o login
        [HttpPost]
        public ActionResult Login(modelLogin verLogin)
        {
            acLogin.testarUsuario(verLogin);

            if (verLogin.eml_usuario != null && verLogin.sh_usuario != null)
            {
                FormsAuthentication.SetAuthCookie(verLogin.eml_usuario, false);              
                Session["usuarioLogado"] = verLogin.eml_usuario.ToString();
                Session["senhaLogado"] = verLogin.sh_usuario.ToString();

                Session["codigo"] = verLogin.cd_usuario.ToString();
                Session["nome"] = verLogin.nm_usuario.ToString();
                Session["cpf"] = verLogin.cpf_usuario.ToString();
                Session["genero"] = verLogin.cd_genero.ToString();
                Session["celular"] = verLogin.cel_usuario.ToString();
                Session["email"] = verLogin.eml_usuario.ToString();
                Session["imagem"] = verLogin.img_usuario.ToString();
                Session["cep"] = verLogin.cep_usuario.ToString();
                Session["logradouro"] = verLogin.log_usuario.ToString();
                Session["bairro"] = verLogin.bar_usuario.ToString();
                Session["cidade"] = verLogin.cid_usuario.ToString();
                Session["uf"] = verLogin.uf_usuario.ToString();
                Session["senha"] = verLogin.sh_usuario.ToString();

                if (verLogin.tp_usuario == "Gerente")
                {
                    Session["tipoGerente"] = verLogin.tp_usuario.ToString(); // tipo de usuário gerente
                    return RedirectToAction("Painel_de_Controle", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            else
            {
                Response.Write("<script>alert('Usuário não encontrado. Verifique o nome do usuário e a senha')</script>");
                return View();
            }
        }

        // método de caso a pessoa não tenha o acesso nescessário
        public ActionResult semAcesso()
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                Response.Write("<script>alert('Você não tem acesso a está operação')</script>");
                return View();
            }
        }

        // método de logout
        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            Session["senhaLogado"] = null;
            Session[""] = null;
            Session["tipoFuncionario"] = null;
            Session["tipoGerente"] = null;
            return RedirectToAction("Index", "Home");
        }

        // método de mostrar os detalhes do perfil do usuario
        public ActionResult Detalhes()
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                ViewBag.cd_usuario = Session["codigo"];
                ViewBag.nm_usuario = Session["nome"];
                ViewBag.cpf_usuario = Session["cpf"];
                ViewBag.nm_genero = Session["genero"];
                ViewBag.cel_usuario = Session["celular"];
                ViewBag.eml_usuario = Session["email"];
                ViewBag.img_usuario = Session["imagem"];
                ViewBag.cep_usuario = Session["cep"];
                ViewBag.log_usuario = Session["logradouro"];
                ViewBag.bar_usuario = Session["bairro"];
                ViewBag.cid_usuario = Session["cidade"];
                ViewBag.uf_usuario = Session["uf"];
                ViewBag.sh_usuario = Session["senha"];

                return View();
            }
        }

        // método de carregar o historico de compras
        public ActionResult Historico()
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                ViewBag.nm_usuario = Session["nome"];
                string id = Session["codigo"].ToString();
                ModelState.Clear();
                return View(acUsuario.listarInformacaoesCarrinho(id));
            }
        }

        // método de carregar os itens da compra
        public ActionResult Itens(int id)
        {
            ModelState.Clear();
            return View(acCarrinho.buscaItens(id));
        }

        // método de cadastrar um usuario
        public ActionResult cadastroUsuario()
        {
            carregaGenero();
            return View();
        }

        // ações ao clicar no botão de confirmar um cadastro
        [HttpPost]
        public ActionResult cadastroUsuario(modelUsuario model, HttpPostedFileBase file)
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
                    return RedirectToAction("Login");
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

        // método de atualizar um usuario
        public ActionResult atualizarUsuario()
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                ViewBag.cd_usuario = Session["codigo"];
                ViewBag.nm_usuario = Session["nome"];
                ViewBag.cpf_usuario = Session["cpf"];
                ViewBag.nm_genero = Session["genero"];
                ViewBag.cel_usuario = Session["celular"];
                ViewBag.eml_usuario = Session["email"];
                ViewBag.img_usuario = Session["imagem"];
                ViewBag.cep_usuario = Session["cep"];
                ViewBag.log_usuario = Session["logradouro"];
                ViewBag.bar_usuario = Session["bairro"];
                ViewBag.cid_usuario = Session["cidade"];
                ViewBag.uf_usuario = Session["uf"];
                ViewBag.sh_usuario = Session["senha"];

                carregaGenero();
                return View();
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
            return RedirectToAction("Detalhes");
        }

        // método de login do funcionario
        public ActionResult LoginFuncionario()
        {
            return View();
        }

        // ações ao clicar no botão de confirmar o login
        [HttpPost]
        public ActionResult LoginFuncionario(modelLogin verLogin)
        {
            acLogin.testarUsuarioFuncionario(verLogin);

            if (verLogin.eml_funcionario != null && verLogin.sh_funcionario != null)
            {
                FormsAuthentication.SetAuthCookie(verLogin.eml_funcionario, false);
                Session["usuarioLogado"] = verLogin.eml_funcionario.ToString();
                Session["senhaLogado"] = verLogin.sh_funcionario.ToString();

                if (verLogin.tp_funcionario == "Funcionario")
                {
                    Session["tipoFuncionario"] = verLogin.tp_funcionario.ToString(); // tipo de usuário funcionário
                    return RedirectToAction("Painel_de_Controle", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            else
            {
                Response.Write("<script>alert('Usuário não encontrado. Verifique o nome do usuário e a senha')</script>");
                return View();
            }
        }
    }
}