using EcommerceMusical.Web.Dados;
using EcommerceMusical.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceMusical.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        // Instanciando a classe Carrinho
        Carrinho acCarrinho = new Carrinho();
        Produto acProduto = new Produto();
        Venda acVenda = new Venda();

        public static string codigo;

        public ActionResult AdicionarCarrinho(int id, double pre)
        {
            modelVenda carrinho = Session["Carrinho"] != null ? (modelVenda)Session["Carrinho"] : new modelVenda();
            var produto = acProduto.consultaProduto(id);
            codigo = id.ToString();

            modelProduto prod = new modelProduto();

            if (produto != null)
            {
                var itemPedido = new modelCarrinho();
                itemPedido.cd_carrinho = Guid.NewGuid();
                itemPedido.cd_produto = id.ToString();
                itemPedido.nm_produto = produto[0].nm_produto;
                itemPedido.qt_produto = 1;
                itemPedido.vl_unitario = pre;
                itemPedido.img_produto = produto[0].img_produto;

                List<modelCarrinho> x = carrinho.ItensPedido.FindAll(m => m.nm_produto == itemPedido.nm_produto);

                if (x.Count != 0)
                {
                    carrinho.ItensPedido.FirstOrDefault(m => m.nm_produto == produto[0].nm_produto).qt_produto += 1;
                    itemPedido.vl_parcial = itemPedido.qt_produto * itemPedido.vl_unitario;
                    carrinho.vl_venda += itemPedido.vl_parcial;
                    carrinho.ItensPedido.FirstOrDefault(m => m.nm_produto == produto[0].nm_produto).vl_parcial = carrinho.ItensPedido.FirstOrDefault(m => m.nm_produto == produto[0].nm_produto).qt_produto * itemPedido.vl_unitario;
                }

                else
                {
                    itemPedido.vl_parcial = itemPedido.qt_produto * itemPedido.vl_unitario;
                    carrinho.vl_venda += itemPedido.vl_parcial;
                    carrinho.ItensPedido.Add(itemPedido);
                }

                Session["Carrinho"] = carrinho;
            }

            return RedirectToAction("Carrinho");
        }

        public ActionResult Carrinho()
        {
            modelVenda carrinho = Session["Carrinho"] != null ? (modelVenda)Session["Carrinho"] : new modelVenda();
            return View(carrinho);
        }

        public ActionResult ExcluirItem(Guid id)
        {
            var carrinho = Session["Carrinho"] != null ? (modelVenda)Session["Carrinho"] : new modelVenda();
            var itemExclusao = carrinho.ItensPedido.FirstOrDefault(m => m.cd_carrinho == id);

            carrinho.vl_venda -= itemExclusao.vl_parcial;
            carrinho.ItensPedido.Remove(itemExclusao);

            Session["Carrinho"] = carrinho;
            return RedirectToAction("Carrinho");
        }

        public ActionResult SalvarCarrinho(modelVenda x)
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var carrinho = Session["Carrinho"] != null ? (modelVenda)Session["Carrinho"] : new modelVenda();

                modelVenda md = new modelVenda();
                modelCarrinho mdV = new modelCarrinho();

                md.dt_venda = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy");
                md.hr_venda = DateTime.Now.ToLocalTime().ToString("HH:mm");
                md.cd_usuario = Session["codigo"].ToString();
                md.vl_venda = carrinho.vl_venda;

                acVenda.inserirVenda(md);
                acVenda.buscaIdVenda(x);

                for (int i = 0; i < carrinho.ItensPedido.Count; i++)
                {
                    mdV.cd_venda = x.cd_venda;
                    mdV.cd_produto = carrinho.ItensPedido[i].cd_produto;
                    mdV.qt_produto = carrinho.ItensPedido[i].qt_produto;
                    mdV.vl_parcial = carrinho.ItensPedido[i].vl_parcial;
                    acCarrinho.inserirItem(mdV);
                }

                carrinho.vl_venda = 0;
                carrinho.ItensPedido.Clear();
                return RedirectToAction("confVenda");
            }
        }

        public ActionResult confVenda()
        {
            return View();
        }
    }
}