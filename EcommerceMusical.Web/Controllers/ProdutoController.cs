using EcommerceMusical.Web.Dados;
using EcommerceMusical.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace EcommerceMusical.Web.Controllers
{
    public class ProdutoController : Controller
    {
        // Instanciando a classe Produto de Dados
        Produto acProduto = new Produto();
        modelProduto cad = new modelProduto();

        // método de listar as categorias
        public void carregaCategoria()
        {
            List<SelectListItem> categoria = new List<SelectListItem>();
            using (MySqlConnection con = new MySqlConnection("Server = localhost; DataBase = db_lojaEcommerce; User = root; pwd= Clashroyale12"))
            {
                // Abrindo a conexao com o banco de dados
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbl_categoria", con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    categoria.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }
            ViewBag.categoria = new SelectList(categoria, "Value", "Text");
        }

        // método de listar os fornecedores
        public void carregaFornecedor()
        {
            List<SelectListItem> fornecedor = new List<SelectListItem>();
            using (MySqlConnection con = new MySqlConnection("Server = localhost; DataBase = db_lojaEcommerce; User = root; pwd= Clashroyale12"))
            {
                // Abrindo a conexao com o banco de dados
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbl_fornecedor", con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    fornecedor.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }
            ViewBag.fornecedor = new SelectList(fornecedor, "Value", "Text");
        }

        // método de listar os status
        public void carregaStatus()
        {
            List<SelectListItem> status = new List<SelectListItem>();
            using (MySqlConnection con = new MySqlConnection("Server = localhost; DataBase = db_lojaEcommerce; User = root; pwd= Clashroyale12"))
            {
                // Abrindo a conexao com o banco de dados
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbl_statusProduto", con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    status.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }
            ViewBag.status = new SelectList(status, "Value", "Text");
        }

        // método de cadastrar um produto
        public ActionResult cadastrarProduto()
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
                    carregaCategoria();
                    carregaFornecedor();
                    carregaStatus();
                    return View();
                }
            }
        }

        // ações ao clicar no botão de confirmar um cadastro
        [HttpPost]
        public ActionResult cadastrarProduto(modelProduto md, HttpPostedFileBase file)
        {
            carregaCategoria();
            carregaFornecedor();
            carregaStatus();
            md.cd_categoria = Request["categoria"];
            md.cd_fornecedor = Request["fornecedor"];
            md.cd_status = Request["status"];

            if(file != null && file.ContentLength > 0)
            {
                try
                {
                    string arquivo = Path.GetFileName(file.FileName);
                    string file2 = "/ImagensProduto/" + Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/ImagensProduto"), arquivo);
                    file.SaveAs(_path);
                    md.img_produto = file2;
                    acProduto.inserirProduto(md);
                    ViewBag.msg = "Produto cadastrado com sucesso";
                    return RedirectToAction("listarProduto");
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

        // método de buscar um produto
        public ActionResult buscarProduto()
        {
            return View();
        }

        // ações ao clicar no botão de confirmar a pesquisa
        [HttpPost]
        public ActionResult buscarProduto(modelProduto model, FormCollection frm)
        {
            model.nm_produto = frm["nomeProduto"];
            return View(acProduto.buscarProduto(model));
        }

        // método de listar um produto
        public ActionResult listarProduto(int? pagina)
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
                    int tamanhoPagina = 10;
                    int numeroPagina = pagina ?? 1;
                    return View(acProduto.listarProduto().ToPagedList(numeroPagina, tamanhoPagina));
                }
            }
        }

        // método de detalhes do produto
        public ActionResult detalhesProduto(string id)
        {
            return View(acProduto.listarProduto().Find((model => model.cd_produto == id)));
        }

        // método de excluir um produto
        public ActionResult excluirProduto(int id)
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
                        if (acProduto.excluirProduto(id))
                        {
                            ViewBag.AlertMsg = "Produto excluído com sucesso!!";
                        }
                        return RedirectToAction("listarProduto");
                    }
                    catch
                    {
                        return View();
                    }
                }
            }
        }

        // método de atualizar um produto
        public ActionResult atualizarProduto(string id)
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
                    carregaCategoria();
                    carregaFornecedor();
                    carregaStatus();

                    return View(acProduto.listarProduto().Find(model => model.cd_produto == id));
                }
            }
        }

        // ações ao clicar no botão de confirmar uma atualização
        [HttpPost]
        public ActionResult atualizarProduto(modelProduto model, HttpPostedFileBase file)
        {
            string arquivo = Path.GetFileName(file.FileName);
            string file2 = "/ImagensProduto/" + Path.GetFileName(file.FileName);
            string _path = Path.Combine(Server.MapPath("~/ImagensProduto"), arquivo);
            file.SaveAs(_path);
            model.img_produto = file2;

            carregaCategoria();
            carregaFornecedor();
            carregaStatus();

            model.cd_fornecedor = Request["fornecedor"];
            model.cd_categoria = Request["categoria"];
            model.cd_status = Request["status"];

            Produto sdb = new Produto();
            sdb.atualizarProduto(model);
            return RedirectToAction("listarProduto");
        }

        // Área dos produtos (Áudio e Tecnologia)
        public ActionResult ProdutoAudioTecnologia(int? pagina, string btnFiltro)
        {
            int tamanhoPagina = 9;
            int numeroPagina = pagina ?? 1;

            switch (btnFiltro)
            {
                case "maiorPreco":
                    return View(acProduto.listarProdutoTecnologiaMaiorPreco().ToPagedList(numeroPagina, tamanhoPagina));
                case "menorPreco":
                    return View(acProduto.listarProdutoTecnologiaMenorPreco().ToPagedList(numeroPagina, tamanhoPagina));
                case "lancamento":
                    return View(acProduto.listarProdutoTecnologiaLancamento().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro1":
                    return View(acProduto.listarProdutoTecnologiaFiltro1().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro2":
                    return View(acProduto.listarProdutoTecnologiaFiltro2().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro3":
                    return View(acProduto.listarProdutoTecnologiaFiltro3().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro4":
                    return View(acProduto.listarProdutoTecnologiaFiltro4().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro5":
                    return View(acProduto.listarProdutoTecnologiaFiltro5().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro6":
                    return View(acProduto.listarProdutoTecnologiaFiltro6().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro7":
                    return View(acProduto.listarProdutoTecnologiaFiltro7().ToPagedList(numeroPagina, tamanhoPagina));
                default:
                    return View(acProduto.listarProdutoTecnologia().ToPagedList(numeroPagina, tamanhoPagina));
            }            
        }

        // Área dos produtos (Instrumentos de Corda)
        public ActionResult ProdutoInstrumentoCorda(int? pagina, string btnFiltro)
        {
            int tamanhoPagina = 9;
            int numeroPagina = pagina ?? 1;

            switch (btnFiltro)
            {
                case "maiorPreco":
                    return View(acProduto.listarProdutoCordaMaiorPreco().ToPagedList(numeroPagina, tamanhoPagina));
                case "menorPreco":
                    return View(acProduto.listarProdutoCordaMenorPreco().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro1":
                    return View(acProduto.listarProdutoCordaFiltro1().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro2":
                    return View(acProduto.listarProdutoCordaFiltro2().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro3":
                    return View(acProduto.listarProdutoCordaFiltro3().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro4":
                    return View(acProduto.listarProdutoCordaFiltro4().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro5":
                    return View(acProduto.listarProdutoCordaFiltro5().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro6":
                    return View(acProduto.listarProdutoCordaFiltro6().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro7":
                    return View(acProduto.listarProdutoCordaFiltro7().ToPagedList(numeroPagina, tamanhoPagina));
                default:
                    return View(acProduto.listarProdutoCorda().ToPagedList(numeroPagina, tamanhoPagina));
            }
        }

        // Área dos produtos (Bateria e Percussão)
        public ActionResult ProdutoBateriaPercussao(int? pagina, string btnFiltro)
        {
            int tamanhoPagina = 9;
            int numeroPagina = pagina ?? 1;

            switch (btnFiltro)
            {
                case "maiorPreco":
                    return View(acProduto.listarProdutoBateriaMaiorPreco().ToPagedList(numeroPagina, tamanhoPagina));
                case "menorPreco":
                    return View(acProduto.listarProdutoBateriaMenorPreco().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro1":
                    return View(acProduto.listarProdutoBateriaFiltro1().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro2":
                    return View(acProduto.listarProdutoBateriaFiltro2().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro3":
                    return View(acProduto.listarProdutoBateriaFiltro3().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro4":
                    return View(acProduto.listarProdutoBateriaFiltro4().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro5":
                    return View(acProduto.listarProdutoBateriaFiltro5().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro6":
                    return View(acProduto.listarProdutoBateriaFiltro6().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro7":
                    return View(acProduto.listarProdutoBateriaFiltro7().ToPagedList(numeroPagina, tamanhoPagina));
                default:
                    return View(acProduto.listarProdutoPercussao().ToPagedList(numeroPagina, tamanhoPagina));
            }
        }

        // Área dos produtos (Instrumentos de Teclas)
        public ActionResult ProdutoInstrumentoTeclas(int? pagina, string btnFiltro)
        {
            int tamanhoPagina = 9;
            int numeroPagina = pagina ?? 1;

            switch (btnFiltro)
            {
                case "maiorPreco":
                    return View(acProduto.listarProdutoTeclasMaiorPreco().ToPagedList(numeroPagina, tamanhoPagina));
                case "menorPreco":
                    return View(acProduto.listarProdutoTeclasMenorPreco().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro1":
                    return View(acProduto.listarProdutoTeclasFiltro1().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro2":
                    return View(acProduto.listarProdutoTeclasFiltro2().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro3":
                    return View(acProduto.listarProdutoTeclasFiltro3().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro4":
                    return View(acProduto.listarProdutoTeclasFiltro4().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro5":
                    return View(acProduto.listarProdutoTeclasFiltro5().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro6":
                    return View(acProduto.listarProdutoTeclasFiltro6().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro7":
                    return View(acProduto.listarProdutoTeclasFiltro7().ToPagedList(numeroPagina, tamanhoPagina));
                default:
                    return View(acProduto.listarProdutoTeclas().ToPagedList(numeroPagina, tamanhoPagina));
            }
        }

        // Área dos produtos (Arco e Sopro)
        public ActionResult ProdutoArcoSopro(int? pagina, string btnFiltro)
        {
            int tamanhoPagina = 9;
            int numeroPagina = pagina ?? 1;

            switch (btnFiltro)
            {
                case "maiorPreco":
                    return View(acProduto.listarProdutoArcoMaiorPreco().ToPagedList(numeroPagina, tamanhoPagina));
                case "menorPreco":
                    return View(acProduto.listarProdutoArcoMenorPreco().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro1":
                    return View(acProduto.listarProdutoArcoFiltro1().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro2":
                    return View(acProduto.listarProdutoArcoFiltro2().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro3":
                    return View(acProduto.listarProdutoArcoFiltro3().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro4":
                    return View(acProduto.listarProdutoArcoFiltro4().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro5":
                    return View(acProduto.listarProdutoArcoFiltro5().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro6":
                    return View(acProduto.listarProdutoArcoFiltro6().ToPagedList(numeroPagina, tamanhoPagina));
                case "filtro7":
                    return View(acProduto.listarProdutoArcoFiltro7().ToPagedList(numeroPagina, tamanhoPagina));
                default:
                    return View(acProduto.listarProduoArco().ToPagedList(numeroPagina, tamanhoPagina));
            }
        }
    }
}