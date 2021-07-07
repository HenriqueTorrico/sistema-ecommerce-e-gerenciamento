using EcommerceMusical.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace EcommerceMusical.Web.Dados
{
    public class Estatistica
    {
        Conexao con = new Conexao();

        public List<modelEstatistica> listarVendasTotais()
        {
            List<modelEstatistica> VendaTotalList = new List<modelEstatistica>();

            MySqlCommand cmd = new MySqlCommand("call listarVendasTotais()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                VendaTotalList.Add(
                    new modelEstatistica
                    {
                        cd_venda = Convert.ToString(dr["count(cd_venda)"])
                    });
            }
            return VendaTotalList;
        }

        public List<modelEstatistica> listarUsuariosTotais()
        {
            List<modelEstatistica> UsuarioTotalList = new List<modelEstatistica>();

            MySqlCommand cmd = new MySqlCommand("call listarUsuarioTotais()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                UsuarioTotalList.Add(
                    new modelEstatistica
                    {
                        cd_usuario = Convert.ToString(dr["count(cd_usuario)"])
                    });
            }
            return UsuarioTotalList;
        }

        public List<modelEstatistica> listarFuncionariosTotais()
        {
            List<modelEstatistica> FuncionarioTotalList = new List<modelEstatistica>();

            MySqlCommand cmd = new MySqlCommand("call listarFuncionariosTotais()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                FuncionarioTotalList.Add(
                    new modelEstatistica
                    {
                        cd_funcionario = Convert.ToString(dr["count(cd_funcionario)"])
                    });
            }
            return FuncionarioTotalList;
        }

        public List<modelEstatistica> listarValorVendas()
        {
            List<modelEstatistica> VendaValorTotalList = new List<modelEstatistica>();

            MySqlCommand cmd = new MySqlCommand("call listarSomaVendas()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                VendaValorTotalList.Add(
                    new modelEstatistica
                    {
                        vl_venda = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["sum(vl_venda)"])
                    });
            }
            return VendaValorTotalList;
        }

        public List<modelEstatistica> listarEstoque()
        {
            List<modelEstatistica> EstoqueList = new List<modelEstatistica>();

            MySqlCommand cmd = new MySqlCommand("call listarEstoque()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                EstoqueList.Add(
                    new modelEstatistica
                    {
                        qt_produto = Convert.ToString(dr["sum(qt_produto)"])
                    });
            }
            return EstoqueList;
        }

        public List<modelEstatistica> listarProdutosEstoque()
        {
            List<modelEstatistica> ProdEstoqueList = new List<modelEstatistica>();

            MySqlCommand cmd = new MySqlCommand("select cd_produto, img_produto, nm_produto, qt_produto from tbl_produto;", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdEstoqueList.Add(
                    new modelEstatistica
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"])
                    });
            }
            return ProdEstoqueList;
        }
    }
}