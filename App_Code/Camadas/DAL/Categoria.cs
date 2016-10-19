using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCAR.Camadas.DAL
{
    public class Categoria
    {
        private string strCon = @"Data Source=LUIZ\TESTES;Initial Catalog=Locavel;Integrated Security=True";
        public Model.Categoria SelectCategoriaById(int id)
        {
            Model.Categoria categoria = new Model.Categoria();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Categorias where idCategoria=@id;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);
            conexao.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            try
            {
                if (reader.Read())
                {
                    categoria.IdCategoria = Convert.ToInt32(reader[0]);
                    categoria.Descricao = reader["Descricao"].ToString();
                    categoria.Valor = Convert.ToDecimal(reader["Valor"]);
                    categoria.qtdeVeiculos = Convert.ToInt32(reader["qtdeVeiculos"]);
                }
            }
            finally
            {
                conexao.Close();
            }
            return categoria;
        }
        public List<Model.Categoria> Select()
        {
            List<Model.Categoria> lstCategoria = new List<Model.Categoria>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Categorias;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            try
            {
                while(reader.Read())
                {
                    Model.Categoria categoria = new Model.Categoria();
                    categoria.IdCategoria = Convert.ToInt32(reader[0]);
                    categoria.Descricao = reader["Descricao"].ToString();
                    categoria.Valor = Convert.ToDecimal(reader["Valor"]);
                    categoria.qtdeVeiculos = Convert.ToInt32(reader["qtdeVeiculos"]);
                    lstCategoria.Add(categoria);
                }
            }
            finally
            {
                conexao.Close();
            }
            return lstCategoria;
        }
        public void Insert(Model.Categoria categoria)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Categorias values (Descricao, Valor qtdeVeiculos)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@desc", categoria.Descricao);
            cmd.Parameters.AddWithValue("@valor", categoria.Valor);
            cmd.Parameters.AddWithValue("@qtde", categoria.qtdeVeiculos);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na insercao de Categorias");
            }
            finally
            {
                conexao.Close();
            }
        }
        public void Update(Model.Categoria categoria)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Categorias set Descricao=@desc, Valor=@valor, qtdeVeiculos=@qtde where IdCategoria=@IdCategoria";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@IdCategoria", categoria.IdCategoria);
            cmd.Parameters.AddWithValue("@desc", categoria.Descricao);
            cmd.Parameters.AddWithValue("@valor", categoria.Valor);
            cmd.Parameters.AddWithValue("@qtde", categoria.qtdeVeiculos);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na atualizacao de Categorias...");
            }
            finally
            {
                conexao.Close();
            }
        }
        public void Delete(Model.Categoria categoria)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Categorias where IdCategoria=@IdCategoria;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@IdCategoria", categoria.IdCategoria);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na remocao de Categorias...");
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}