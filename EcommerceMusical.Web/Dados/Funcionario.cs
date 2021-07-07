using EcommerceMusical.Web.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EcommerceMusical.Web.Dados
{
    public class Funcionario
    {
        // instanciando a classe de conexao
        Conexao con = new Conexao();

        public void inserirFuncionario(modelFuncionario model)
        {
            MySqlCommand cmd = new MySqlCommand("call cadastrarFuncionario(@nmFuncionario, @idaFuncionario, @cpfFuncionario, @cdGenero, @celFuncionario, @emlFuncionario, @shFuncionario, @imgFuncionario, @cepFuncionario, @tpFuncionario)", con.MyConectarBD());

            cmd.Parameters.Add("@nmFuncionario", MySqlDbType.VarChar).Value = model.nm_funcionario;
            cmd.Parameters.Add("@idaFuncionario", MySqlDbType.VarChar).Value = model.ida_funcionario;
            cmd.Parameters.Add("@cpfFuncionario", MySqlDbType.VarChar).Value = model.cpf_funcionario;
            cmd.Parameters.Add("@cdGenero", MySqlDbType.VarChar).Value = model.cd_genero;
            cmd.Parameters.Add("@celFuncionario", MySqlDbType.VarChar).Value = model.cel_funcionario;
            cmd.Parameters.Add("@emlFuncionario", MySqlDbType.VarChar).Value = model.eml_funcionario;
            cmd.Parameters.Add("@shFuncionario", MySqlDbType.VarChar).Value = model.sh_funcionario;
            cmd.Parameters.Add("@imgFuncionario", MySqlDbType.VarChar).Value = model.img_funcionario;
            cmd.Parameters.Add("@cepFuncionario", MySqlDbType.VarChar).Value = model.cep_funcionario;
            cmd.Parameters.Add("@tpFuncionario", MySqlDbType.VarChar).Value = model.tp_funcionario;

            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public List<modelFuncionario> listarFuncionario()
        {
            List<modelFuncionario> FuncionarioList = new List<modelFuncionario>();

            MySqlCommand cmd = new MySqlCommand("call listarFuncionario()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                FuncionarioList.Add(
                    new modelFuncionario
                    {
                        cd_funcionario = Convert.ToString(dr["cd_funcionario"]),
                        nm_funcionario = Convert.ToString(dr["nm_funcionario"]),
                        ida_funcionario = Convert.ToString(dr["ida_funcionario"]),
                        cpf_funcionario = Convert.ToString(dr["cpf_funcionario"]),
                        nm_genero = Convert.ToString(dr["nm_genero"]),
                        cel_funcionario = Convert.ToString(dr["cel_funcionario"]),
                        eml_funcionario = Convert.ToString(dr["eml_funcionario"]),
                        sh_funcionario = Convert.ToString(dr["sh_funcionario"]),
                        img_funcionario = Convert.ToString(dr["img_funcionario"]),
                        cep_funcionario = Convert.ToString(dr["cep_funcionario"]),
                        tp_funcionario = Convert.ToString(dr["tp_funcionario"])
                    });
            }
            return FuncionarioList;
        }

        public bool excluirFuncionario(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("call excluirFuncionario(@cdFuncionario)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdFuncionario", cd);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool atualizarFuncionario(modelFuncionario model)
        {
            MySqlCommand cmd = new MySqlCommand("call atualizarFuncionario(@cdFuncionario, @nmFuncionario, @idaFuncionario, @cpfFuncionario, @cdGenero, @celFuncionario, @emlFuncionario, @shFuncionario, @imgFuncionario, @cepFuncionario, @tpFuncionario)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cdFuncionario", model.cd_funcionario);
            cmd.Parameters.AddWithValue("@nmFuncionario", model.nm_funcionario);
            cmd.Parameters.AddWithValue("@idaFuncionario", model.ida_funcionario);
            cmd.Parameters.AddWithValue("@cpfFuncionario", model.cpf_funcionario);
            cmd.Parameters.AddWithValue("@cdGenero", model.cd_genero);
            cmd.Parameters.AddWithValue("@celFuncionario", model.cel_funcionario);
            cmd.Parameters.AddWithValue("@emlFuncionario", model.eml_funcionario);
            cmd.Parameters.AddWithValue("@shFuncionario", model.sh_funcionario);
            cmd.Parameters.AddWithValue("@cepFuncionario", model.cep_funcionario);
            cmd.Parameters.AddWithValue("@imgFuncionario", model.img_funcionario);
            cmd.Parameters.AddWithValue("@tpFuncionario", model.tp_funcionario);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}