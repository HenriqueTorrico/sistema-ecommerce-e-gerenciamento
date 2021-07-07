using EcommerceMusical.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EcommerceMusical.Web.Dados
{
    public class Venda
    {
        // instanciando a classe de conexao
        Conexao con = new Conexao();

        // método de inserir uma venda
        public void inserirVenda(modelVenda model)
        {
            MySqlCommand cmd = new MySqlCommand("call cadastrarVenda(@cdUsuario, @dtVenda, @hrVenda, @vlVenda)", con.MyConectarBD());
            cmd.Parameters.Add("@cdUsuario", MySqlDbType.VarChar).Value = model.cd_usuario;
            cmd.Parameters.Add("@dtVenda", MySqlDbType.VarChar).Value = model.dt_venda;
            cmd.Parameters.Add("@hrVenda", MySqlDbType.VarChar).Value = model.hr_venda;
            cmd.Parameters.Add("@vlVenda", MySqlDbType.VarChar).Value = model.vl_venda;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        MySqlDataReader dr;
        public void buscaIdVenda(modelVenda model)
        {
            MySqlCommand cmd = new MySqlCommand("select cd_venda from tbl_venda order by cd_venda desc limit 1;", con.MyConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                model.cd_venda = dr[0].ToString();
            }
            con.MyDesconectarBD();
        }

        // método de listagem de vendas
        public List<modelVenda> listarVenda()
        {
            List<modelVenda> VendaList = new List<modelVenda>();

            MySqlCommand cmd = new MySqlCommand("call listarVenda()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                VendaList.Add(
                    new modelVenda
                    {
                        cd_venda = Convert.ToString(dr["cd_venda"]),
                        nm_usuario = Convert.ToString(dr["nm_usuario"]),
                        cpf_usuario = Convert.ToString(dr["cpf_usuario"]),
                        dt_venda = Convert.ToString(dr["dt_venda"]),
                        hr_venda = Convert.ToString(dr["hr_venda"]),
                        vl_venda = Convert.ToDouble(dr["vl_venda"])
                    });
            }
            return VendaList;
        }
    }
}