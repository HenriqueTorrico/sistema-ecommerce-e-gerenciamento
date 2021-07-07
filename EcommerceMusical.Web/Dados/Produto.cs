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
    public class Produto
    {
        // instanciando a classe de conexao
        Conexao con = new Conexao();

        // método de inserir um produto
        public void inserirProduto(modelProduto model)
        {
            MySqlCommand cmd = new MySqlCommand("call cadastrarProduto(@nmProduto, @cdFornecedor, @cdCategoria, @marProduto, @qtProduto, @vlProduto, @imgProduto, @dsProduto, @carProduto, @cdStatus)", con.MyConectarBD());
            string vl_produto = model.vl_produto;
            vl_produto = vl_produto.Replace(".", "").Replace(",", ".");

            cmd.Parameters.Add("@nmProduto", MySqlDbType.VarChar).Value = model.nm_produto;
            cmd.Parameters.Add("@cdFornecedor", MySqlDbType.VarChar).Value = model.cd_fornecedor;
            cmd.Parameters.Add("@cdCategoria", MySqlDbType.VarChar).Value = model.cd_categoria;
            cmd.Parameters.Add("@marProduto", MySqlDbType.VarChar).Value = model.mar_produto;
            cmd.Parameters.Add("@qtProduto", MySqlDbType.VarChar).Value = model.qt_produto;
            cmd.Parameters.Add("@vlProduto", MySqlDbType.VarChar).Value = vl_produto;
            cmd.Parameters.Add("@imgProduto", MySqlDbType.VarChar).Value = model.img_produto;
            cmd.Parameters.Add("@dsProduto", MySqlDbType.VarChar).Value = model.ds_produto;
            cmd.Parameters.Add("@carProduto", MySqlDbType.VarChar).Value = model.car_produto;
            cmd.Parameters.Add("@cdStatus", MySqlDbType.VarChar).Value = model.cd_status;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        // método de buscar um produto
        public List<modelProduto> buscarProduto(modelProduto model)
        {
            List<modelProduto> ProdutoBuscaList = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("call buscarProduto(@nmProduto)", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@nmProduto", model.nm_produto);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoBuscaList.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        cd_fornecedor = Convert.ToString(dr["cd_fornecedor"]),
                        cd_categoria = Convert.ToString(dr["cd_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        cd_status = Convert.ToString(dr["cd_status"])
                    });
            }
            return ProdutoBuscaList;
        }

        // método de listagem de produtos
        public List<modelProduto> listarProduto()
        {
            List<modelProduto> ProdutoList = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("call listarProduto()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoList.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = Convert.ToString(dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoList;
        }

        // método de listagem de produtos (Áudio e Tecnologia)
        public List<modelProduto> listarProdutoTecnologia()
        {
            List<modelProduto> ProdutoListTec = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("call listarProdutoTecnologia()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTec.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTec;
        }

        // método de listagem de produtos (Instrumentos de Cordas)
        public List<modelProduto> listarProdutoCorda()
        {
            List<modelProduto> ProdutoListCorda = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("call listarProdutoCorda()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListCorda.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListCorda;
        }

        // método de listagem de produtos (Bateria e Percurssão)
        public List<modelProduto> listarProdutoPercussao()
        {
            List<modelProduto> ProdutoListPer = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("call listarProdutoPercussao()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListPer.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListPer;
        }

        // método de listagem de produtos (Instrumentos de Teclas)
        public List<modelProduto> listarProdutoTeclas()
        {
            List<modelProduto> ProdutoListTec = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("call listarProdutoTeclas()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTec.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTec;
        }

        // método de listagem de produtos (Arco e Sopro)
        public List<modelProduto> listarProduoArco()
        {
            List<modelProduto> ProdutoListArc = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("call listarProdutoSopro()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListArc.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListArc;
        }

        // método de listagem de produtos (Lançamentos)
        public List<modelProduto> listarProdutoLancamento()
        {
            List<modelProduto> ProdutoListLanc = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("call listarProdutoLancamento()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListLanc.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListLanc;
        }

        // método de listagem de produtos (Destaques)
        public List<modelProduto> listarProdutoDestaque()
        {
            List<modelProduto> ProdutoListDest = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("call listarProdutoDestaque()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListDest.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListDest;
        }

        // método de listagem de produtos (Ofertas)
        public List<modelProduto> listarProdutoOfertas()
        {
            List<modelProduto> ProdutoListOfer = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("call listarProdutoOfertas()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListOfer.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListOfer;
        }

        // método de listagem de produtos (Premium)
        public List<modelProduto> listarProdutoPremium()
        {
            List<modelProduto> ProdutoListPrem = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("call listarProdutoPremium()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListPrem.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListPrem;
        }

        // método de listagem de produtos (Instrumentos de Corda (R$ 0,00 - R$ 1.000,00))
        public List<modelProduto> listarProdutoCordaFiltro1()
        {
            List<modelProduto> ProdutoListCordaFiltro1 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro1Corda", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListCordaFiltro1.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListCordaFiltro1;
        }

        // método de listagem de produtos (Instrumentos de Corda (R$ 1.000,00 - R$ 5.000,00))
        public List<modelProduto> listarProdutoCordaFiltro2()
        {
            List<modelProduto> ProdutoListCordaFiltro2 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro2Corda", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListCordaFiltro2.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListCordaFiltro2;
        }

        // método de listagem de produtos (Instrumentos de Corda (R$ 5.000,00 - R$ 10.000,00))
        public List<modelProduto> listarProdutoCordaFiltro3()
        {
            List<modelProduto> ProdutoListCordaFiltro3 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro3Corda", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListCordaFiltro3.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListCordaFiltro3;
        }

        // método de listagem de produtos (Instrumentos de Corda (R$ 10.000,00 - R$ 15.000,00))
        public List<modelProduto> listarProdutoCordaFiltro4()
        {
            List<modelProduto> ProdutoListCordaFiltro4 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro4Corda", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListCordaFiltro4.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListCordaFiltro4;
        }

        // método de listagem de produtos (Instrumentos de Corda (R$ 15.000,00 - R$ 20.000,00))
        public List<modelProduto> listarProdutoCordaFiltro5()
        {
            List<modelProduto> ProdutoListCordaFiltro5 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro5Corda", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListCordaFiltro5.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListCordaFiltro5;
        }

        // método de listagem de produtos (Instrumentos de Corda (R$ 20.000,00 - R$ 30.000,00))
        public List<modelProduto> listarProdutoCordaFiltro6()
        {
            List<modelProduto> ProdutoListCordaFiltro6 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro6Corda", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListCordaFiltro6.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListCordaFiltro6;
        }

        // método de listagem de produtos (Instrumentos de Corda (Acima de R$ 30.000,00))
        public List<modelProduto> listarProdutoCordaFiltro7()
        {
            List<modelProduto> ProdutoListCordaFiltro7 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro7Corda", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListCordaFiltro7.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListCordaFiltro7;
        }

        // método de listagem de produtos (Instrumentos de Corda (maior preço))
        public List<modelProduto> listarProdutoCordaMaiorPreco()
        {
            List<modelProduto> ProdutoListCordaMaior = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosMaiorPrecoCorda", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListCordaMaior.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListCordaMaior;
        }

        // método de listagem de produtos (Instrumentos de Corda (menor preço))
        public List<modelProduto> listarProdutoCordaMenorPreco()
        {
            List<modelProduto> ProdutoListCordaMenor = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosMenorPrecoCorda", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListCordaMenor.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListCordaMenor;
        }

        // método de listagem de produtos (Instrumentos de Audio e Tecnologia (R$ 0,00 - R$ 1.000,00))
        public List<modelProduto> listarProdutoTecnologiaFiltro1()
        {
            List<modelProduto> ProdutoListTecFiltro1 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro1Tecnologia", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTecFiltro1.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTecFiltro1;
        }

        // método de listagem de produtos (Instrumentos de Audio e Tecnologia (R$ 1.000,00 - R$ 5.000,00))
        public List<modelProduto> listarProdutoTecnologiaFiltro2()
        {
            List<modelProduto> ProdutoListTecFiltro2 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro2Tecnologia", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTecFiltro2.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTecFiltro2;
        }

        // método de listagem de produtos (Instrumentos de Audio e Tecnologia (R$ 5.000,00 - R$ 10.000,00))
        public List<modelProduto> listarProdutoTecnologiaFiltro3()
        {
            List<modelProduto> ProdutoListTecFiltro3 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro3Tecnologia", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTecFiltro3.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTecFiltro3;
        }

        // método de listagem de produtos (Instrumentos de Audio e Tecnologia (R$ 10.000,00 - R$ 15.000,00))
        public List<modelProduto> listarProdutoTecnologiaFiltro4()
        {
            List<modelProduto> ProdutoListTecFiltro4 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro4Tecnologia", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTecFiltro4.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTecFiltro4;
        }

        // método de listagem de produtos (Instrumentos de Audio e Tecnologia (R$ 15.000,00 - R$ 20.000,00))
        public List<modelProduto> listarProdutoTecnologiaFiltro5()
        {
            List<modelProduto> ProdutoListTecFiltro5 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro5Tecnologia", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTecFiltro5.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTecFiltro5;
        }

        // método de listagem de produtos (Instrumentos de Audio e Tecnologia (R$ 20.000,00 - R$ 30.000,00))
        public List<modelProduto> listarProdutoTecnologiaFiltro6()
        {
            List<modelProduto> ProdutoListTecFiltro6 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro6Tecnologia", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTecFiltro6.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTecFiltro6;
        }

        // método de listagem de produtos (Instrumentos de Audio e Tecnologia (Acima de R$ 30.000,00))
        public List<modelProduto> listarProdutoTecnologiaFiltro7()
        {
            List<modelProduto> ProdutoListTecFiltro7 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro7Tecnologia", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTecFiltro7.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTecFiltro7;
        }

        public List<modelProduto> listarProdutoTecnologiaLancamento()
        {
            List<modelProduto> ProdutoListTecLancamento = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosLançamentoTecnologia", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTecLancamento.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTecLancamento;
        }

        // método de listagem de produtos (Áudio e Tecnologia (maior preço))
        public List<modelProduto> listarProdutoTecnologiaMaiorPreco()
        {
            List<modelProduto> ProdutoListTecMaior = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosMaiorPrecoTecnologia", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTecMaior.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTecMaior;
        }

        // método de listagem de produtos (Áudio e Tecnologia (menor preço))
        public List<modelProduto> listarProdutoTecnologiaMenorPreco()
        {
            List<modelProduto> ProdutoListTecMenor = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosMenorPrecoTecnologia", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTecMenor.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTecMenor;
        }

        // método de listagem de produtos (Instrumentos de Bateria e Percussão (R$ 0,00 - R$ 1.000,00))
        public List<modelProduto> listarProdutoBateriaFiltro1()
        {
            List<modelProduto> ProdutoListBateriaFiltro1 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro1Bateria", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListBateriaFiltro1.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListBateriaFiltro1;
        }

        // método de listagem de produtos (Instrumentos de Bateria e Percussão (R$ 1.000,00 - R$ 5.000,00))
        public List<modelProduto> listarProdutoBateriaFiltro2()
        {
            List<modelProduto> ProdutoListBateriaFiltro2 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro2Bateria", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListBateriaFiltro2.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListBateriaFiltro2;
        }

        // método de listagem de produtos (Instrumentos de Bateria e Percussão (R$ 5.000,00 - R$ 10.000,00))
        public List<modelProduto> listarProdutoBateriaFiltro3()
        {
            List<modelProduto> ProdutoListBateriaFiltro3 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro3Bateria", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListBateriaFiltro3.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListBateriaFiltro3;
        }

        // método de listagem de produtos (Instrumentos de Bateria e Percussão (R$ 10.000,00 - R$ 15.000,00))
        public List<modelProduto> listarProdutoBateriaFiltro4()
        {
            List<modelProduto> ProdutoListBateriaFiltro4 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro4Bateria", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListBateriaFiltro4.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListBateriaFiltro4;
        }

        // método de listagem de produtos (Instrumentos de Bateria e Percussão (R$ 15.000,00 - R$ 20.000,00))
        public List<modelProduto> listarProdutoBateriaFiltro5()
        {
            List<modelProduto> ProdutoListBateriaFiltro5 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro5Bateria", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListBateriaFiltro5.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListBateriaFiltro5;
        }

        // método de listagem de produtos (Instrumentos de Bateria e Percussão (R$ 20.000,00 - R$ 30.000,00))
        public List<modelProduto> listarProdutoBateriaFiltro6()
        {
            List<modelProduto> ProdutoListBateriaFiltro6 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro6Bateria", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListBateriaFiltro6.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListBateriaFiltro6;
        }

        // método de listagem de produtos (Instrumentos de Bateria e Percussão (Acima de R$ 30.000,00))
        public List<modelProduto> listarProdutoBateriaFiltro7()
        {
            List<modelProduto> ProdutoListBateriaFiltro7 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro7Bateria", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListBateriaFiltro7.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListBateriaFiltro7;
        }

        // método de listagem de produtos (Bateria e Percussão (maior preço))
        public List<modelProduto> listarProdutoBateriaMaiorPreco()
        {
            List<modelProduto> ProdutoListBateriaMaior = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosMaiorPrecoBateria", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListBateriaMaior.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListBateriaMaior;
        }

        // método de listagem de produtos (Bateria e Percussão (menor preço))
        public List<modelProduto> listarProdutoBateriaMenorPreco()
        {
            List<modelProduto> ProdutoListBateriaMenor = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosMenorPrecoBateria", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListBateriaMenor.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListBateriaMenor;
        }

        // método de listagem de produtos (Instrumentos de Teclas (R$ 0,00 - R$ 1.000,00))
        public List<modelProduto> listarProdutoTeclasFiltro1()
        {
            List<modelProduto> ProdutoListTeclasFiltro1 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro1Teclas", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTeclasFiltro1.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTeclasFiltro1;
        }

        // método de listagem de produtos (Instrumentos de Teclas (R$ 1.000,00 - R$ 5.000,00))
        public List<modelProduto> listarProdutoTeclasFiltro2()
        {
            List<modelProduto> ProdutoListTeclasFiltro2 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro2Teclas", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTeclasFiltro2.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTeclasFiltro2;
        }

        // método de listagem de produtos (Instrumentos de Teclas (R$ 5.000,00 - R$ 10.000,00))
        public List<modelProduto> listarProdutoTeclasFiltro3()
        {
            List<modelProduto> ProdutoListTeclasFiltro3 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro3Teclas", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTeclasFiltro3.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTeclasFiltro3;
        }

        // método de listagem de produtos (Instrumentos de Teclas (R$ 10.000,00 - R$ 15.000,00))
        public List<modelProduto> listarProdutoTeclasFiltro4()
        {
            List<modelProduto> ProdutoListTeclasFiltro4 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro4Teclas", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTeclasFiltro4.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTeclasFiltro4;
        }

        // método de listagem de produtos (Instrumentos de Teclas (R$ 15.000,00 - R$ 20.000,00))
        public List<modelProduto> listarProdutoTeclasFiltro5()
        {
            List<modelProduto> ProdutoListTeclasFiltro5 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro5Teclas", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTeclasFiltro5.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTeclasFiltro5;
        }

        // método de listagem de produtos (Instrumentos de Teclas (R$ 20.000,00 - R$ 30.000,00))
        public List<modelProduto> listarProdutoTeclasFiltro6()
        {
            List<modelProduto> ProdutoListTeclasFiltro6 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro6Teclas", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTeclasFiltro6.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTeclasFiltro6;
        }

        // método de listagem de produtos (Instrumentos de Teclas (Acima de R$ 30.000,00))
        public List<modelProduto> listarProdutoTeclasFiltro7()
        {
            List<modelProduto> ProdutoListTeclasFiltro7 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro7Teclas", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTeclasFiltro7.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = string.Format(CultureInfo.GetCultureInfo("pt-br"), "{0:C}", dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTeclasFiltro7;
        }





        // método de listagem de produtos (Instrumentos de Teclas (maior preço))
        public List<modelProduto> listarProdutoTeclasMaiorPreco()
        {
            List<modelProduto> ProdutoListTeclasMaior = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosMaiorPrecoTeclas", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTeclasMaior.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = Convert.ToString(dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTeclasMaior;
        }

        // método de listagem de produtos (Instrumentos de Teclas (menor preço))
        public List<modelProduto> listarProdutoTeclasMenorPreco()
        {
            List<modelProduto> ProdutoListTeclasMenor = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosMenorPrecoTeclas", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListTeclasMenor.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = Convert.ToString(dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListTeclasMenor;
        }

        // método de listagem de produtos (Instrumentos de Arco e Sopro (R$ 0,00 - R$ 1.000,00))
        public List<modelProduto> listarProdutoArcoFiltro1()
        {
            List<modelProduto> ProdutoListArcoFiltro1 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro1Arco", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListArcoFiltro1.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = Convert.ToString(dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListArcoFiltro1;
        }

        // método de listagem de produtos (Instrumentos de Arco e Sopro (R$ 1.000,00 - R$ 5.000,00))
        public List<modelProduto> listarProdutoArcoFiltro2()
        {
            List<modelProduto> ProdutoListArcoFiltro2 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro2Arco", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListArcoFiltro2.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = Convert.ToString(dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListArcoFiltro2;
        }

        // método de listagem de produtos (Instrumentos de Arco e Sopro (R$ 5.000,00 - R$ 10.000,00))
        public List<modelProduto> listarProdutoArcoFiltro3()
        {
            List<modelProduto> ProdutoListArcoFiltro3 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro3Arco", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListArcoFiltro3.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = Convert.ToString(dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListArcoFiltro3;
        }

        // método de listagem de produtos (Instrumentos de Arco e Sopro (R$ 10.000,00 - R$ 15.000,00))
        public List<modelProduto> listarProdutoArcoFiltro4()
        {
            List<modelProduto> ProdutoListArcoFiltro4 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro4Arco", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListArcoFiltro4.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = Convert.ToString(dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListArcoFiltro4;
        }

        // método de listagem de produtos (Instrumentos de Arco e Sopro (R$ 15.000,00 - R$ 20.000,00))
        public List<modelProduto> listarProdutoArcoFiltro5()
        {
            List<modelProduto> ProdutoListArcoFiltro5 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro5Arco", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListArcoFiltro5.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = Convert.ToString(dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListArcoFiltro5;
        }

        // método de listagem de produtos (Instrumentos de Arco e Sopro (R$ 20.000,00 - R$ 30.000,00))
        public List<modelProduto> listarProdutoArcoFiltro6()
        {
            List<modelProduto> ProdutoListArcoFiltro6 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro6Arco", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListArcoFiltro6.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = Convert.ToString(dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListArcoFiltro6;
        }

        // método de listagem de produtos (Instrumentos de Arco e Sopro (Acima de R$ 30.000,00))
        public List<modelProduto> listarProdutoArcoFiltro7()
        {
            List<modelProduto> ProdutoListArcoFiltro7 = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosFiltro7Arco", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListArcoFiltro7.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = Convert.ToString(dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListArcoFiltro7;
        }

        // método de listagem de produtos (Instrumentos de Arco e Sopro (maior preço))
        public List<modelProduto> listarProdutoArcoMaiorPreco()
        {
            List<modelProduto> ProdutoListArcoMaior = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosMaiorPrecoArco", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListArcoMaior.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = Convert.ToString(dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListArcoMaior;
        }

        // método de listagem de produtos (Instrumentos de Arco e Sopro (menor preço))
        public List<modelProduto> listarProdutoArcoMenorPreco()
        {
            List<modelProduto> ProdutoListArcoMenor = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from viewProdutosMenorPrecoArco", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ProdutoListArcoMenor.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = Convert.ToString(dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        nm_status = Convert.ToString(dr["nm_status"])
                    });
            }
            return ProdutoListArcoMenor;
        }

        // método de consulta do produto
        public List<modelProduto> consultaProduto(int id)
        {
            List<modelProduto> Produtoslist = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("select * from tbl_produto where cd_produto = @cdProduto", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@cdProduto", id);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                Produtoslist.Add(
                    new modelProduto
                    {
                        cd_produto = Convert.ToString(dr["cd_produto"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        cd_fornecedor = Convert.ToString(dr["cd_fornecedor"]),
                        cd_categoria = Convert.ToString(dr["cd_categoria"]),
                        mar_produto = Convert.ToString(dr["mar_produto"]),
                        qt_produto = Convert.ToString(dr["qt_produto"]),
                        vl_produto = Convert.ToString(dr["vl_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        ds_produto = Convert.ToString(dr["ds_produto"]),
                        car_produto = Convert.ToString(dr["car_produto"]),
                        cd_status = Convert.ToString(dr["cd_status"])
                    });
            }
            return Produtoslist;
        }

        // método de excluir um produto
        public bool excluirProduto(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("call excluirProduto(@cdProduto)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdProduto", cd);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // método de atualizar um produto
        public bool atualizarProduto(modelProduto model)
        {
            MySqlCommand cmd = new MySqlCommand("call atualizarProduto(@cdProduto, @nmProduto, @cdFornecedor, @cdCategoria, @marProduto, @qtProduto, @vlProduto, @imgProduto, @dsProduto, @carProduto, @cdStatus)", con.MyConectarBD());
            string vl_produto = model.vl_produto;
            vl_produto = vl_produto.Replace(".", "").Replace(",", ".");
            cmd.Parameters.AddWithValue("@cdProduto", model.cd_produto);
            cmd.Parameters.AddWithValue("@nmProduto", model.nm_produto);
            cmd.Parameters.AddWithValue("@cdFornecedor", model.cd_fornecedor);
            cmd.Parameters.AddWithValue("@cdCategoria", model.cd_categoria);
            cmd.Parameters.AddWithValue("@marProduto", model.mar_produto);
            cmd.Parameters.AddWithValue("@qtProduto", model.qt_produto);
            cmd.Parameters.AddWithValue("@vlProduto", vl_produto);
            cmd.Parameters.AddWithValue("@imgProduto", model.img_produto);
            cmd.Parameters.AddWithValue("@dsProduto", model.ds_produto);
            cmd.Parameters.AddWithValue("@carProduto", model.car_produto);
            cmd.Parameters.AddWithValue("@cdStatus", model.cd_status);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}