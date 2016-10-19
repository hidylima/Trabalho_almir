using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOCAR.Camadas.DAL
{
    public class Veiculo
    {
        private string strCon = @"Data Source=LUIZ\TESTES;Initial Catalog=Trabalho;Integrated Security=True";
        public Model.Veiculo SelectVeiculoById(int Id)
        {
            Model.Veiculo veiculo = new Model.Veiculo();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Veiculo where IdVeiculo = @Id";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@Id", Id);
            conexao.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            try
            {
                if (reader.Read())
                {
                    veiculo.IdVeiculo = Convert.ToInt32(reader["IdVeiculo"]);
                    veiculo.Placa = reader["Placa"].ToString();
                    veiculo.Renavam = reader["Renavam"].ToString();
                    veiculo.Cor = reader["Cor"].ToString();
                    veiculo.Categoria = Convert.ToInt32(reader["Categoria"]);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na execucao de select de veiculo por Codigo..");
            }
            finally
            {
                conexao.Close();
            }
            return veiculo;
        }
        public List<Model.Veiculo> SelectVeiculoByPlaca(string Placa)
        {
            List<Model.Veiculo> lstVeiculo = new List<Model.Veiculo>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Veiculo where (Placa like @Placa)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@Placa", Placa + "%");
            conexao.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            try
            {
                while (reader.Read())
                {
                    Model.Veiculo veiculo = new Model.Veiculo();
                    veiculo.IdVeiculo = Convert.ToInt32(reader["IdVeiculo"]);
                    veiculo.Placa = reader["Placa"].ToString();
                    veiculo.Renavam = reader["Renavam"].ToString();
                    veiculo.Cor = reader["Cor"].ToString();
                    veiculo.Categoria = Convert.ToInt32(reader["Categoria"]);
                    lstVeiculo.Add(veiculo);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro na execucao de select de Veiculo por placa..");
            }
            finally
            {
                conexao.Close();
            }
            return lstVeiculo;
        }
        public List<Model.Veiculo> Select()
        {
            List<Model.Veiculo> lstVeiculo = new List<Model.Veiculo>();
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Select * from Veiculo;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            conexao.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            try
            {
                while (reader.Read())
                {
                    Model.Veiculo veiculo = new Model.Veiculo();
                    veiculo.IdVeiculo = Convert.ToInt32(reader[0]);
                    veiculo.Placa = reader["placa"].ToString();
                    veiculo.Renavam = reader["Renavam"].ToString();
                    veiculo.Cor = reader["Cor"].ToString();
                    veiculo.Categoria = Convert.ToInt32(reader["Categoria"].ToString());
                    lstVeiculo.Add(veiculo);
                }
            }
            finally
            {
                conexao.Close();
            }
            return lstVeiculo;
        }
        public void Insert(Model.Veiculo veiculo)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Insert into Veiculo values (@Placa, @Ren, @Cor, @Categ)";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@Placa", veiculo.Placa);
            cmd.Parameters.AddWithValue("@Ren", veiculo.Renavam);
            cmd.Parameters.AddWithValue("@Cor", veiculo.Cor);
            cmd.Parameters.AddWithValue("@Categ", veiculo.Categoria);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na insercao de Veiculos");
            }
            finally
            {
                conexao.Close();
            }
        }
        public void Update(Model.Veiculo veiculo)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Update Veiculo set Placa=@Placa, Renavam=@Ren, Cor=@Cor, Categoria=@Categ where IdVeiculo=@IdVeiculo";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@IdVeiculo", veiculo.IdVeiculo);
            cmd.Parameters.AddWithValue("@Placa", veiculo.Placa);
            cmd.Parameters.AddWithValue("@Ren", veiculo.Renavam);
            cmd.Parameters.AddWithValue("@Cor", veiculo.Cor);
            cmd.Parameters.AddWithValue("@Categ", veiculo.Categoria);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na atualizacao de Veiculos...");
            }
            finally
            {
                conexao.Close();
            }
        }
        public void Delete(Model.Veiculo veiculo)
        {
            SqlConnection conexao = new SqlConnection(strCon);
            string sql = "Delete from Veiculo where IdVeiculo=@IdVeiculo;";
            SqlCommand cmd = new SqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@IdVeiculo", veiculo.IdVeiculo);
            conexao.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Deu erro na remocao de Veiculo...");
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}