using EcommerceMusical.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EcommerceMusical.Web.Dados
{
    public class Usuario
    {
        // instanciando a classe de conexao
        Conexao con = new Conexao();

        public void inserirUsuario(modelUsuario model)
        {
            MySqlCommand cmd = new MySqlCommand("call cadastrarUsuario(@nmUsuario, @cpfUsuario, @cdGenero, @celUsuario, @emlUsuario, @imgUsuario, @cepUsuario, @logUsuario, @barUsuario, @cidUsuario, @ufUsuario, @shUsuario)", con.MyConectarBD());

            cmd.Parameters.Add("@nmUsuario", MySqlDbType.VarChar).Value = model.nm_usuario;
            cmd.Parameters.Add("@cpfUsuario", MySqlDbType.VarChar).Value = model.cpf_usuario;
            cmd.Parameters.Add("@cdGenero", MySqlDbType.VarChar).Value = model.cd_genero;
            cmd.Parameters.Add("@celUsuario", MySqlDbType.VarChar).Value = model.cel_usuario;
            cmd.Parameters.Add("@emlUsuario", MySqlDbType.VarChar).Value = model.eml_usuario;
            cmd.Parameters.Add("@imgUsuario", MySqlDbType.VarChar).Value = model.img_usuario;
            cmd.Parameters.Add("@cepUsuario", MySqlDbType.VarChar).Value = model.cep_usuario;
            cmd.Parameters.Add("@logUsuario", MySqlDbType.VarChar).Value = model.log_usuario;
            cmd.Parameters.Add("@barUsuario", MySqlDbType.VarChar).Value = model.bar_usuario;
            cmd.Parameters.Add("@cidUsuario", MySqlDbType.VarChar).Value = model.cid_usuario;
            cmd.Parameters.Add("@ufUsuario", MySqlDbType.VarChar).Value = model.uf_usuario;
            cmd.Parameters.Add("@shUsuario", MySqlDbType.VarChar).Value = model.sh_usuario;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<modelUsuario> listarUsuario()
        {
            List<modelUsuario> UsuarioList = new List<modelUsuario>();

            MySqlCommand cmd = new MySqlCommand("call listarUsuario()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                UsuarioList.Add(
                    new modelUsuario
                    {
                        cd_usuario = Convert.ToString(dr["cd_usuario"]),
                        nm_usuario = Convert.ToString(dr["nm_usuario"]),
                        cpf_usuario = Convert.ToString(dr["cpf_usuario"]),
                        nm_genero = Convert.ToString(dr["nm_genero"]),
                        cel_usuario = Convert.ToString(dr["cel_usuario"]),
                        eml_usuario = Convert.ToString(dr["eml_usuario"]),
                        img_usuario = Convert.ToString(dr["img_usuario"]),
                        cep_usuario = Convert.ToString(dr["cep_usuario"]),
                        log_usuario = Convert.ToString(dr["log_usuario"]),
                        bar_usuario = Convert.ToString(dr["bar_usuario"]),
                        cid_usuario = Convert.ToString(dr["cid_usuario"]),
                        uf_usuario = Convert.ToString(dr["uf_usuario"]),
                        sh_usuario = Convert.ToString(dr["sh_usuario"])
                    });
            }
            return UsuarioList;
        }

        public List<modelUsuario> listarInformacaoesCarrinho(string id)
        {
            List<modelUsuario> CarrinhoList = new List<modelUsuario>();

            MySqlCommand cmd = new MySqlCommand("select cd_venda, nm_usuario, dt_venda, hr_venda, vl_venda from viewCarrinho where cd_usuario = @cdUsuario group by cd_venda;", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@cdUsuario", id);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                CarrinhoList.Add(
                    new modelUsuario
                    {
                        cd_venda = Convert.ToString(dr["cd_venda"]),
                        nm_usuario = Convert.ToString(dr["nm_usuario"]),
                        vl_venda = Convert.ToString(dr["vl_venda"]),
                        dt_venda = Convert.ToString(dr["dt_venda"]),
                        hr_venda = Convert.ToString(dr["hr_venda"])
                    });
            }
            return CarrinhoList;
        }

        public bool excluirUsuario(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("call excluirUsuario(@cdUsuario)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdUsuario", cd);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool atualizarUsuario(modelUsuario model)
        {
            MySqlCommand cmd = new MySqlCommand("call atualizarUsuario(@cdUsuario, @nmUsuario, @cpfUsuario, @cdGenero, @celUsuario, @emlUsuario, @imgUsuario, @cepUsuario, @logUsuario, @barUsuario, @cidUsuario, @ufUsuario, @shUsuario)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdUsuario", model.cd_usuario);
            cmd.Parameters.AddWithValue("@nmUsuario", model.nm_usuario);
            cmd.Parameters.AddWithValue("@cpfUsuario", model.cpf_usuario);
            cmd.Parameters.AddWithValue("@cdGenero", model.cd_genero);
            cmd.Parameters.AddWithValue("@celUsuario", model.cel_usuario);
            cmd.Parameters.AddWithValue("@emlUsuario", model.eml_usuario);
            cmd.Parameters.AddWithValue("@imgUsuario", model.img_usuario);
            cmd.Parameters.AddWithValue("@cepUsuario", model.cep_usuario);
            cmd.Parameters.AddWithValue("@logUsuario", model.log_usuario);
            cmd.Parameters.AddWithValue("@barUsuario", model.bar_usuario);
            cmd.Parameters.AddWithValue("@cidUsuario", model.cid_usuario);
            cmd.Parameters.AddWithValue("@ufUsuario", model.uf_usuario);
            cmd.Parameters.AddWithValue("@shUsuario", model.sh_usuario);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}