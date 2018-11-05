using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SOS.Dentes.Model;

namespace SOS.Dentes.DAL
{
    public class ContatoDAL : SQLHelper<Contato>
    {
        private SqlConnection con;
        private SqlCommand comando;

        public ContatoDAL()
        {
            this.con = FabricaConexao.getConexao();
        }
        public void abrirConexao()
        {
            if (this.con.State == ConnectionState.Closed)
            {
                this.con.Open();
            }
        }
        public void create(Contato obj)
        {
            string sqlInsert = "insert into Contato (Avaliacao, Nome, Email, Telefone, Mensagem) " +
                " values('" + obj.Avaliacao + "','" + obj.Nome + "','" + obj.Email + "','" + obj.Telefone + "','" + obj.Mensagem + "')";

            try
            {
                this.abrirConexao();
                this.comando = new SqlCommand(sqlInsert, this.con);
                this.comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.con.Close();
            }
        }

        public void delete(Contato obj)
        {
            throw new NotImplementedException();
        }

        public bool find(Contato obj)
        {
            throw new NotImplementedException();
        }

        public List<Contato> findAll()
        {
            throw new NotImplementedException();
        }

        public void update(Contato obj)
        {
            throw new NotImplementedException();
        }
    }
}
