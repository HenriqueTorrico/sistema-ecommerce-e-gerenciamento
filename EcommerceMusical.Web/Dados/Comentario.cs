using EcommerceMusical.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EcommerceMusical.Web.Dados
{
    public class Comentario
    {
        Conexao con = new Conexao();

        public void inserirComentario(modelProduto model)
        {
            MySqlCommand cmd = new MySqlCommand("call cadastrarComentario(@dsComentario, @cdUsuario, @dtComentario)", con.MyConectarBD());

            cmd.Parameters.Add("@dsComentario", MySqlDbType.VarChar).Value = model.ds_comentario;
            cmd.Parameters.Add("@cdUsuario", MySqlDbType.VarChar).Value = model.cd_usuario;
            cmd.Parameters.Add("@dtComentario", MySqlDbType.VarChar).Value = model.dt_comentario;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<modelProduto> listarComentario()
        {
            List<modelProduto> ComentarioList = new List<modelProduto>();

            MySqlCommand cmd = new MySqlCommand("call listarComentario()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ComentarioList.Add(
                    new modelProduto
                    {
                        cd_comentario = Convert.ToString(dr["cd_comentario"]),
                        ds_comentario = Convert.ToString(dr["ds_comentario"]),
                        dt_comentario = Convert.ToString(dr["dt_comentario"]),
                        nm_usuario = Convert.ToString(dr["nm_usuario"]),
                        img_usuario = Convert.ToString(dr["img_usuario"])
                    });
            }
            return ComentarioList;
        }

        public bool excluirComentario(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("call excluirComentario(@cdComentario)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdComentario", cd);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}