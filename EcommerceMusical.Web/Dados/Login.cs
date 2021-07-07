using EcommerceMusical.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EcommerceMusical.Web.Dados
{
    public class Login
    {
        // instanciando a classe de conexao
        Conexao con = new Conexao();

        // método de testar o usuário do banco
        public void testarUsuario(modelLogin user)
        {
            MySqlCommand cmd = new MySqlCommand("call testarUsuario(@emlUsuario, @shUsuario)", con.MyConectarBD());

            cmd.Parameters.Add("@emlUsuario", MySqlDbType.VarChar).Value = user.eml_usuario;
            cmd.Parameters.Add("@shUsuario", MySqlDbType.VarChar).Value = user.sh_usuario;

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.cd_usuario = Convert.ToString(leitor["cd_usuario"]);
                    user.nm_usuario = Convert.ToString(leitor["nm_usuario"]);
                    user.cpf_usuario = Convert.ToString(leitor["cpf_usuario"]);
                    user.cd_genero = Convert.ToString(leitor["cd_genero"]);
                    user.cel_usuario = Convert.ToString(leitor["cel_usuario"]);
                    user.eml_usuario = Convert.ToString(leitor["eml_usuario"]);
                    user.img_usuario = Convert.ToString(leitor["img_usuario"]);
                    user.cep_usuario = Convert.ToString(leitor["cep_usuario"]);
                    user.log_usuario = Convert.ToString(leitor["log_usuario"]);
                    user.bar_usuario = Convert.ToString(leitor["bar_usuario"]);
                    user.cid_usuario = Convert.ToString(leitor["cid_usuario"]);
                    user.uf_usuario = Convert.ToString(leitor["uf_usuario"]);
                    user.sh_usuario = Convert.ToString(leitor["sh_usuario"]);
                    user.tp_usuario = Convert.ToString(leitor["tp_usuario"]);
                }
            }

            else
            {
                user.eml_usuario = null;
                user.sh_usuario = null;
                user.tp_usuario = null;
            }

            con.MyDesconectarBD();
        }

        public void testarUsuarioFuncionario(modelLogin user)
        {
            MySqlCommand cmd = new MySqlCommand("call testarUsuarioFuncionario(@emlFuncionario, @shFuncionario)", con.MyConectarBD());

            cmd.Parameters.Add("@emlFuncionario", MySqlDbType.VarChar).Value = user.eml_funcionario;
            cmd.Parameters.Add("@shFuncionario", MySqlDbType.VarChar).Value = user.sh_funcionario;

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.eml_funcionario = Convert.ToString(leitor["eml_funcionario"]);
                    user.sh_funcionario = Convert.ToString(leitor["sh_funcionario"]);
                    user.tp_funcionario = Convert.ToString(leitor["tp_funcionario"]);
                }
            }

            else
            {
                user.eml_funcionario = null;
                user.sh_funcionario = null;
                user.tp_funcionario = null;
            }

            con.MyDesconectarBD();
        }
    }
}