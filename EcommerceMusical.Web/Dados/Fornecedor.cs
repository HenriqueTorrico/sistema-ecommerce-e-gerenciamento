using EcommerceMusical.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EcommerceMusical.Web.Dados
{
    public class Fornecedor
    {
        // instanciando a classe de conexao
        Conexao con = new Conexao();

        public void inserirFornecedor(modelFornecedor model)
        {
            MySqlCommand cmd = new MySqlCommand("call cadastrarFornecedor(@nmFornecedor, @telFornecedor, @cnpjFornecedor, @cepFornecedor, @logFornecedor, @barFornecedor, @cidFornecedor, @ufFornecedor)", con.MyConectarBD());

            cmd.Parameters.Add("@nmFornecedor", MySqlDbType.VarChar).Value = model.nm_fornecedor;
            cmd.Parameters.Add("@telFornecedor", MySqlDbType.VarChar).Value = model.tel_fornecedor;
            cmd.Parameters.Add("@cnpjFornecedor", MySqlDbType.VarChar).Value = model.cnpj_fornecedor;
            cmd.Parameters.Add("@cepFornecedor", MySqlDbType.VarChar).Value = model.cep_fornecedor;
            cmd.Parameters.Add("@logFornecedor", MySqlDbType.VarChar).Value = model.log_fornecedor;
            cmd.Parameters.Add("@barFornecedor", MySqlDbType.VarChar).Value = model.bar_fornecedor;
            cmd.Parameters.Add("@cidFornecedor", MySqlDbType.VarChar).Value = model.cid_fornecedor;
            cmd.Parameters.Add("@ufFornecedor", MySqlDbType.VarChar).Value = model.uf_fornecedor;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<modelFornecedor> listarFornecedor()
        {
            List<modelFornecedor> FornecedorList = new List<modelFornecedor>();

            MySqlCommand cmd = new MySqlCommand("call listarFornecedor()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                FornecedorList.Add(
                    new modelFornecedor
                    {
                        cd_fornecedor = Convert.ToString(dr["cd_fornecedor"]),
                        nm_fornecedor = Convert.ToString(dr["nm_fornecedor"]),
                        tel_fornecedor = Convert.ToString(dr["tel_fornecedor"]),
                        cnpj_fornecedor = Convert.ToString(dr["cnpj_fornecedor"]),
                        cep_fornecedor = Convert.ToString(dr["cep_fornecedor"]),
                        log_fornecedor = Convert.ToString(dr["log_fornecedor"]),
                        bar_fornecedor = Convert.ToString(dr["bar_fornecedor"]),
                        cid_fornecedor = Convert.ToString(dr["cid_fornecedor"]),
                        uf_fornecedor = Convert.ToString(dr["uf_fornecedor"])
                    });
            }
            return FornecedorList;
        }

        public bool excluirFornecedor(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("call excluirFornecedor(@cdFornecedor)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdFornecedor", cd);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool atualizarFornecedor(modelFornecedor model)
        {
            MySqlCommand cmd = new MySqlCommand("call atualizarFornecedor(@cdFornecedor, @nmFornecedor, @telFornecedor, @cnpjFornecedor, @cepFornecedor, @logFornecedor, @barFornecedor, @cidFornecedor, @ufFornecedor)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdFornecedor", model.cd_fornecedor);
            cmd.Parameters.AddWithValue("@nmFornecedor", model.nm_fornecedor);
            cmd.Parameters.AddWithValue("@telFornecedor", model.tel_fornecedor);
            cmd.Parameters.AddWithValue("@cnpjFornecedor", model.cnpj_fornecedor);
            cmd.Parameters.AddWithValue("@cepFornecedor", model.cep_fornecedor);
            cmd.Parameters.AddWithValue("@logFornecedor", model.log_fornecedor);
            cmd.Parameters.AddWithValue("@barFornecedor", model.bar_fornecedor);
            cmd.Parameters.AddWithValue("@cidFornecedor", model.cid_fornecedor);
            cmd.Parameters.AddWithValue("@ufFornecedor", model.uf_fornecedor);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}