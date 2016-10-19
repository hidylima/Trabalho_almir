using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCAR.Camadas.DAL
{
    public class Table // camada de devolução
    {
        private string strCon = @"Data Source=LUIZ\TESTES;Initial Catalog=Trabalho;Integrated Security=True";
        public List<Model.Table> Select()
        {
            List<Model.Table> lstTable = new List<Model.Table>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Table";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            try
            {
                while (reader.Read())
                {
                    Model.Table table = new Model.Table();
                    table.IdDevolucao = Convert.ToInt32(reader[0]);
                    table.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    table.IdVeiculo = Convert.ToInt32(reader["IdVeiculo"]);
                    table.Data_devolucao = Convert.ToDateTime(reader["Data_devolucao"]);
                    lstTable.Add(table);
                }
            }
            finally
            {
                conexao.Close();
            }
            return lstTable;
        }
        public void Insert(Model.Table table)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Table values (@IdCli, @IdVei, @Data_dev)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@IdCli", table.IdCliente);
            cmd.Parameters.AddWithValue("@IdVei", table.IdVeiculo);
            cmd.Parameters.AddWithValue("@Data_dev", table.Data_devolucao);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na insercao de Devolucoes");
            }
            finally
            {
                conexao.Close();
            }
        }
        public void Update(Model.Table table)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Table set IdCliente=@IdCli, IdVeiculo=@IdVei, Data_devolucao=@Data_dev where IdDevolucao=@IdDevolucao";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@IdDevolucao", table.IdDevolucao);
            cmd.Parameters.AddWithValue("@IdCli", table.IdCliente);
            cmd.Parameters.AddWithValue("@IdVei", table.IdVeiculo);
            cmd.Parameters.AddWithValue("@Data_dev", table.Data_devolucao);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na atualizacao de Devolucoes...");
            }
            finally
            {
                conexao.Close();
            }
        }
        public void Delete(Model.Table table)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Table where IdDevolucao=@IdDevolucao;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@IdDevolucao", table.IdDevolucao);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na remocao de Devolucoes...");
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}