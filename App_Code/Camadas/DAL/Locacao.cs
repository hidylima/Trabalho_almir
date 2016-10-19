using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCAR.Camadas.DAL
{
    public class Locacao
    {
        private string strCon = @"Data Source=LUIZ\TESTES;Initial Catalog=Trabalho;Integrated Security=True";
        public Model.Locacao SelectLocacaoById(int Id)
        {
            Model.Locacao locacao = new Model.Locacao();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Locacao where IdLocacao = @Id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@Id", Id);
            conexao.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            try
            {
                if (reader.Read())
                {
                    locacao.IdLocacao = Convert.ToInt32(reader["IdLocacao"]);
                    locacao.IdCliente = reader["IdCliente"].ToString();
                    locacao.IdVeiculo = reader["IdVeiculo"].ToString();
                    locacao.Data_locacao = reader["Data_locacao"].ToString();
                    locacao.Data_devolucao = reader["Data_devolucao"].ToString();
                    locacao.Valor_total = Convert.ToDecimal(reader["Valor_total"]);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na execucao de select de locacao por Codigo..");
            }
            finally
            {
                conexao.Close();
            }
            return locacao;
        }
        public List<Model.Locacao> Select()
        {
            List<Model.Locacao> lstLocacao = new List<Model.Locacao>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Locacao";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            try
            {
                while (reader.Read())
                {
                    Model.Locacao locacao = new Model.Locacao();
                    locacao.IdLocacao = Convert.ToInt32(reader["IdLocacao"]);
                    locacao.IdCliente = reader["IdCliente"].ToString();
                    locacao.IdVeiculo = reader["IdVeiculo"].ToString();
                    locacao.Data_locacao = reader["Data_locacao"].ToString();
                    locacao.Data_devolucao = reader["Data_devolucao"].ToString();
                    locacao.Valor_total = Convert.ToDecimal(reader["Valor_total"]);
                    lstLocacao.Add(locacao);
                }
            }
            finally
            {
                conexao.Close();
            }
            return lstLocacao;
        }
        public void Insert(Model.Locacao locacao)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Locacao values (@IdCli, @IdVei, @Data_loc, @Data_dev, @Vl_tot)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@IdCli", locacao.IdCliente);
            cmd.Parameters.AddWithValue("@IdVei", locacao.IdVeiculo);
            cmd.Parameters.AddWithValue("@Data_loc", locacao.Data_locacao);
            cmd.Parameters.AddWithValue("@Data_dev", locacao.Data_devolucao);
            cmd.Parameters.AddWithValue("@Vl_tot", locacao.Valor_total);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na insercao de Locacoes");
            }
            finally
            {
                conexao.Close();
            }
        }
        public void Update(Model.Locacao locacao)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Locacao set IdCliente=@IdCli, IdVeiculo=@IdVei, Data_locacao=@Data_loc, Data_devolucao=@Data_dev, Valor_total=@Vl_tot where IdLocacao=@IdLocacao";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@IdLocacao", locacao.IdLocacao);
            cmd.Parameters.AddWithValue("@IdCli", locacao.IdCliente);
            cmd.Parameters.AddWithValue("@IdVei", locacao.IdVeiculo);
            cmd.Parameters.AddWithValue("@Data_loc", locacao.Data_locacao);
            cmd.Parameters.AddWithValue("@Data_dev", locacao.Data_devolucao);
            cmd.Parameters.AddWithValue("@Vl_tot", locacao.Valor_total);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na atualizacao de Locacoes...");
            }
            finally
            {
                conexao.Close();
            }
        }
        public void Delete(Model.Locacao locacao)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Locacao where IdLocacao=@IdLocacao;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@IdLocacao", locacao.IdLocacao);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na remocao de Locacao...");
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}