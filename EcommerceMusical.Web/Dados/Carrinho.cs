using EcommerceMusical.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EcommerceMusical.Web.Dados
{
    public class Carrinho
    {
        // instanciando a classe de conexao
        Conexao con = new Conexao();

        public void inserirItem(modelCarrinho model)
        {
            MySqlCommand cmd = new MySqlCommand("call inserirItem(@cdVenda, @cdProduto, @qtProduto)", con.MyConectarBD());

            cmd.Parameters.Add("@cdVenda", MySqlDbType.VarChar).Value = model.cd_venda;
            cmd.Parameters.Add("@cdProduto", MySqlDbType.VarChar).Value = model.cd_produto;
            cmd.Parameters.Add("@qtProduto", MySqlDbType.VarChar).Value = model.qt_produto;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<modelUsuario> buscaItens(int id)
        {
            List<modelUsuario> ProdutoCarrinholist = new List<modelUsuario>();

            MySqlCommand cmd = new MySqlCommand("select img_produto, nm_produto, vl_produto, qt_produto from viewcarrinho where cd_venda = @cdVenda", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@cdVenda", id);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoCarrinholist.Add(
                    new modelUsuario
                    {
                        img_produto = Convert.ToString(dr["img_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        vl_produto = Convert.ToString(dr["vl_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"])
                    });
            }
            return ProdutoCarrinholist;
        }
    }
}