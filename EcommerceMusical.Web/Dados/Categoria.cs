using EcommerceMusical.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EcommerceMusical.Web.Dados
{
    public class Categoria
    {
        // instanciando a classe de conexao
        Conexao con = new Conexao();

        public void inserirCategoria(modelCategoria model)
        {
            MySqlCommand cmd = new MySqlCommand("call cadastrarCategoria(@nmCategoria)", con.MyConectarBD());

            cmd.Parameters.Add("@nmCategoria", MySqlDbType.VarChar).Value = model.nm_categoria;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<modelCategoria> listarCategoria()
        {
            List<modelCategoria> CategoriaList = new List<modelCategoria>();

            MySqlCommand cmd = new MySqlCommand("call listarCategoria()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                CategoriaList.Add(
                    new modelCategoria
                    {
                        cd_categoria = Convert.ToString(dr["cd_categoria"]),
                        nm_categoria = Convert.ToString(dr["nm_categoria"])
                    });
            }
            return CategoriaList;
        }

        public bool excluirCategoria(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("call excluirCategoria(@cdCategoria)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdCategoria", cd);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool atualizarCategoria(modelCategoria model)
        {
            MySqlCommand cmd = new MySqlCommand("call atualizarCategoria(@cdCategoria, @nmCategoria)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdCategoria", model.cd_categoria);
            cmd.Parameters.AddWithValue("@nmCategoria", model.nm_categoria);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}