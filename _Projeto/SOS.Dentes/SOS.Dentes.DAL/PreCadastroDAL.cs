using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SOS.Dentes.Model;

namespace SOS.Dentes.DAL
{
    public class PreCadastroDAL : SQLHelper<PreCadastro>
    {
        private SqlConnection con;
        private SqlCommand comando;

        public PreCadastroDAL()
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


        public void create(PreCadastro obj)
        {
            string sqlInsert = "insert into PreCadastro(Nome, Email, Telefone, Celular) " +
                " values('" + obj.Nome + "','" + obj.Email + "','" + obj.Telefone + "','" + obj.Celular + "')";

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

        public void delete(PreCadastro obj)
        {
            string sqlDelete = "delete from PreCadastro where id_PreCadastro =" + obj.IdPreCadastro;
            try
            {
                this.abrirConexao();
                this.comando = new SqlCommand(sqlDelete, this.con);
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

        public bool find(PreCadastro obj)
        {
            bool temRegistro = false;
            string sqlFind = "select * from PreCadastro where id_PreCadastro = " + obj.IdPreCadastro;
            try
            {
                this.abrirConexao();
                this.comando = new SqlCommand(sqlFind, this.con);
                SqlDataReader reader = this.comando.ExecuteReader();
                temRegistro = reader.Read();
                if (temRegistro)
                {
                    obj.Nome = reader[1].ToString();
                    obj.Email= reader[2].ToString();
                    obj.Telefone = reader[3].ToString();
                    obj.Celular = reader[4].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.con.Close();
            }
            return temRegistro;
        }

        public List<PreCadastro> findAll()
        {
            List<PreCadastro> listaCategoria = new List<PreCadastro>();
            string sqlFindAll = "select * from PreCadastro where order by id_PreCadastro ";
            try
            {
                this.abrirConexao();
                this.comando = new SqlCommand(sqlFindAll, this.con);
                SqlDataReader reader = this.comando.ExecuteReader();
                while (reader.Read())
                {
                    PreCadastro cat = new PreCadastro();
                    cat.IdPreCadastro = Convert.ToInt32(reader[0].ToString());
                    cat.Nome = reader[1].ToString();
                    cat.Email = reader[2].ToString();
                    cat.Telefone = reader[3].ToString();
                    cat.Celular = reader[4].ToString();
                    listaCategoria.Add(cat);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.con.Close();
            }

            return listaCategoria;
        }

        public void update(PreCadastro obj)
        {
            string sqlUpdate = "update PreCadastro set " +
                " Nome = '" + obj.Nome + "'"+ 
                ", Email = '" + obj.Email + "'" +
                ", Telefone = '" + obj.Telefone + "'" +
                ", Celular = '" + obj.Celular + "'" +
                " where id_PreCadastro = " + obj.IdPreCadastro; 
            try
            {
                this.abrirConexao();
                this.comando = new SqlCommand(sqlUpdate, this.con);
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
    }
}
